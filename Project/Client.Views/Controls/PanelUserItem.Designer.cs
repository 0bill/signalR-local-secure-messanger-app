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
            this.LabelUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelUserName
            // 
            this.LabelUserName.Location = new System.Drawing.Point(-3, 19);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(300, 15);
            this.LabelUserName.TabIndex = 0;
            this.LabelUserName.Text = "LabelUserName";
            // 
            // PanelUserItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelUserName);
            this.Name = "PanelUserItem";
            this.Size = new System.Drawing.Size(300, 50);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label LabelUserName;
    }
}