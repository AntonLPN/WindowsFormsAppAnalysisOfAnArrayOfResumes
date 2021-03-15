
namespace WindowsFormsAppAnalysisOfAnArrayOfResumes
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonLoadOnlyOneSummary = new System.Windows.Forms.Button();
            this.buttonLoadSomeSummary = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonCandidatsFromOneCity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(407, 409);
            this.textBox1.TabIndex = 0;
            // 
            // buttonLoadOnlyOneSummary
            // 
            this.buttonLoadOnlyOneSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadOnlyOneSummary.Location = new System.Drawing.Point(426, 12);
            this.buttonLoadOnlyOneSummary.Name = "buttonLoadOnlyOneSummary";
            this.buttonLoadOnlyOneSummary.Size = new System.Drawing.Size(225, 43);
            this.buttonLoadOnlyOneSummary.TabIndex = 1;
            this.buttonLoadOnlyOneSummary.Text = "Load only One Summary";
            this.buttonLoadOnlyOneSummary.UseVisualStyleBackColor = true;
            this.buttonLoadOnlyOneSummary.Click += new System.EventHandler(this.buttonLoadOnlyOneSummary_Click);
            // 
            // buttonLoadSomeSummary
            // 
            this.buttonLoadSomeSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadSomeSummary.Location = new System.Drawing.Point(426, 61);
            this.buttonLoadSomeSummary.Name = "buttonLoadSomeSummary";
            this.buttonLoadSomeSummary.Size = new System.Drawing.Size(225, 43);
            this.buttonLoadSomeSummary.TabIndex = 2;
            this.buttonLoadSomeSummary.Text = "Load two or more summary";
            this.buttonLoadSomeSummary.UseVisualStyleBackColor = true;
            this.buttonLoadSomeSummary.Click += new System.EventHandler(this.buttonLoadSomeSummary_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReport.Location = new System.Drawing.Point(426, 110);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(225, 43);
            this.buttonReport.TabIndex = 3;
            this.buttonReport.Text = "Show Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonCandidatsFromOneCity
            // 
            this.buttonCandidatsFromOneCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCandidatsFromOneCity.Location = new System.Drawing.Point(426, 159);
            this.buttonCandidatsFromOneCity.Name = "buttonCandidatsFromOneCity";
            this.buttonCandidatsFromOneCity.Size = new System.Drawing.Size(225, 56);
            this.buttonCandidatsFromOneCity.TabIndex = 4;
            this.buttonCandidatsFromOneCity.Text = "Show Report Candidats from one city";
            this.buttonCandidatsFromOneCity.UseVisualStyleBackColor = true;
            this.buttonCandidatsFromOneCity.Click += new System.EventHandler(this.buttonCandidatsFromOneCity_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.buttonCandidatsFromOneCity);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonLoadSomeSummary);
            this.Controls.Add(this.buttonLoadOnlyOneSummary);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonLoadOnlyOneSummary;
        private System.Windows.Forms.Button buttonLoadSomeSummary;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonCandidatsFromOneCity;
    }
}

