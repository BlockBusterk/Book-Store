namespace BookShopManagement.Chat_UI
{
    partial class UC_ReceiverMetaData
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBoxView = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pictureBoxAvaSender = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbTimeString = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvaSender)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.pictureBoxView);
            this.guna2Panel1.Controls.Add(this.pictureBoxAvaSender);
            this.guna2Panel1.Controls.Add(this.lbTimeString);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(297, 243);
            this.guna2Panel1.TabIndex = 3;
            // 
            // pictureBoxView
            // 
            this.pictureBoxView.ImageRotate = 0F;
            this.pictureBoxView.Location = new System.Drawing.Point(63, 3);
            this.pictureBoxView.Name = "pictureBoxView";
            this.pictureBoxView.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxView.TabIndex = 12;
            this.pictureBoxView.TabStop = false;
            this.pictureBoxView.Click += new System.EventHandler(this.pictureBoxView_Click);
            // 
            // pictureBoxAvaSender
            // 
            this.pictureBoxAvaSender.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAvaSender.BorderRadius = 16;
            this.pictureBoxAvaSender.Image = global::BookShopManagement.Properties.Resources._8664831_user_icon;
            this.pictureBoxAvaSender.ImageRotate = 0F;
            this.pictureBoxAvaSender.Location = new System.Drawing.Point(17, 3);
            this.pictureBoxAvaSender.Name = "pictureBoxAvaSender";
            this.pictureBoxAvaSender.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.pictureBoxAvaSender.ShadowDecoration.Enabled = true;
            this.pictureBoxAvaSender.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBoxAvaSender.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxAvaSender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvaSender.TabIndex = 10;
            this.pictureBoxAvaSender.TabStop = false;
            // 
            // lbTimeString
            // 
            this.lbTimeString.AutoSize = true;
            this.lbTimeString.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeString.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeString.ForeColor = System.Drawing.Color.Gray;
            this.lbTimeString.Location = new System.Drawing.Point(193, 206);
            this.lbTimeString.Name = "lbTimeString";
            this.lbTimeString.Size = new System.Drawing.Size(70, 19);
            this.lbTimeString.TabIndex = 11;
            this.lbTimeString.Text = "12:30 AM";
            // 
            // UC_ReceiverMetaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_ReceiverMetaData";
            this.Size = new System.Drawing.Size(297, 243);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvaSender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxView;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxAvaSender;
        private System.Windows.Forms.Label lbTimeString;
    }
}
