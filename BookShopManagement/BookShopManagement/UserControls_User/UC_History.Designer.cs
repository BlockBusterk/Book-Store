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
            this.Column_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Title,
            this.Column_Author,
            this.Column_Publisher,
            this.Column_Quantity,
            this.Column_TotalPrice,
            this.Column_Date});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(985, 480);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column_Title
            // 
            this.Column_Title.HeaderText = "Title";
            this.Column_Title.MinimumWidth = 6;
            this.Column_Title.Name = "Column_Title";
            // 
            // Column_Author
            // 
            this.Column_Author.HeaderText = "Author";
            this.Column_Author.MinimumWidth = 6;
            this.Column_Author.Name = "Column_Author";
            // 
            // Column_Publisher
            // 
            this.Column_Publisher.HeaderText = "Publisher";
            this.Column_Publisher.MinimumWidth = 6;
            this.Column_Publisher.Name = "Column_Publisher";
            // 
            // Column_Quantity
            // 
            this.Column_Quantity.HeaderText = "Quantity";
            this.Column_Quantity.MinimumWidth = 6;
            this.Column_Quantity.Name = "Column_Quantity";
            // 
            // Column_TotalPrice
            // 
            this.Column_TotalPrice.HeaderText = "Total Price";
            this.Column_TotalPrice.MinimumWidth = 6;
            this.Column_TotalPrice.Name = "Column_TotalPrice";
            // 
            // Column_Date
            // 
            this.Column_Date.HeaderText = "Date";
            this.Column_Date.MinimumWidth = 6;
            this.Column_Date.Name = "Column_Date";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTotalPages);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.lblCurrentPage);
            this.panel3.Controls.Add(this.btnPreviousPage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 525);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(985, 55);
            this.panel3.TabIndex = 2;
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(487, 16);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(23, 25);
            this.lblTotalPages.TabIndex = 5;
            this.lblTotalPages.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(598, 10);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(54, 36);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(429, 16);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(23, 25);
            this.lblCurrentPage.TabIndex = 2;
            this.lblCurrentPage.Text = "1";
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(283, 10);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(54, 36);
            this.btnPreviousPage.TabIndex = 0;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // UC_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Date;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label label1;
    }
}
