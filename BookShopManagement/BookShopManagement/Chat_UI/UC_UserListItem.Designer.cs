namespace BookShopManagement.Chat_UI
{
    partial class UC_UserListItem
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
            this.itemPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lbNumberMessage = new Guna.UI2.WinForms.Guna2Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbLastMessage = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.itemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.lbNumberMessage);
            this.itemPanel.Controls.Add(this.lbTime);
            this.itemPanel.Controls.Add(this.lbLastMessage);
            this.itemPanel.Controls.Add(this.lbName);
            this.itemPanel.Controls.Add(this.pictureBoxAvatar);
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel.FillColor = System.Drawing.Color.Purple;
            this.itemPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.itemPanel.Location = new System.Drawing.Point(0, 0);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.itemPanel.ShadowDecoration.Enabled = true;
            this.itemPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 7);
            this.itemPanel.Size = new System.Drawing.Size(258, 86);
            this.itemPanel.TabIndex = 2;
            this.itemPanel.Click += new System.EventHandler(this.itemPanel_Click);
            // 
            // lbNumberMessage
            // 
            this.lbNumberMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbNumberMessage.BorderRadius = 8;
            this.lbNumberMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lbNumberMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lbNumberMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lbNumberMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lbNumberMessage.FillColor = System.Drawing.Color.Magenta;
            this.lbNumberMessage.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberMessage.ForeColor = System.Drawing.Color.White;
            this.lbNumberMessage.Location = new System.Drawing.Point(207, 32);
            this.lbNumberMessage.Name = "lbNumberMessage";
            this.lbNumberMessage.Size = new System.Drawing.Size(30, 30);
            this.lbNumberMessage.TabIndex = 5;
            this.lbNumberMessage.Text = "5";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbTime.Location = new System.Drawing.Point(187, 8);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(63, 19);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "Just now";
            // 
            // lbLastMessage
            // 
            this.lbLastMessage.AutoSize = true;
            this.lbLastMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbLastMessage.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastMessage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbLastMessage.Location = new System.Drawing.Point(59, 42);
            this.lbLastMessage.Name = "lbLastMessage";
            this.lbLastMessage.Size = new System.Drawing.Size(153, 19);
            this.lbLastMessage.TabIndex = 3;
            this.lbLastMessage.Text = "New message coming...";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold);
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(59, 17);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(110, 19);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Nguyen Van A";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAvatar.BorderRadius = 16;
            this.pictureBoxAvatar.Image = global::BookShopManagement.Properties.Resources._8664831_user_icon;
            this.pictureBoxAvatar.ImageRotate = 0F;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(13, 14);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.ShadowDecoration.Color = System.Drawing.Color.Fuchsia;
            this.pictureBoxAvatar.ShadowDecoration.Enabled = true;
            this.pictureBoxAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBoxAvatar.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 1;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // UC_UserListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemPanel);
            this.Name = "UC_UserListItem";
            this.Size = new System.Drawing.Size(258, 86);
            this.itemPanel.ResumeLayout(false);
            this.itemPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel itemPanel;
        private Guna.UI2.WinForms.Guna2Button lbNumberMessage;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbLastMessage;
        private System.Windows.Forms.Label lbName;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxAvatar;
    }
}
