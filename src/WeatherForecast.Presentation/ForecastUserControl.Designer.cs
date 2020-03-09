namespace WeatherForecast.Presentation
{
    partial class ForecastUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForecastUserControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWind = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecipitation = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblDateValue
            // 
            this.lblDateValue.Location = new System.Drawing.Point(68, 13);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(83, 15);
            this.lblDateValue.TabIndex = 2;
            this.lblDateValue.Text = "Date";
            this.lblDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // lblMin
            // 
            this.lblMin.Location = new System.Drawing.Point(157, 37);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(39, 15);
            this.lblMin.TabIndex = 5;
            this.lblMin.Text = "MIN";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(157, 13);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(78, 15);
            this.lblTemperature.TabIndex = 3;
            this.lblTemperature.Text = "Температура";
            // 
            // lblMax
            // 
            this.lblMax.Location = new System.Drawing.Point(202, 37);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(33, 15);
            this.lblMax.TabIndex = 7;
            this.lblMax.Text = "MAX";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ветер (м/с)";
            // 
            // lblWind
            // 
            this.lblWind.Location = new System.Drawing.Point(260, 33);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(69, 23);
            this.lblWind.TabIndex = 9;
            this.lblWind.Text = "WIND";
            this.lblWind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Осадки (мм)";
            // 
            // lblPrecipitation
            // 
            this.lblPrecipitation.Location = new System.Drawing.Point(335, 33);
            this.lblPrecipitation.Name = "lblPrecipitation";
            this.lblPrecipitation.Size = new System.Drawing.Size(76, 23);
            this.lblPrecipitation.TabIndex = 11;
            this.lblPrecipitation.Text = "PRECIP";
            this.lblPrecipitation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummary
            // 
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSummary.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSummary.Location = new System.Drawing.Point(416, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(263, 61);
            this.lblSummary.TabIndex = 12;
            this.lblSummary.Text = "SUMMARY";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForecastUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(680, 61);
            this.ControlBox = false;
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblPrecipitation);
            this.Controls.Add(this.lblWind);
            this.Controls.Add(this.lblDateValue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForecastUserControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ForecastUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrecipitation;
        private System.Windows.Forms.Label lblSummary;
    }
}