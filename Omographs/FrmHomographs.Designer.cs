namespace Homographs
{
    partial class FrmHomographs
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
            if (disposing && (components != null)) {
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
            this.olvHomographs = new BrightIdeasSoftware.ObjectListView();
            this.olvClmHomograph = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvClmSocPol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvClmFiction = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.olvClmForm = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvHomographs)).BeginInit();
            this.SuspendLayout();
            // 
            // olvHomographs
            // 
            this.olvHomographs.AllColumns.Add(this.olvClmHomograph);
            this.olvHomographs.AllColumns.Add(this.olvClmForm);
            this.olvHomographs.AllColumns.Add(this.olvClmSocPol);
            this.olvHomographs.AllColumns.Add(this.olvClmFiction);
            this.olvHomographs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvHomographs.CellEditUseWholeCell = false;
            this.olvHomographs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvClmHomograph,
            this.olvClmForm,
            this.olvClmSocPol,
            this.olvClmFiction});
            this.olvHomographs.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvHomographs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvHomographs.Location = new System.Drawing.Point(-1, -1);
            this.olvHomographs.Name = "olvHomographs";
            this.olvHomographs.Size = new System.Drawing.Size(741, 455);
            this.olvHomographs.TabIndex = 18;
            this.olvHomographs.UseCompatibleStateImageBehavior = false;
            this.olvHomographs.View = System.Windows.Forms.View.Details;
            this.olvHomographs.SelectedIndexChanged += new System.EventHandler(this.olvHomographs_SelectedIndexChanged);
            // 
            // olvClmHomograph
            // 
            this.olvClmHomograph.AspectName = "Title";
            this.olvClmHomograph.Text = "Омограф";
            this.olvClmHomograph.Width = 174;
            // 
            // olvClmSocPol
            // 
            this.olvClmSocPol.AspectName = "GetNotes";
            this.olvClmSocPol.Text = "Примечание";
            // 
            // olvClmFiction
            // 
            this.olvClmFiction.AspectName = "GetTranslation";
            this.olvClmFiction.Text = "Основная словарная статья";
            this.olvClmFiction.Width = 1000;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(657, 460);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            // 
            // olvClmForm
            // 
            this.olvClmForm.AspectName = "GetType";
            this.olvClmForm.Text = "Тип";
            this.olvClmForm.Width = 120;
            // 
            // FrmHomographs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 490);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.olvHomographs);
            this.Name = "FrmHomographs";
            this.Text = "Омографы";
            this.Load += new System.EventHandler(this.FrmHomographs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvHomographs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvHomographs;
        private BrightIdeasSoftware.OLVColumn olvClmHomograph;
        private BrightIdeasSoftware.OLVColumn olvClmFiction;
        private BrightIdeasSoftware.OLVColumn olvClmSocPol;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.OLVColumn olvClmForm;
    }
}