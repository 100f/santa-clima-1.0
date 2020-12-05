using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.IO.Ports;
using System.Management;
using System.Globalization;

namespace SantaClima
{
    public partial class Main : Form
    {
        public DataAccess database;

        private byte menuItemSelected = 255;
        private byte previouslySelectedIndex = 0;
        private bool isConnected = false;
        private IFormatProvider myFormat = CultureInfo.InvariantCulture;
        ToolTip descriptions = new ToolTip();        
        public Main()
        {
            InitializeComponent();
            try
            {
                database = new DataAccess("DBSantaClima");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }

            cmbPortas.Items.Clear();
            cmbPortas.DataSource = SerialPort.GetPortNames();
            pnlDados.Visible = false;
            
            lblMensagemInicial.Location = new Point(190, 235);
            lblMensagemInicial.Visible = true;
        }
        #region sobrescrita de método para tornar a janela arrastável
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        #endregion
        #region inicializações
        private void Main_Load(object sender, EventArgs e)
        {
            #region descrições dos botões (tooltip)
            descriptions.SetToolTip(btnMenuDirecaoDoVento, "Direção do Vento");
            descriptions.SetToolTip(btnMenuPrecipitacao, "Precipitação");
            descriptions.SetToolTip(btnMenuVelocidadeDoVento, "Velocidade do Vento");
            descriptions.SetToolTip(btnMenuPressaoAtmosferica, "Pressão Atmosférica");
            descriptions.SetToolTip(btnMenuTemperatura, "Temperatura");
            descriptions.SetToolTip(btnMenuUmidade, "Umidade");
            #endregion
            lblValorDePico.Text = "0";
            setValueLabelsToDefault("empty");
            #region pendura cor de texto e eventos hover dos labels (visual)
            foreach (Label control in pnlDados.Controls.OfType<Label>())
            {
                if (control.Name.Contains("lblValor") || control.Name.Contains("lblUnidade"))
                {
                    control.ForeColor = Color.FromArgb(60,116,164); // #3C74A4
                    control.MouseEnter += LblValor_MouseEnter;
                    control.MouseLeave += LblValor_MouseLeave;
                }
            }
            cmbUnidades.ForeColor = Color.FromArgb(60, 116, 164);
            #endregion
        }
        #endregion
        #region evento de coleta dos dados da estação
        private void EspPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(GetDataFromEsp));
        }
        private void GetDataFromEsp(object sender, EventArgs e)
        {
            try
            {
                //PROTOCOLO: #PRC,#VEL,#DIR,#TMP,#UMI,#PRA
                string dataReceived = espPort.ReadLine();

                WeatherStationModel registroAtual = new WeatherStationModel();

                string[] dataComponents = dataReceived.Split(',');

                foreach (string dataComponent in dataComponents)
                {
                    string prefix = dataComponent.Substring(0, 4);
                    switch (prefix)
                    {
                        case "#PRC":
                            registroAtual.Precipitacao = double.Parse(dataComponent.Substring(4), myFormat);
                            if (cmbUnidades.SelectedIndex == 0) //mm
                                lblValorPrecipitacao.Text = Math.Round(registroAtual.Precipitacao, 5).ToString(myFormat);
                            else //m
                                lblValorPrecipitacao.Text = Math.Round(registroAtual.Precipitacao * Math.Pow(10, -3), 5).ToString(myFormat);
                            break;
                        case "#VEL":
                            registroAtual.VelocidadeDoVento = double.Parse(dataComponent.Substring(4), myFormat);
                            if (cmbUnidades.SelectedIndex == 0)
                                lblValorVelocidadeDoVento.Text = Math.Round(registroAtual.VelocidadeDoVento, 5).ToString(myFormat);
                            else
                                lblValorVelocidadeDoVento.Text = Math.Round(registroAtual.VelocidadeDoVento / 3.6, 5).ToString(myFormat);
                            break;
                        case "#DIR":
                            registroAtual.DirecaoDoVento = double.Parse(dataComponent.Substring(4), myFormat);
                            lblValorDirecaoDoVento.Text = dataComponent.Substring(4);
                            break;
                        case "#TMP":
                            registroAtual.Temperatura = double.Parse(dataComponent.Substring(4), myFormat);
                            if (cmbUnidades.SelectedIndex == 0)
                                lblValorTemperatura.Text = Math.Round(registroAtual.Temperatura, 5).ToString(myFormat);
                            else
                                lblValorTemperatura.Text = Math.Round((registroAtual.Temperatura * 1.8 + 32), 5).ToString(myFormat);
                            break;
                        case "#UMI":
                            registroAtual.Umidade = double.Parse(dataComponent.Substring(4), myFormat); 
                            lblValorUmidade.Text = Math.Round(registroAtual.Umidade, 5).ToString(myFormat);
                            break;
                        case "#PRA":
                            registroAtual.PressaoAtmosferica = double.Parse(dataComponent.Substring(4, dataComponent.IndexOf("\r") - 4), myFormat);
                            if (cmbUnidades.SelectedIndex == 0) //hPa
                                lblValorPressaoAtmosferica.Text = Math.Round(registroAtual.PressaoAtmosferica, 5).ToString(myFormat);
                            else
                            if (cmbUnidades.SelectedIndex == 1) //atm
                                lblValorPressaoAtmosferica.Text = Math.Round(registroAtual.PressaoAtmosferica * (9.87 * Math.Pow(10, -4)), 5).ToString(myFormat);
                            else
                            if (cmbUnidades.SelectedIndex == 2) //bar
                                lblValorPressaoAtmosferica.Text = Math.Round((registroAtual.PressaoAtmosferica * Math.Pow(10, -3)), 5).ToString(myFormat);
                            break;
                        default:
                            break;
                    }
                }
                registroAtual.DataDeCriacao = DateTime.Now;
                
                database.insertRegister<WeatherStationModel>("Data", registroAtual);

                #region mostra novo valor de pico recente
                if (menuItemSelected >= 1 && menuItemSelected <= 6) //caso o usuário tenha clicado em um dos botões, checar qual parâmetro ele está vendo no momento
                {
                    double valorDePico;
                    switch (menuItemSelected)
                    {
                        case 1: //Velocidade do vento
                            valorDePico = database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "VelocidadeDoVento");
                            if (cmbUnidades.SelectedIndex == 0)
                                lblValorDePico.Text = $"{Math.Round(valorDePico, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            else
                                lblValorDePico.Text = $"{Math.Round(valorDePico / 3.6, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            break;
                        case 2: //Direção do vento
                            valorDePico = database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "DirecaoDoVento");
                            lblValorDePico.Text = $"{Math.Round(valorDePico, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            break;
                        case 3: //Precipitação
                            valorDePico = database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "Precipitacao");
                            if (cmbUnidades.SelectedIndex == 0)
                                lblValorDePico.Text = $"{Math.Round(valorDePico, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            else
                                lblValorDePico.Text = $"{Math.Round(valorDePico * Math.Pow(10, -3), 5).ToString(myFormat)} {cmbUnidades.SelectedItem}"; 
                            break;
                        case 4: //Temperatura
                            valorDePico = database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "Temperatura");
                            if (cmbUnidades.SelectedIndex == 0)
                                lblValorDePico.Text = $"{Math.Round(valorDePico, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            else
                                lblValorDePico.Text = $"{Math.Round(valorDePico * 1.8 + 32, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            break;
                        case 5: //Pressão Atmosférica
                            valorDePico = database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "PressaoAtmosferica");
                            if (cmbUnidades.SelectedIndex == 0) //hPa
                                lblValorDePico.Text = $"{Math.Round(valorDePico, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            else
                            if (cmbUnidades.SelectedIndex == 1) //atm
                                lblValorDePico.Text = $"{Math.Round(valorDePico * (9.87 * Math.Pow(10, -4)), 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            else
                            if (cmbUnidades.SelectedIndex == 2) //bar
                                lblValorPressaoAtmosferica.Text = Math.Round(valorDePico * Math.Pow(10, -3), 5).ToString(myFormat);
                            break;
                        case 6: //Umidade
                            valorDePico = database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "Umidade");
                            lblValorDePico.Text = $"{Math.Round(valorDePico, 5).ToString(myFormat)} {cmbUnidades.SelectedItem}";
                            break;
                        default:
                            break;
                    }
                }
            #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        

        #region funções de reset visual e de valores
        private void setButtonsToDefault()
        {
            btnMenuDirecaoDoVento.BackgroundImage = Properties.Resources.biruta_default;
            btnMenuPrecipitacao.BackgroundImage = Properties.Resources.rain_default;
            btnMenuVelocidadeDoVento.BackgroundImage = Properties.Resources.wind_speed_default;
            btnMenuPressaoAtmosferica.BackgroundImage = Properties.Resources.pressao_default;
            btnMenuTemperatura.BackgroundImage = Properties.Resources.temperature_default;
            btnMenuUmidade.BackgroundImage = Properties.Resources.drop_default;
        }
        private void setValueLabelsToDefault(string _mode)
        {
            
                foreach(Label control in pnlDados.Controls.OfType<Label>())
                {
                    if (control.Name.Contains("lblValor") && !control.Name.Contains("Pico"))
                    {
                        if (_mode == "hide")
                            control.Visible = false;
                        else if (_mode == "empty")
                            control.Text = "0";
                        else
                            return;
                    }
                }
        }
        #endregion
        #region hover dos labels e combobox
        private void LblValor_MouseEnter(object sender, EventArgs e)
        {
            Label _sender = sender as Label;
            _sender.ForeColor = Color.FromArgb(237, 102, 99);
        }
        private void LblValor_MouseLeave(object sender, EventArgs e)
        {
            Label _sender = sender as Label;
            _sender.ForeColor = Color.FromArgb(60, 116, 164);
        }
        private void CmbUnidades_MouseEnter(object sender, EventArgs e) 
        {
            cmbUnidades.ForeColor = Color.FromArgb(237, 102, 99); 
        }
        private void CmbUnidades_MouseLeave(object sender, EventArgs e)
        {
            cmbUnidades.ForeColor = Color.FromArgb(60, 116, 164);
        }
        #endregion

        #region encerramento do programa
        private void BtnFecharAplicacao_Click(object sender, EventArgs e)
        {
            fechaAplicacao();
        }
        private void fechaAplicacao()
        {
            if (MessageBox.Show("Deseja mesmo sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }
        #endregion
        #region interação visual dos botões do menu/fechar
        private void MenuItem_MouseEnter(object sender, EventArgs e)
        {
            PictureBox _sender = sender as PictureBox;
            switch (_sender.Name)
            {
                case "btnMenuVelocidadeDoVento":
                    _sender.BackgroundImage = Properties.Resources.wind_speed_hovered;
                    break;
                case "btnMenuDirecaoDoVento":
                    _sender.BackgroundImage = Properties.Resources.biruta_hovered;
                    break;
                case "btnMenuPrecipitacao":
                    _sender.BackgroundImage = Properties.Resources.rain_hovered;
                    break;
                case "btnMenuTemperatura":
                    _sender.BackgroundImage = Properties.Resources.temperature_hovered;
                    break;
                case "btnMenuPressaoAtmosferica":
                    _sender.BackgroundImage = Properties.Resources.pressao_hovered;
                    break;
                case "btnMenuUmidade":
                    _sender.BackgroundImage = Properties.Resources.drop_hovered;
                    break;
                case "btnFecharAplicacao":
                    _sender.BackgroundImage = Properties.Resources.close_hovered;
                    break;
                default:
                    break;
            }
        }
        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            PictureBox _sender = sender as PictureBox;
            switch (_sender.Name)
            {
                case "btnMenuVelocidadeDoVento":
                    if (menuItemSelected != 1)
                        _sender.BackgroundImage = Properties.Resources.wind_speed_default;
                    break;
                case "btnMenuDirecaoDoVento":
                    if (menuItemSelected != 2)
                        _sender.BackgroundImage = Properties.Resources.biruta_default;
                    break;
                case "btnMenuPrecipitacao":
                    if (menuItemSelected != 3)
                        _sender.BackgroundImage = Properties.Resources.rain_default;
                    break;
                case "btnMenuTemperatura":
                    if (menuItemSelected != 4)
                        _sender.BackgroundImage = Properties.Resources.temperature_default;
                    break;
                case "btnMenuPressaoAtmosferica":
                    if (menuItemSelected != 5)
                        _sender.BackgroundImage = Properties.Resources.pressao_default;
                    break;
                case "btnMenuUmidade":
                    if (menuItemSelected != 6)
                        _sender.BackgroundImage = Properties.Resources.drop_default;
                    break;
                case "btnFecharAplicacao":
                    _sender.BackgroundImage = Properties.Resources.close_default;
                    break;
                default:
                    break;
            }
        }
        #endregion
        private void MenuItem_Click(object sender, EventArgs e)
        {
            lblMensagemInicial.Visible = false;
            PictureBox _sender = sender as PictureBox;
            pnlDados.Visible = true;
            setButtonsToDefault();
            setValueLabelsToDefault("hide");
            cmbUnidades.DataSource = null;

            switch (_sender.Name)
            {
                case "btnMenuVelocidadeDoVento":
                    lblTitulo.Text = "Velocidade do vento";
                    lblValorVelocidadeDoVento.Visible = true;
                    lblUnidade.Text = "Km/h";
                    cmbUnidades.DataSource = new[] { "KM/h", "m/s" };
                    lblValorDePico.Text = $"{database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "VelocidadeDoVento").ToString(myFormat)} {lblUnidade.Text}";
                    _sender.BackgroundImage = Properties.Resources.wind_speed_hovered;
                    menuItemSelected = 1;
                    break;
                case "btnMenuDirecaoDoVento":
                    lblTitulo.Text = "Direção do vento";
                    lblValorDirecaoDoVento.Visible = true;
                    cmbUnidades.DataSource = new[] { "°" };
                    lblUnidade.Text = "°";
                    lblValorDePico.Text = "-";
                    _sender.BackgroundImage = Properties.Resources.biruta_hovered;
                    menuItemSelected = 2;
                    break;
                case "btnMenuPrecipitacao":
                    lblTitulo.Text = "Precipitação";
                    lblValorPrecipitacao.Visible = true;
                    cmbUnidades.DataSource = new[] { "mm", "m" };
                    lblUnidade.Text = "mm";
                    lblValorDePico.Text = $"{database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "Precipitacao").ToString(myFormat)} {lblUnidade.Text}";
                    _sender.BackgroundImage = Properties.Resources.rain_hovered;
                    menuItemSelected = 3;
                    break;
                case "btnMenuTemperatura":
                    lblTitulo.Text = "Temperatura";
                    lblValorTemperatura.Visible = true;
                    cmbUnidades.DataSource = new[] { "°C", "°F" };
                    lblUnidade.Text = "°C";
                    lblValorDePico.Text = $"{database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "Temperatura").ToString(myFormat)} {lblUnidade.Text}";
                    _sender.BackgroundImage = Properties.Resources.temperature_hovered;
                    menuItemSelected = 4;
                    break;
                case "btnMenuPressaoAtmosferica":
                    lblTitulo.Text = "Pressão Atmosférica";
                    lblValorPressaoAtmosferica.Visible = true;
                    cmbUnidades.DataSource = new[] { "hPa", "atm", "bar" };
                    lblUnidade.Text = "hPa";
                    lblValorDePico.Text = $"{database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "PressaoAtmosferica").ToString(myFormat)} {lblUnidade.Text}";
                    _sender.BackgroundImage = Properties.Resources.pressao_hovered;
                    menuItemSelected = 5;
                    break;
                case "btnMenuUmidade":
                    lblTitulo.Text = "Umidade do ar";
                    lblValorUmidade.Visible = true;
                    cmbUnidades.DataSource = new []{ "%" };
                    lblUnidade.Text = "%";
                    lblValorDePico.Text = $"{database.getPeakValueByDateRange<WeatherStationModel>(DateTime.Now.AddHours(-24), DateTime.Now, "Data", "Umidade").ToString(myFormat)} {lblUnidade.Text}";
                    _sender.BackgroundImage = Properties.Resources.drop_hovered;
                    menuItemSelected = 6;
                    break;
                default:
                    break;
            }
            previouslySelectedIndex = 0; // importante essa expressão estar depois do switch para que as queries sejam feitas de modo a se ter um valor disponível para manipular
            descriptions.SetToolTip(btnGerarGrafico, $"Gerar gráfico de {lblTitulo.Text}");
        }

        private void btnGerarGrafico_Click(object sender, EventArgs e)
        {
            switch (menuItemSelected)
            {
                case 1:
                    using (FormChart form = new FormChart(database, DateTime.Now.AddDays(-7), "VelocidadeDoVento"))
                    {
                        form.ShowDialog();
                    }
                    break;
                case 2:
                    using (FormChart form = new FormChart(database, DateTime.Now.AddDays(-7), "DirecaoDoVento"))
                    {
                        form.ShowDialog();
                    }
                    break;
                case 3:
                    using (FormChart form = new FormChart(database, DateTime.Now.AddDays(-7), "Precipitacao"))
                    {
                        form.ShowDialog();
                    }
                    break;
                case 4:
                    using (FormChart form = new FormChart(database, DateTime.Now.AddDays(-7), "Temperatura"))
                    {
                        form.ShowDialog();
                    }
                    break;
                case 5:
                    using (FormChart form = new FormChart(database, DateTime.Now.AddDays(-7), "PressaoAtmosferica"))
                    {
                        form.ShowDialog();
                    }
                    break;
                case 6:
                    using (FormChart form = new FormChart(database, DateTime.Now.AddDays(-7), "Umidade"))
                    {
                        form.ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }
        #region interação visual do botão de gráfico
        private void btnGerarGrafico_MouseEnter(object sender, EventArgs e)
        {
            btnGerarGrafico.BackgroundImage = Properties.Resources.chart_hovered;
        }

        private void btnGerarGrafico_MouseLeave(object sender, EventArgs e)
        {
            btnGerarGrafico.BackgroundImage = Properties.Resources.chart_default;
        }
        #endregion

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string portSelected = cmbPortas.SelectedItem.ToString();

            if (isConnected)
            {
                try
                {
                    espPort.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Erro de conexão!: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnConectar.Text = "Conectar";
                lblStatusConexao.Text = "Desconectado";
                lblStatusConexao.ForeColor = Color.FromArgb(255, 57, 62, 70);
                pbxStatusConexao.BackgroundImage = Properties.Resources.circle_default;

                setValueLabelsToDefault("empty");

                cmbPortas.Enabled = true;
                isConnected = false;
            }
            else
            {
                try
                {
                    espPort.PortName = portSelected;
                    espPort.BaudRate = 9600;
                    espPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro de conexão!: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnConectar.Text = "Desconectar";
                lblStatusConexao.Text = "Conectado";
                lblStatusConexao.ForeColor = Color.FromArgb(255, 41, 161, 156);
                pbxStatusConexao.BackgroundImage = Properties.Resources.circle_hovered;
                
                isConnected = true;
                cmbPortas.Enabled = false;
            }

        }

        private void btnAtualizarConexoes_Click(object sender, EventArgs e)
        {
            cmbPortas.DataSource = null;
            cmbPortas.DataSource = SerialPort.GetPortNames();
            cmbPortas.SelectedIndex = 0;
 
            if (espPort.IsOpen)
            {
                espPort.Close();

                btnConectar.Text = "Conectar";

                lblStatusConexao.Text = "Desconectado";
                lblStatusConexao.ForeColor = Color.FromArgb(255, 57, 62, 70);

                pbxStatusConexao.BackgroundImage = Properties.Resources.circle_default;
                
                setValueLabelsToDefault("empty");

                cmbPortas.Enabled = true;

                isConnected = false;
            }
        }
        private void btnAtualizarConexoes_MouseEnter(object sender, EventArgs e)
        {
            btnAtualizarConexoes.BackgroundImage = Properties.Resources.refresh_hovered;
        }
        private void btnAtualizarConexoes_MouseLeave(object sender, EventArgs e)
        {
            btnAtualizarConexoes.BackgroundImage = Properties.Resources.refresh_default;
        }

        private void cmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            double valorAtual;
            if(menuItemSelected != 2) 
            {
                if (previouslySelectedIndex != cmbUnidades.SelectedIndex) 
                {
                    string valorDePicoExtraido = lblValorDePico.Text.Split(' ')[0];
                    double valorDePicoAtual = double.Parse(valorDePicoExtraido, myFormat);
                    switch (menuItemSelected)
                    {
                        case 1: //Velocidade do vento
                            valorAtual = double.Parse(lblValorVelocidadeDoVento.Text, myFormat);
                            if (cmbUnidades.SelectedIndex == 0)
                            { // de m/s para Km/h
                                lblValorVelocidadeDoVento.Text = Math.Round(valorAtual * 3.6, 5).ToString(myFormat);
                                lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * 3.6, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                            }
                            else
                            { //de Km/h para m/s
                                lblValorVelocidadeDoVento.Text = Math.Round(valorAtual / 3.6, 5).ToString(myFormat);
                                lblValorDePico.Text = $"{Math.Round(valorDePicoAtual / 3.6, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                            }
                            break;
                        case 3: //Precipitacao
                            valorAtual = double.Parse(lblValorPrecipitacao.Text, myFormat);
                            if (cmbUnidades.SelectedIndex == 0)
                            { // de M para mm
                                lblValorPrecipitacao.Text = Math.Round(valorAtual * Math.Pow(10, 3), 5).ToString(myFormat);
                                lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * Math.Pow(10, 3), 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                            }
                            else
                            { //de mm para m
                                lblValorPrecipitacao.Text = Math.Round(valorAtual * Math.Pow(10, -3), 5).ToString(myFormat);
                                lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * Math.Pow(10, -3), 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                            }
                            break;
                        case 4: //Temperatura
                            valorAtual = double.Parse(lblValorTemperatura.Text, myFormat);
                            if (cmbUnidades.SelectedIndex == 0)
                            { //de °F para °C
                                lblValorTemperatura.Text = Math.Round((valorAtual - 32) * 5 / 9, 5).ToString(myFormat);
                                lblValorDePico.Text = $"{Math.Round((valorDePicoAtual - 32) * 5 / 9, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                            }
                            else
                            { //de °C para °F
                                lblValorTemperatura.Text = Math.Round(valorAtual * 1.8 + 32, 5).ToString(myFormat);
                                lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * 1.8 + 32, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                            }
                            break;
                        case 5: //Pressão Atmosférica
                            valorAtual = double.Parse(lblValorPressaoAtmosferica.Text, myFormat);
                            if (previouslySelectedIndex == 0) //de hPa para...
                            {
                                if (cmbUnidades.SelectedIndex == 1) //atm
                                {
                                    lblValorPressaoAtmosferica.Text = Math.Round(valorAtual * (9.87 * Math.Pow(10, -4)), 5).ToString(myFormat);
                                    lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * (9.87 * Math.Pow(10, -4)), 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                                }
                                else
                                if (cmbUnidades.SelectedIndex == 2) //bar
                                {
                                    lblValorPressaoAtmosferica.Text = Math.Round(valorAtual * Math.Pow(10, -3), 5).ToString(myFormat);
                                    lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * Math.Pow(10, -3), 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                                }
                            }
                            else
                            if (previouslySelectedIndex == 1) //de atm para...
                            {
                                if (cmbUnidades.SelectedIndex == 0) // hPa
                                {
                                    lblValorPressaoAtmosferica.Text = Math.Round(valorAtual * 1013.25, 5).ToString(myFormat);
                                    lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * 1013.25, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                                }
                                else
                                if (cmbUnidades.SelectedIndex == 2) //bar
                                {
                                    lblValorPressaoAtmosferica.Text = Math.Round(valorAtual * 1.01325, 5).ToString(myFormat);
                                    lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * 1.01325, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                                }
                            }
                            else
                            if (previouslySelectedIndex == 2) //de bar para...
                            {
                                if (cmbUnidades.SelectedIndex == 0) //hPa
                                {
                                    lblValorPressaoAtmosferica.Text = Math.Round(valorAtual * 1000, 5).ToString(myFormat);
                                    lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * 1000, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                                }
                                else
                                if (cmbUnidades.SelectedIndex == 1) //atm
                                {
                                    lblValorPressaoAtmosferica.Text = Math.Round(valorAtual * 0.987, 5).ToString(myFormat);
                                    lblValorDePico.Text = $"{Math.Round(valorDePicoAtual * 0.987, 5).ToString(myFormat)} { cmbUnidades.SelectedItem}";
                                }
                            }
                            break;
                        default: //Os casos Direção do vento e Umidade caem aqui pois esses parâmetros só possuem uma unidade, logo, o índice de seleção não muda
                            break;
                    }
                    previouslySelectedIndex = (byte)cmbUnidades.SelectedIndex;
                }
            }
            
        }
    }
    
}
