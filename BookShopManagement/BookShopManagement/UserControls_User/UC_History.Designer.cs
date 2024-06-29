namespace BookShopManagement.UserControls_User
{
    partial class UC_History
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_ReceiptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Detail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 100);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(406, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 37);
            this.label2.TabIndex = 33;
            this.label2.Text = "History";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 480);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ReceiptId,
            this.Column_TotalPrice,
            this.Column_Date,
            this.Column_Detail});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(985, 480);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClickAsync);
            // 
            // Column_ReceiptId
            // 
            this.Column_ReceiptId.HeaderText = "Receipt Id";
            this.Column_ReceiptId.MinimumWidth = 6;
            this.Column_ReceiptId.Name = "Column_ReceiptId";
            this.Column_ReceiptId.ReadOnly = true;
            // 
            // Column_TotalPrice
            // 
            this.Column_TotalPrice.HeaderText = "Total Price";
            this.Column_TotalPrice.MinimumWidth = 6;
            this.Column_TotalPrice.Name = "Column_TotalPrice";
            this.Column_TotalPrice.ReadOnly = true;
            // 
            // Column_Date
            // 
            this.Column_Date.HeaderText = "Date";
            this.Column_Date.MinimumWidth = 6;
            this.Column_Date.Name = "Column_Date";
            this.Column_Date.ReadOnly = true;
            // 
            // Column_Detail
            // 
            this.Column_Detail.HeaderText = "Detail of Receipt";
            this.Column_Detail.MinimumWidth = 6;
            this.Column_Detail.Name = "Column_Detail";
            this.Column_Detail.ReadOnly = true;
            this.Column_Detail.Text = "Show detail of the receipt";
            this.Column_Detail.UseColumnTextForButtonValue = true;
            // 
            // UC_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UC_History";
            this.Size = new System.Drawing.Size(985, 580);
            this.Load += new System.EventHandler(this.UC_History_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ReceiptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Date;
        private System.Windows.Forms.DataGridViewButtonColumn Column_Detail;
    }
}
