﻿using System.ComponentModel;
using System.Drawing;

namespace Client.Views
{
    partial class HomePanelView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelUsers = new System.Windows.Forms.Panel();
            this.TopMenu.SuspendLayout();
            this.SuspendLayout();
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMenuItem1});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(350, 24);
            this.TopMenu.TabIndex = 0;
            this.TopMenu.Text = "TopMenu";
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menu";
            this.PanelUsers.AutoScroll = true;
            this.PanelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelUsers.Location = new System.Drawing.Point(0, 24);
            this.PanelUsers.Name = "PanelUsers";
            this.PanelUsers.Size = new System.Drawing.Size(350, 776);
            this.PanelUsers.TabIndex = 1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 800);
            this.Controls.Add(this.PanelUsers);
            this.Controls.Add(this.TopMenu);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "HomePanelView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HomePanelView";
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.Panel PanelUsers;
    }
}