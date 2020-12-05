namespace SantaClima
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.espPort = new System.IO.Ports.SerialPort(this.components);
            this.pnlDados = new System.Windows.Forms.Panel();
            this.cmbUnidades = new System.Windows.Forms.ComboBox();
            this.lblValorUmidade = new System.Windows.Forms.Label();
            this.lblValorDePico = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValorPressaoAtmosferica = new System.Windows.Forms.Label();
            this.lblValorTemperatura = new System.Windows.Forms.Label();
            this.lblValorPrecipitacao = new System.Windows.Forms.Label();
            this.lblValorVelocidadeDoVento = new System.Windows.Forms.Label();
            this.lblValorDirecaoDoVento = new System.Windows.Forms.Label();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.lblValorLuminosidade = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlConexao = new System.Windows.Forms.Panel();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPortas = new System.Windows.Forms.ComboBox();
            this.lblMensagemInicial = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.btnMenuUmidade = new System.Windows.Forms.PictureBox();
            this.btnAtualizarConexoes = new System.Windows.Forms.PictureBox();
            this.pbxStatusConexao = new System.Windows.Forms.PictureBox();
            this.lblStatusConexao = new System.Windows.Forms.Label();
            this.btnGerarGrafico = new System.Windows.Forms.PictureBox();
            this.btnFecharAplicacao = new System.Windows.Forms.PictureBox();
            this.btnMenuPressaoAtmosferica = new System.Windows.Forms.PictureBox();
            this.btnMenuTemperatura = new System.Windows.Forms.PictureBox();
            this.btnMenuPrecipitacao = new System.Windows.Forms.PictureBox();
            this.btnMenuVelocidadeDoVento = new System.Windows.Forms.PictureBox();
            this.btnMenuDirecaoDoVento = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDados.SuspendLayout();
            this.pnlConexao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuUmidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizarConexoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatusConexao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGerarGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharAplicacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuPressaoAtmosferica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuPrecipitacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuVelocidadeDoVento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuDirecaoDoVento)).BeginInit();
            this.SuspendLayout();
            // 
            // espPort
            // 
            this.espPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.EspPort_DataReceived);
            // 
            // pnlDados
            // 
            this.pnlDados.BackColor = System.Drawing.Color.Transparent;
            this.pnlDados.Controls.Add(this.cmbUnidades);
            this.pnlDados.Controls.Add(this.lblValorUmidade);
            this.pnlDados.Controls.Add(this.lblValorDePico);
            this.pnlDados.Controls.Add(this.label3);
            this.pnlDados.Controls.Add(this.btnGerarGrafico);
            this.pnlDados.Controls.Add(this.lblValorPressaoAtmosferica);
            this.pnlDados.Controls.Add(this.lblValorTemperatura);
            this.pnlDados.Controls.Add(this.lblValorPrecipitacao);
            this.pnlDados.Controls.Add(this.lblValorVelocidadeDoVento);
            this.pnlDados.Controls.Add(this.lblValorDirecaoDoVento);
            this.pnlDados.Controls.Add(this.lblUnidade);
            this.pnlDados.Controls.Add(this.lblValorLuminosidade);
            this.pnlDados.Controls.Add(this.label2);
            this.pnlDados.Controls.Add(this.label1);
            this.pnlDados.Controls.Add(this.lblTitulo);
            this.pnlDados.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDados.Location = new System.Drawing.Point(161, 93);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(481, 335);
            this.pnlDados.TabIndex = 8;
            // 
            // cmbUnidades
            // 
            this.cmbUnidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.cmbUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidades.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnidades.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.cmbUnidades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(164)))));
            this.cmbUnidades.FormattingEnabled = true;
            this.cmbUnidades.ItemHeight = 32;
            this.cmbUnidades.Location = new System.Drawing.Point(151, 100);
            this.cmbUnidades.Name = "cmbUnidades";
            this.cmbUnidades.Size = new System.Drawing.Size(99, 40);
            this.cmbUnidades.TabIndex = 14;
            this.cmbUnidades.SelectedIndexChanged += new System.EventHandler(this.cmbUnidades_SelectedIndexChanged);
            this.cmbUnidades.MouseEnter += new System.EventHandler(this.CmbUnidades_MouseEnter);
            this.cmbUnidades.MouseLeave += new System.EventHandler(this.CmbUnidades_MouseLeave);
            // 
            // lblValorUmidade
            // 
            this.lblValorUmidade.AutoSize = true;
            this.lblValorUmidade.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorUmidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(164)))));
            this.lblValorUmidade.Location = new System.Drawing.Point(16, 103);
            this.lblValorUmidade.Name = "lblValorUmidade";
            this.lblValorUmidade.Size = new System.Drawing.Size(24, 32);
            this.lblValorUmidade.TabIndex = 13;
            this.lblValorUmidade.Text = "-";
            // 
            // lblValorDePico
            // 
            this.lblValorDePico.AutoSize = true;
            this.lblValorDePico.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorDePico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(164)))));
            this.lblValorDePico.Location = new System.Drawing.Point(18, 206);
            this.lblValorDePico.Name = "lblValorDePico";
            this.lblValorDePico.Size = new System.Drawing.Size(24, 32);
            this.lblValorDePico.TabIndex = 12;
            this.lblValorDePico.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.label3.Location = new System.Drawing.Point(19, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Valor de Pico (Últimas 24 hrs)";
            // 
            // lblValorPressaoAtmosferica
            // 
            this.lblValorPressaoAtmosferica.AutoSize = true;
            this.lblValorPressaoAtmosferica.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorPressaoAtmosferica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblValorPressaoAtmosferica.Location = new System.Drawing.Point(16, 103);
            this.lblValorPressaoAtmosferica.Name = "lblValorPressaoAtmosferica";
            this.lblValorPressaoAtmosferica.Size = new System.Drawing.Size(24, 32);
            this.lblValorPressaoAtmosferica.TabIndex = 9;
            this.lblValorPressaoAtmosferica.Text = "-";
            // 
            // lblValorTemperatura
            // 
            this.lblValorTemperatura.AutoSize = true;
            this.lblValorTemperatura.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorTemperatura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblValorTemperatura.Location = new System.Drawing.Point(16, 103);
            this.lblValorTemperatura.Name = "lblValorTemperatura";
            this.lblValorTemperatura.Size = new System.Drawing.Size(24, 32);
            this.lblValorTemperatura.TabIndex = 8;
            this.lblValorTemperatura.Text = "-";
            // 
            // lblValorPrecipitacao
            // 
            this.lblValorPrecipitacao.AutoSize = true;
            this.lblValorPrecipitacao.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorPrecipitacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblValorPrecipitacao.Location = new System.Drawing.Point(16, 103);
            this.lblValorPrecipitacao.Name = "lblValorPrecipitacao";
            this.lblValorPrecipitacao.Size = new System.Drawing.Size(24, 32);
            this.lblValorPrecipitacao.TabIndex = 7;
            this.lblValorPrecipitacao.Text = "-";
            // 
            // lblValorVelocidadeDoVento
            // 
            this.lblValorVelocidadeDoVento.AutoSize = true;
            this.lblValorVelocidadeDoVento.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorVelocidadeDoVento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblValorVelocidadeDoVento.Location = new System.Drawing.Point(16, 103);
            this.lblValorVelocidadeDoVento.Name = "lblValorVelocidadeDoVento";
            this.lblValorVelocidadeDoVento.Size = new System.Drawing.Size(24, 32);
            this.lblValorVelocidadeDoVento.TabIndex = 6;
            this.lblValorVelocidadeDoVento.Text = "-";
            // 
            // lblValorDirecaoDoVento
            // 
            this.lblValorDirecaoDoVento.AutoSize = true;
            this.lblValorDirecaoDoVento.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorDirecaoDoVento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblValorDirecaoDoVento.Location = new System.Drawing.Point(16, 103);
            this.lblValorDirecaoDoVento.Name = "lblValorDirecaoDoVento";
            this.lblValorDirecaoDoVento.Size = new System.Drawing.Size(24, 32);
            this.lblValorDirecaoDoVento.TabIndex = 5;
            this.lblValorDirecaoDoVento.Text = "-";
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblUnidade.Location = new System.Drawing.Point(145, 103);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(24, 32);
            this.lblUnidade.TabIndex = 4;
            this.lblUnidade.Text = "-";
            // 
            // lblValorLuminosidade
            // 
            this.lblValorLuminosidade.AutoSize = true;
            this.lblValorLuminosidade.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorLuminosidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblValorLuminosidade.Location = new System.Drawing.Point(16, 103);
            this.lblValorLuminosidade.Name = "lblValorLuminosidade";
            this.lblValorLuminosidade.Size = new System.Drawing.Size(24, 32);
            this.lblValorLuminosidade.TabIndex = 3;
            this.lblValorLuminosidade.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.label2.Location = new System.Drawing.Point(148, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.label1.Location = new System.Drawing.Point(16, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor Atual";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(164)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(30, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "-";
            // 
            // pnlConexao
            // 
            this.pnlConexao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.pnlConexao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConexao.Controls.Add(this.btnAtualizarConexoes);
            this.pnlConexao.Controls.Add(this.btnConectar);
            this.pnlConexao.Controls.Add(this.pbxStatusConexao);
            this.pnlConexao.Controls.Add(this.lblStatusConexao);
            this.pnlConexao.Controls.Add(this.label5);
            this.pnlConexao.Controls.Add(this.label4);
            this.pnlConexao.Controls.Add(this.cmbPortas);
            this.pnlConexao.ForeColor = System.Drawing.Color.Black;
            this.pnlConexao.Location = new System.Drawing.Point(229, 440);
            this.pnlConexao.Name = "pnlConexao";
            this.pnlConexao.Size = new System.Drawing.Size(289, 88);
            this.pnlConexao.TabIndex = 9;
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.LightGray;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btnConectar.Location = new System.Drawing.Point(201, 9);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(69, 68);
            this.btnConectar.TabIndex = 5;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.label5.Location = new System.Drawing.Point(14, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Porta:";
            // 
            // cmbPortas
            // 
            this.cmbPortas.BackColor = System.Drawing.Color.LightGray;
            this.cmbPortas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPortas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPortas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.cmbPortas.Location = new System.Drawing.Point(72, 15);
            this.cmbPortas.Name = "cmbPortas";
            this.cmbPortas.Size = new System.Drawing.Size(74, 23);
            this.cmbPortas.TabIndex = 0;
            // 
            // lblMensagemInicial
            // 
            this.lblMensagemInicial.AutoSize = true;
            this.lblMensagemInicial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(164)))));
            this.lblMensagemInicial.Location = new System.Drawing.Point(149, 26);
            this.lblMensagemInicial.Name = "lblMensagemInicial";
            this.lblMensagemInicial.Size = new System.Drawing.Size(394, 28);
            this.lblMensagemInicial.TabIndex = 10;
            this.lblMensagemInicial.Text = "Bem vindo(a). Faça a conexão com a estação clicando no botão abaixo. \r\nApós isso," +
    " para acessar parâmetros da estação, clique nos botões à esquerda.\r\n";
            this.lblMensagemInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensagemInicial.Visible = false;
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::SantaClima.Properties.Resources.logo;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.Cursor = System.Windows.Forms.Cursors.Default;
            this.logo.Location = new System.Drawing.Point(25, 10);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(167, 77);
            this.logo.TabIndex = 12;
            this.logo.TabStop = false;
            // 
            // btnMenuUmidade
            // 
            this.btnMenuUmidade.BackgroundImage = global::SantaClima.Properties.Resources.drop_default;
            this.btnMenuUmidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenuUmidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuUmidade.InitialImage = null;
            this.btnMenuUmidade.Location = new System.Drawing.Point(25, 381);
            this.btnMenuUmidade.Name = "btnMenuUmidade";
            this.btnMenuUmidade.Size = new System.Drawing.Size(50, 50);
            this.btnMenuUmidade.TabIndex = 11;
            this.btnMenuUmidade.TabStop = false;
            this.btnMenuUmidade.Click += new System.EventHandler(this.MenuItem_Click);
            this.btnMenuUmidade.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnMenuUmidade.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // btnAtualizarConexoes
            // 
            this.btnAtualizarConexoes.BackgroundImage = global::SantaClima.Properties.Resources.refresh_default;
            this.btnAtualizarConexoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtualizarConexoes.Location = new System.Drawing.Point(161, 15);
            this.btnAtualizarConexoes.Name = "btnAtualizarConexoes";
            this.btnAtualizarConexoes.Size = new System.Drawing.Size(23, 23);
            this.btnAtualizarConexoes.TabIndex = 6;
            this.btnAtualizarConexoes.TabStop = false;
            this.btnAtualizarConexoes.Click += new System.EventHandler(this.btnAtualizarConexoes_Click);
            this.btnAtualizarConexoes.MouseEnter += new System.EventHandler(this.btnAtualizarConexoes_MouseEnter);
            this.btnAtualizarConexoes.MouseLeave += new System.EventHandler(this.btnAtualizarConexoes_MouseLeave);
            // 
            // pbxStatusConexao
            // 
            this.pbxStatusConexao.BackgroundImage = global::SantaClima.Properties.Resources.circle_default;
            this.pbxStatusConexao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxStatusConexao.Location = new System.Drawing.Point(72, 56);
            this.pbxStatusConexao.Name = "pbxStatusConexao";
            this.pbxStatusConexao.Size = new System.Drawing.Size(10, 10);
            this.pbxStatusConexao.TabIndex = 4;
            this.pbxStatusConexao.TabStop = false;
            // 
            // lblStatusConexao
            // 
            this.lblStatusConexao.AutoSize = true;
            this.lblStatusConexao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.lblStatusConexao.Image = global::SantaClima.Properties.Resources.biruta_default;
            this.lblStatusConexao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusConexao.Location = new System.Drawing.Point(87, 54);
            this.lblStatusConexao.Name = "lblStatusConexao";
            this.lblStatusConexao.Size = new System.Drawing.Size(77, 13);
            this.lblStatusConexao.TabIndex = 3;
            this.lblStatusConexao.Text = "Desconectado";
            this.lblStatusConexao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGerarGrafico
            // 
            this.btnGerarGrafico.BackgroundImage = global::SantaClima.Properties.Resources.chart_default;
            this.btnGerarGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGerarGrafico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarGrafico.Location = new System.Drawing.Point(431, 20);
            this.btnGerarGrafico.Name = "btnGerarGrafico";
            this.btnGerarGrafico.Size = new System.Drawing.Size(30, 30);
            this.btnGerarGrafico.TabIndex = 10;
            this.btnGerarGrafico.TabStop = false;
            this.btnGerarGrafico.Click += new System.EventHandler(this.btnGerarGrafico_Click);
            this.btnGerarGrafico.MouseEnter += new System.EventHandler(this.btnGerarGrafico_MouseEnter);
            this.btnGerarGrafico.MouseLeave += new System.EventHandler(this.btnGerarGrafico_MouseLeave);
            // 
            // btnFecharAplicacao
            // 
            this.btnFecharAplicacao.BackgroundImage = global::SantaClima.Properties.Resources.close_default;
            this.btnFecharAplicacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFecharAplicacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharAplicacao.InitialImage = global::SantaClima.Properties.Resources.close_default;
            this.btnFecharAplicacao.Location = new System.Drawing.Point(668, 21);
            this.btnFecharAplicacao.Name = "btnFecharAplicacao";
            this.btnFecharAplicacao.Size = new System.Drawing.Size(30, 30);
            this.btnFecharAplicacao.TabIndex = 7;
            this.btnFecharAplicacao.TabStop = false;
            this.btnFecharAplicacao.Click += new System.EventHandler(this.BtnFecharAplicacao_Click);
            this.btnFecharAplicacao.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnFecharAplicacao.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // btnMenuPressaoAtmosferica
            // 
            this.btnMenuPressaoAtmosferica.BackgroundImage = global::SantaClima.Properties.Resources.pressao_default;
            this.btnMenuPressaoAtmosferica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenuPressaoAtmosferica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPressaoAtmosferica.InitialImage = null;
            this.btnMenuPressaoAtmosferica.Location = new System.Drawing.Point(25, 322);
            this.btnMenuPressaoAtmosferica.Name = "btnMenuPressaoAtmosferica";
            this.btnMenuPressaoAtmosferica.Size = new System.Drawing.Size(50, 50);
            this.btnMenuPressaoAtmosferica.TabIndex = 6;
            this.btnMenuPressaoAtmosferica.TabStop = false;
            this.btnMenuPressaoAtmosferica.Click += new System.EventHandler(this.MenuItem_Click);
            this.btnMenuPressaoAtmosferica.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnMenuPressaoAtmosferica.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // btnMenuTemperatura
            // 
            this.btnMenuTemperatura.BackgroundImage = global::SantaClima.Properties.Resources.temperature_default;
            this.btnMenuTemperatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenuTemperatura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuTemperatura.InitialImage = null;
            this.btnMenuTemperatura.Location = new System.Drawing.Point(25, 264);
            this.btnMenuTemperatura.Name = "btnMenuTemperatura";
            this.btnMenuTemperatura.Size = new System.Drawing.Size(50, 50);
            this.btnMenuTemperatura.TabIndex = 5;
            this.btnMenuTemperatura.TabStop = false;
            this.btnMenuTemperatura.Click += new System.EventHandler(this.MenuItem_Click);
            this.btnMenuTemperatura.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnMenuTemperatura.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // btnMenuPrecipitacao
            // 
            this.btnMenuPrecipitacao.BackgroundImage = global::SantaClima.Properties.Resources.rain_default;
            this.btnMenuPrecipitacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenuPrecipitacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPrecipitacao.InitialImage = null;
            this.btnMenuPrecipitacao.Location = new System.Drawing.Point(25, 207);
            this.btnMenuPrecipitacao.Name = "btnMenuPrecipitacao";
            this.btnMenuPrecipitacao.Size = new System.Drawing.Size(50, 50);
            this.btnMenuPrecipitacao.TabIndex = 4;
            this.btnMenuPrecipitacao.TabStop = false;
            this.btnMenuPrecipitacao.Click += new System.EventHandler(this.MenuItem_Click);
            this.btnMenuPrecipitacao.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnMenuPrecipitacao.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // btnMenuVelocidadeDoVento
            // 
            this.btnMenuVelocidadeDoVento.BackgroundImage = global::SantaClima.Properties.Resources.wind_speed_default;
            this.btnMenuVelocidadeDoVento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenuVelocidadeDoVento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuVelocidadeDoVento.InitialImage = null;
            this.btnMenuVelocidadeDoVento.Location = new System.Drawing.Point(25, 93);
            this.btnMenuVelocidadeDoVento.Name = "btnMenuVelocidadeDoVento";
            this.btnMenuVelocidadeDoVento.Size = new System.Drawing.Size(50, 50);
            this.btnMenuVelocidadeDoVento.TabIndex = 3;
            this.btnMenuVelocidadeDoVento.TabStop = false;
            this.btnMenuVelocidadeDoVento.Click += new System.EventHandler(this.MenuItem_Click);
            this.btnMenuVelocidadeDoVento.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnMenuVelocidadeDoVento.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // btnMenuDirecaoDoVento
            // 
            this.btnMenuDirecaoDoVento.BackgroundImage = global::SantaClima.Properties.Resources.biruta_default;
            this.btnMenuDirecaoDoVento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenuDirecaoDoVento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuDirecaoDoVento.InitialImage = null;
            this.btnMenuDirecaoDoVento.Location = new System.Drawing.Point(25, 150);
            this.btnMenuDirecaoDoVento.Name = "btnMenuDirecaoDoVento";
            this.btnMenuDirecaoDoVento.Size = new System.Drawing.Size(50, 50);
            this.btnMenuDirecaoDoVento.TabIndex = 2;
            this.btnMenuDirecaoDoVento.TabStop = false;
            this.btnMenuDirecaoDoVento.Click += new System.EventHandler(this.MenuItem_Click);
            this.btnMenuDirecaoDoVento.MouseEnter += new System.EventHandler(this.MenuItem_MouseEnter);
            this.btnMenuDirecaoDoVento.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SantaClima.Properties.Resources.coloured_strip;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 10);
            this.panel1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(725, 548);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.btnMenuUmidade);
            this.Controls.Add(this.pnlConexao);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.btnFecharAplicacao);
            this.Controls.Add(this.btnMenuPressaoAtmosferica);
            this.Controls.Add(this.btnMenuTemperatura);
            this.Controls.Add(this.btnMenuPrecipitacao);
            this.Controls.Add(this.btnMenuVelocidadeDoVento);
            this.Controls.Add(this.btnMenuDirecaoDoVento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMensagemInicial);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estação Meteorológica";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseEnter += new System.EventHandler(this.btnAtualizarConexoes_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.btnAtualizarConexoes_MouseLeave);
            this.pnlDados.ResumeLayout(false);
            this.pnlDados.PerformLayout();
            this.pnlConexao.ResumeLayout(false);
            this.pnlConexao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuUmidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizarConexoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatusConexao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGerarGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharAplicacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuPressaoAtmosferica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuPrecipitacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuVelocidadeDoVento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuDirecaoDoVento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.IO.Ports.SerialPort espPort;
        private System.Windows.Forms.PictureBox btnMenuDirecaoDoVento;
        private System.Windows.Forms.PictureBox btnMenuVelocidadeDoVento;
        private System.Windows.Forms.PictureBox btnMenuPrecipitacao;
        private System.Windows.Forms.PictureBox btnMenuTemperatura;
        private System.Windows.Forms.PictureBox btnMenuPressaoAtmosferica;
        private System.Windows.Forms.PictureBox btnFecharAplicacao;
        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.Label lblValorLuminosidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValorPressaoAtmosferica;
        private System.Windows.Forms.Label lblValorTemperatura;
        private System.Windows.Forms.Label lblValorPrecipitacao;
        private System.Windows.Forms.Label lblValorVelocidadeDoVento;
        private System.Windows.Forms.Label lblValorDirecaoDoVento;
        private System.Windows.Forms.PictureBox btnGerarGrafico;
        private System.Windows.Forms.Label lblValorDePico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlConexao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPortas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatusConexao;
        private System.Windows.Forms.PictureBox pbxStatusConexao;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblMensagemInicial;
        private System.Windows.Forms.Label lblValorUmidade;
        private System.Windows.Forms.PictureBox btnMenuUmidade;
        private System.Windows.Forms.PictureBox btnAtualizarConexoes;
        private System.Windows.Forms.ComboBox cmbUnidades;
        private System.Windows.Forms.PictureBox logo;
    }
}

