namespace Kmeans
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDugumRastgele = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDugumRastgele = new System.Windows.Forms.TextBox();
            this.btnDugumSil = new System.Windows.Forms.Button();
            this.txtDugumY = new System.Windows.Forms.TextBox();
            this.txtDugumX = new System.Windows.Forms.TextBox();
            this.btnDugumEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnKumeRastgele = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKumeRastgele = new System.Windows.Forms.TextBox();
            this.btnKumeSil = new System.Windows.Forms.Button();
            this.btnKumeyeRenkSec = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKumeY = new System.Windows.Forms.TextBox();
            this.txtKumeX = new System.Windows.Forms.TextBox();
            this.btnKumeEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUygula = new System.Windows.Forms.Button();
            this.btnKoordinatlariAcKapa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.Maximum = 10D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 38);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Blue;
            series1.MarkerSize = 10;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Dugum";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(729, 558);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnDugumSil);
            this.groupBox1.Controls.Add(this.txtDugumY);
            this.groupBox1.Controls.Add(this.txtDugumX);
            this.groupBox1.Controls.Add(this.btnDugumEkle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(763, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DÜĞÜM EKLE";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDugumRastgele);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtDugumRastgele);
            this.groupBox3.Location = new System.Drawing.Point(27, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 58);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rastgele";
            // 
            // btnDugumRastgele
            // 
            this.btnDugumRastgele.Location = new System.Drawing.Point(199, 19);
            this.btnDugumRastgele.Name = "btnDugumRastgele";
            this.btnDugumRastgele.Size = new System.Drawing.Size(101, 33);
            this.btnDugumRastgele.TabIndex = 8;
            this.btnDugumRastgele.Text = "Rastgele Getir";
            this.btnDugumRastgele.UseVisualStyleBackColor = true;
            this.btnDugumRastgele.Click += new System.EventHandler(this.btnDugumRastgele_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tane Rastgele Getir";
            // 
            // txtDugumRastgele
            // 
            this.txtDugumRastgele.Location = new System.Drawing.Point(20, 26);
            this.txtDugumRastgele.Name = "txtDugumRastgele";
            this.txtDugumRastgele.Size = new System.Drawing.Size(45, 20);
            this.txtDugumRastgele.TabIndex = 7;
            // 
            // btnDugumSil
            // 
            this.btnDugumSil.Location = new System.Drawing.Point(298, 22);
            this.btnDugumSil.Name = "btnDugumSil";
            this.btnDugumSil.Size = new System.Drawing.Size(71, 59);
            this.btnDugumSil.TabIndex = 5;
            this.btnDugumSil.Text = "Son Düğümü Sil";
            this.btnDugumSil.UseVisualStyleBackColor = true;
            this.btnDugumSil.Click += new System.EventHandler(this.btnDugumSil_Click);
            // 
            // txtDugumY
            // 
            this.txtDugumY.Location = new System.Drawing.Point(81, 52);
            this.txtDugumY.Name = "txtDugumY";
            this.txtDugumY.Size = new System.Drawing.Size(100, 20);
            this.txtDugumY.TabIndex = 4;
            // 
            // txtDugumX
            // 
            this.txtDugumX.Location = new System.Drawing.Point(81, 28);
            this.txtDugumX.Name = "txtDugumX";
            this.txtDugumX.Size = new System.Drawing.Size(100, 20);
            this.txtDugumX.TabIndex = 3;
            // 
            // btnDugumEkle
            // 
            this.btnDugumEkle.Location = new System.Drawing.Point(212, 28);
            this.btnDugumEkle.Name = "btnDugumEkle";
            this.btnDugumEkle.Size = new System.Drawing.Size(50, 46);
            this.btnDugumEkle.TabIndex = 2;
            this.btnDugumEkle.Text = "Ekle";
            this.btnDugumEkle.UseVisualStyleBackColor = true;
            this.btnDugumEkle.Click += new System.EventHandler(this.btnDugumEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X = ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btnKumeSil);
            this.groupBox2.Controls.Add(this.btnKumeyeRenkSec);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtKumeY);
            this.groupBox2.Controls.Add(this.txtKumeX);
            this.groupBox2.Controls.Add(this.btnKumeEkle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(763, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 258);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KÜME EKLE";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnKumeRastgele);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtKumeRastgele);
            this.groupBox4.Location = new System.Drawing.Point(27, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 58);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rastgele";
            // 
            // btnKumeRastgele
            // 
            this.btnKumeRastgele.Location = new System.Drawing.Point(199, 19);
            this.btnKumeRastgele.Name = "btnKumeRastgele";
            this.btnKumeRastgele.Size = new System.Drawing.Size(101, 33);
            this.btnKumeRastgele.TabIndex = 8;
            this.btnKumeRastgele.Text = "Rastgele Getir";
            this.btnKumeRastgele.UseVisualStyleBackColor = true;
            this.btnKumeRastgele.Click += new System.EventHandler(this.btnKumeRastgele_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tane Rastgele Getir";
            // 
            // txtKumeRastgele
            // 
            this.txtKumeRastgele.Location = new System.Drawing.Point(20, 26);
            this.txtKumeRastgele.Name = "txtKumeRastgele";
            this.txtKumeRastgele.Size = new System.Drawing.Size(45, 20);
            this.txtKumeRastgele.TabIndex = 7;
            // 
            // btnKumeSil
            // 
            this.btnKumeSil.Location = new System.Drawing.Point(298, 58);
            this.btnKumeSil.Name = "btnKumeSil";
            this.btnKumeSil.Size = new System.Drawing.Size(71, 59);
            this.btnKumeSil.TabIndex = 6;
            this.btnKumeSil.Text = "Son Kümeyi Sil";
            this.btnKumeSil.UseVisualStyleBackColor = true;
            this.btnKumeSil.Click += new System.EventHandler(this.btnKumeSil_Click);
            // 
            // btnKumeyeRenkSec
            // 
            this.btnKumeyeRenkSec.Location = new System.Drawing.Point(127, 29);
            this.btnKumeyeRenkSec.Name = "btnKumeyeRenkSec";
            this.btnKumeyeRenkSec.Size = new System.Drawing.Size(100, 23);
            this.btnKumeyeRenkSec.TabIndex = 6;
            this.btnKumeyeRenkSec.Text = "Renk Seç";
            this.btnKumeyeRenkSec.UseVisualStyleBackColor = true;
            this.btnKumeyeRenkSec.Click += new System.EventHandler(this.btnKumeyeRenkSec_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Renk =";
            // 
            // txtKumeY
            // 
            this.txtKumeY.Location = new System.Drawing.Point(127, 101);
            this.txtKumeY.Name = "txtKumeY";
            this.txtKumeY.Size = new System.Drawing.Size(100, 20);
            this.txtKumeY.TabIndex = 4;
            // 
            // txtKumeX
            // 
            this.txtKumeX.Location = new System.Drawing.Point(127, 77);
            this.txtKumeX.Name = "txtKumeX";
            this.txtKumeX.Size = new System.Drawing.Size(100, 20);
            this.txtKumeX.TabIndex = 3;
            // 
            // btnKumeEkle
            // 
            this.btnKumeEkle.Location = new System.Drawing.Point(127, 136);
            this.btnKumeEkle.Name = "btnKumeEkle";
            this.btnKumeEkle.Size = new System.Drawing.Size(90, 27);
            this.btnKumeEkle.TabIndex = 2;
            this.btnKumeEkle.Text = "Ekle";
            this.btnKumeEkle.UseVisualStyleBackColor = true;
            this.btnKumeEkle.Click += new System.EventHandler(this.btnKumeEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "X = ";
            // 
            // btnUygula
            // 
            this.btnUygula.Location = new System.Drawing.Point(763, 515);
            this.btnUygula.Name = "btnUygula";
            this.btnUygula.Size = new System.Drawing.Size(375, 42);
            this.btnUygula.TabIndex = 6;
            this.btnUygula.Text = "K-Means Uygula";
            this.btnUygula.UseVisualStyleBackColor = true;
            this.btnUygula.Click += new System.EventHandler(this.btnUygula_Click);
            // 
            // btnKoordinatlariAcKapa
            // 
            this.btnKoordinatlariAcKapa.Location = new System.Drawing.Point(12, 602);
            this.btnKoordinatlariAcKapa.Name = "btnKoordinatlariAcKapa";
            this.btnKoordinatlariAcKapa.Size = new System.Drawing.Size(150, 35);
            this.btnKoordinatlariAcKapa.TabIndex = 7;
            this.btnKoordinatlariAcKapa.Tag = "acik";
            this.btnKoordinatlariAcKapa.Text = "Koordinatları Aç/Kapa";
            this.btnKoordinatlariAcKapa.UseVisualStyleBackColor = true;
            this.btnKoordinatlariAcKapa.Click += new System.EventHandler(this.btnKoordinatlariAcKapa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 649);
            this.Controls.Add(this.btnKoordinatlariAcKapa);
            this.Controls.Add(this.btnUygula);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDugumY;
        private System.Windows.Forms.TextBox txtDugumX;
        private System.Windows.Forms.Button btnDugumEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtKumeY;
        private System.Windows.Forms.TextBox txtKumeX;
        private System.Windows.Forms.Button btnKumeEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKumeyeRenkSec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDugumSil;
        private System.Windows.Forms.Button btnKumeSil;
        private System.Windows.Forms.Button btnUygula;
        private System.Windows.Forms.Button btnDugumRastgele;
        private System.Windows.Forms.TextBox txtDugumRastgele;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnKumeRastgele;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKumeRastgele;
        private System.Windows.Forms.Button btnKoordinatlariAcKapa;
    }
}

