namespace BookShopManagement.UserControls
{
    partial class UC_UserComment
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
            this.imgUserAvatar = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserComment = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imgUserAvatar
            // 
            this.imgUserAvatar.Location = new System.Drawing.Point(3, 3);
            this.imgUserAvatar.Name = "imgUserAvatar";
            this.imgUserAvatar.Size = new System.Drawing.Size(128, 100);
            this.imgUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgUserAvatar.TabIndex = 0;
            this.imgUserAvatar.TabStop = false;
            this.imgUserAvatar.Click += new System.EventHandler(this.imgUserAvatar_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(158, 14);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(70, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "label1";
            // 
            // lblUserComment
            // 
            this.lblUserComment.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserComment.Location = new System.Drawing.Point(157, 45);
            this.lblUserComment.Name = "lblUserComment";
            this.lblUserComment.Size = new System.Drawing.Size(476, 49);
            this.lblUserComment.TabIndex = 2;
            this.lblUserComment.Text = "label2";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(474, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(19, 21);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(537, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(62, 18);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "lblDate";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BookShopManagement.Properties.Resources._285661_star_icon;
            this.pictureBox2.Location = new System.Drawing.Point(495, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // UC_UserComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblUserComment);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.imgUserAvatar);
            this.Name = "UC_UserComment";
            this.Size = new System.Drawing.Size(645, 106);
            ((System.ComponentModel.ISupportInitialize)(this.imgUserAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserComment;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
