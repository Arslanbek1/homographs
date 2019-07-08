namespace Homographs
{
    partial class frmMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtDict = new System.Windows.Forms.TextBox();
            this.txtSlovnik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prbMain = new System.Windows.Forms.ProgressBar();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(178, 64);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Найти Омографы";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtDict
            // 
            this.txtDict.Location = new System.Drawing.Point(97, 12);
            this.txtDict.Name = "txtDict";
            this.txtDict.ReadOnly = true;
            this.txtDict.Size = new System.Drawing.Size(200, 20);
            this.txtDict.TabIndex = 1;
            this.txtDict.Text = "FakeDict.txt";
            // 
            // txtSlovnik
            // 
            this.txtSlovnik.Location = new System.Drawing.Point(97, 38);
            this.txtSlovnik.Name = "txtSlovnik";
            this.txtSlovnik.ReadOnly = true;
            this.txtSlovnik.Size = new System.Drawing.Size(200, 20);
            this.txtSlovnik.TabIndex = 2;
            this.txtSlovnik.Text = "slovnik.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Файл Словаря";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Файл Словника";
            // 
            // prbMain
            // 
            this.prbMain.Location = new System.Drawing.Point(6, 96);
            this.prbMain.Name = "prbMain";
            this.prbMain.Size = new System.Drawing.Size(291, 23);
            this.prbMain.TabIndex = 5;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(97, 64);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Просмотр";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 127);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.prbMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSlovnik);
            this.Controls.Add(this.txtDict);
            this.Controls.Add(this.btnStart);
            this.Name = "frmMain";
            this.Text = "Омографы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtDict;
        private System.Windows.Forms.TextBox txtSlovnik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar prbMain;
        private System.Windows.Forms.Button btnShow;
    }
}

