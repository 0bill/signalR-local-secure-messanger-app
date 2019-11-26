using System.ComponentModel;

namespace Client.Views.Controls
{
    partial class PanelUserItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Client.Views.Controls.PanelUserItem));
            this.LabelUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            this.LabelUserName.Font = new System.Drawing.Font("Segoe UI", 12F,
                ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.LabelUserName.Location = new System.Drawing.Point(63, 0);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(234, 48);
            this.LabelUserName.TabIndex = 0;
            this.LabelUserName.Text = "LabelUserName";
            this.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MouseHover += new System.EventHandler(this.LabelUserName_MouseHover);
            this.LabelUserName.MouseHover += new System.EventHandler(this.LabelUserName_MouseHover);
            this.pictureBox1.MouseHover += new System.EventHandler(this.LabelUserName_MouseHover);
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LabelUserName);
            this.Name = "PanelUserItem";
            this.Size = new System.Drawing.Size(299, 50);
            this.MouseLeave += new System.EventHandler(this.PanelUserItem_MouseLeave);
            this.LabelUserName.MouseLeave += new System.EventHandler(this.PanelUserItem_MouseLeave);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PanelUserItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label LabelUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}