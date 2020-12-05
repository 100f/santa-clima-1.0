using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colors = System.Windows.Media.Color;

using LiveCharts.Wpf;
using LiveCharts.Helpers;


namespace SantaClima
{
    public partial class FormChart : Form
    {
        private DataAccess database;

        private ulong CURRENT_PAGE = 1;
        private ulong PAGE_QUANTITY = 1;
        private ulong pageNumberToJump = 1;
        private const byte POINT_QUANTITY = 20;
        private string TABLE_NAME = "Data";
        private string propName;

        private string seriesName = "";
        private string seriesUnit = "";

        private List<string> timestamps = new List<string>();
        private List<double> values = new List<double>();
        private List<WeatherStationModel> registersRetrieved = new List<WeatherStationModel>();

        private DateTime minimumDate;
        
        public FormChart(DataAccess _database, DateTime _minimumDate, string _propName)
        {
            InitializeComponent();
            database = _database;
            minimumDate = _minimumDate;
            propName = _propName;

            updateForm(1);
        }

        private void updateChart (ulong _pageNumber = 1)
        {
            dataChart.Series.Clear();
            dataChart.AxisX.Clear();
            dataChart.AxisY.Clear();
            timestamps.Clear();
            values.Clear();
            registersRetrieved.Clear();

            registersRetrieved = database.getRegistersByDate<WeatherStationModel>(TABLE_NAME, minimumDate, _pageNumber, POINT_QUANTITY);
           
            foreach (WeatherStationModel register in registersRetrieved)
            {
                timestamps.Add(register.DataDeCriacao.ToString());
                values.Add((double)register.GetType().GetProperty(propName).GetValue(register, null));
            }
            dataChart.Series.Add(
                new LineSeries()
                {
                    Title = seriesName,
                    Values = values.AsChartValues(),
                    Fill = new System.Windows.Media.SolidColorBrush(Colors.FromArgb(70, 41, 161, 156)),
                    Stroke = new System.Windows.Media.SolidColorBrush(Colors.FromRgb(41, 161, 156)),
                }
            ); 
            dataChart.AxisX.Add(new Axis
            {
                Labels = timestamps,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Stroke = new System.Windows.Media.SolidColorBrush(Colors.FromArgb(120, 57, 62, 70)),
                }
        });
            dataChart.AxisY.Add(new Axis
            {
                Title = $"{seriesName} [{seriesUnit}]",
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Stroke = new System.Windows.Media.SolidColorBrush(Colors.FromArgb(120, 57, 62, 70)),
                }
        });
        }

        #region sobrescrita de método para adicionar atalho de teclado (F5)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                updateForm(CURRENT_PAGE);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if(CURRENT_PAGE > 1)
            {
                CURRENT_PAGE--;
                updateChart(CURRENT_PAGE);
            }
            lblInfoPagina.Text = $"Página {CURRENT_PAGE} de {PAGE_QUANTITY}";
        }
        private void btnPaginaSeguinte_Click(object sender, EventArgs e)
        {
            if (CURRENT_PAGE < PAGE_QUANTITY)
            {
                CURRENT_PAGE++;
                updateChart(CURRENT_PAGE);
            }
            lblInfoPagina.Text = $"Página {CURRENT_PAGE} de {PAGE_QUANTITY}";
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox _sender = sender as PictureBox;
            switch (_sender.Name){
                case "btnFechar":
                    btnFechar.BackgroundImage = Properties.Resources.close_hovered;
                    break;
                case "btnPaginaAnterior":
                    btnPaginaAnterior.BackgroundImage = Properties.Resources.previous_hovered;
                    break;
                case "btnPaginaSeguinte":
                    btnPaginaSeguinte.BackgroundImage = Properties.Resources.next_hovered;
                    break;
                default:
                    break;
            }
        }
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox _sender = sender as PictureBox;
            switch (_sender.Name)
            {
                case "btnFechar":
                    btnFechar.BackgroundImage = Properties.Resources.close_default;
                    break;
                case "btnPaginaAnterior":
                    btnPaginaAnterior.BackgroundImage = Properties.Resources.previous_default;
                    break;
                case "btnPaginaSeguinte":
                    btnPaginaSeguinte.BackgroundImage = Properties.Resources.next_default;
                    break;
                default:
                    break;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void txtNumeroDaPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 127)
                e.KeyChar = e.KeyChar;
            else
                if (e.KeyChar == 27)
                    this.Focus();
            else
                if (e.KeyChar == 13)
                {
                    if(txtNumeroDaPagina.TextLength != 0)
                    {
                        pageNumberToJump = (ulong)Convert.ToDouble(txtNumeroDaPagina.Text);
                        if (pageNumberToJump >= 1 && pageNumberToJump <= PAGE_QUANTITY)
                        {
                            updateChart(pageNumberToJump);
                            lblInfoPagina.Text = $"Página {pageNumberToJump} de {PAGE_QUANTITY}";
                        }   
                        else
                        { 
                            MessageBox.Show("Número fora do intervalo de páginas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNumeroDaPagina.Clear();
                        }
                    }
                }
                else
                    e.KeyChar = Convert.ToChar(0);
        }

        private void updateForm(ulong _currentPage)
        {
            switch (propName)
            {
                case "DirecaoDoVento":
                    seriesName = "Direção do Vento";
                    seriesUnit = "°";
                    break;
                case "Precipitacao":
                    seriesName = "Precipitação";
                    seriesUnit = "mm";
                    break;
                case "VelocidadeDoVento":
                    seriesName = "Velocidade do Vento";
                    seriesUnit = "Km/h";
                    break;
                case "PressaoAtmosferica":
                    seriesName = "Pressão Atmosférica";
                    seriesUnit = "hPa";
                    break;
                case "Temperatura":
                    seriesName = "Temperatura";
                    seriesUnit = "°C";
                    break;
                case "Umidade":
                    seriesName = "Umidade";
                    seriesUnit = "%";
                    break;
                default:
                    break;
            }

            PAGE_QUANTITY = database.getPageCount<WeatherStationModel>("Data");

            lblNomeDoGrafico.Text = seriesName;
            lblInfoPagina.Text = $"Página {CURRENT_PAGE} de {PAGE_QUANTITY}";

            updateChart(_currentPage);
        }
    }
}
