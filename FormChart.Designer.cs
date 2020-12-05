namespace SantaClima
{
    partial class FormChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataChart = new LiveCharts.WinForms.CartesianChart();
            this.lblNomeDoGrafico = new System.Windows.Forms.Label();
            this.btnPaginaSeguinte = new System.Windows.Forms.PictureBox();
            this.btnPaginaAnterior = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfoPagina = new System.Windows.Forms.Label();
            this.txtNumeroDaPagina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaSeguinte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataChart
            // 
            this.dataChart.BackColorTransparent = true;
            this.dataChart.Location = new System.Drawing.Point(38, 181);
            this.dataChart.Name = "dataChart";
            this.dataChart.Size = new System.Drawing.Size(665, 353);
            this.dataChart.TabIndex = 0;
            // 
            // lblNomeDoGrafico
            // 
            this.lblNomeDoGrafico.AutoSize = true;
            this.lblNomeDoGrafico.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeDoGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.lblNomeDoGrafico.Location = new System.Drawing.Point(31, 35);
            this.lblNomeDoGrafico.Name = "lblNomeDoGrafico";
            this.lblNomeDoGrafico.Size = new System.Drawing.Size(190, 41);
            this.lblNomeDoGrafico.TabIndex = 4;
            this.lblNomeDoGrafico.Text = "Parâmetro";
            // 
            // btnPaginaSeguinte
            // 
            this.btnPaginaSeguinte.BackgroundImage = global::SantaClima.Properties.Resources.next_default;
            this.btnPaginaSeguinte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPaginaSeguinte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSeguinte.Location = new System.Drawing.Point(85, 122);
            this.btnPaginaSeguinte.Name = "btnPaginaSeguinte";
            this.btnPaginaSeguinte.Size = new System.Drawing.Size(30, 30);
            this.btnPaginaSeguinte.TabIndex = 10;
            this.btnPaginaSeguinte.TabStop = false;
            this.btnPaginaSeguinte.Click += new System.EventHandler(this.btnPaginaSeguinte_Click);
            this.btnPaginaSeguinte.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.btnPaginaSeguinte.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.BackgroundImage = global::SantaClima.Properties.Resources.previous_default;
            this.btnPaginaAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPaginaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnterior.Location = new System.Drawing.Point(38, 122);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(30, 30);
            this.btnPaginaAnterior.TabIndex = 9;
            this.btnPaginaAnterior.TabStop = false;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            this.btnPaginaAnterior.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.btnPaginaAnterior.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::SantaClima.Properties.Resources.close_default;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.InitialImage = global::SantaClima.Properties.Resources.close_default;
            this.btnFechar.Location = new System.Drawing.Point(673, 26);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 30);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            this.btnFechar.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.btnFechar.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SantaClima.Properties.Resources.coloured_strip;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, -21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 27);
            this.panel1.TabIndex = 1;
            // 
            // lblInfoPagina
            // 
            this.lblInfoPagina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPagina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(161)))), ((int)(((byte)(156)))));
            this.lblInfoPagina.Location = new System.Drawing.Point(417, 136);
            this.lblInfoPagina.Name = "lblInfoPagina";
            this.lblInfoPagina.Size = new System.Drawing.Size(286, 16);
            this.lblInfoPagina.TabIndex = 11;
            this.lblInfoPagina.Text = "Info Página";
            this.lblInfoPagina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDaPagina
            // 
            this.txtNumeroDaPagina.AcceptsReturn = true;
            this.txtNumeroDaPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.txtNumeroDaPagina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDaPagina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDaPagina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.txtNumeroDaPagina.Location = new System.Drawing.Point(150, 88);
            this.txtNumeroDaPagina.Name = "txtNumeroDaPagina";
            this.txtNumeroDaPagina.Size = new System.Drawing.Size(55, 22);
            this.txtNumeroDaPagina.TabIndex = 12;
            this.txtNumeroDaPagina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDaPagina_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(35, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pular para página:";
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(729, 545);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumeroDaPagina);
            this.Controls.Add(this.lblInfoPagina);
            this.Controls.Add(this.btnPaginaSeguinte);
            this.Controls.Add(this.btnPaginaAnterior);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.lblNomeDoGrafico);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChart";
            this.ShowIcon = false;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaSeguinte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart dataChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNomeDoGrafico;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.PictureBox btnPaginaAnterior;
        private System.Windows.Forms.PictureBox btnPaginaSeguinte;
        private System.Windows.Forms.Label lblInfoPagina;
        private System.Windows.Forms.TextBox txtNumeroDaPagina;
        private System.Windows.Forms.Label label1;
    }
}