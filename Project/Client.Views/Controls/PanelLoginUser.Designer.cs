using System.ComponentModel;

namespace Client.Views.Controls
{
    partial class PanelLoginUser
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
            this.LoginHeaderPanel = new System.Windows.Forms.Panel();
            this.LoginHeaderLablel = new System.Windows.Forms.Label();
            this.PanelError = new System.Windows.Forms.Panel();
            this.ErrorTable = new System.Windows.Forms.TableLayoutPanel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.LoginBodyPanel = new System.Windows.Forms.Panel();
            this.BodyPanelTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.PanelSubmit = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.loginButton = new System.Windows.Forms.Button();
            this.LoginHeaderPanel.SuspendLayout();
            this.PanelError.SuspendLayout();
            this.ErrorTable.SuspendLayout();
            this.LoginBodyPanel.SuspendLayout();
            this.BodyPanelTableLayout.SuspendLayout();
            this.PanelSubmit.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginHeaderPanel
            // 
            this.LoginHeaderPanel.Controls.Add(this.LoginHeaderLablel);
            this.LoginHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginHeaderPanel.Name = "LoginHeaderPanel";
            this.LoginHeaderPanel.Size = new System.Drawing.Size(300, 75);
            this.LoginHeaderPanel.TabIndex = 0;
            // 
            // LoginHeaderLablel
            // 
            this.LoginHeaderLablel.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.LoginHeaderLablel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.LoginHeaderLablel.Location = new System.Drawing.Point(0, 52);
            this.LoginHeaderLablel.Margin = new System.Windows.Forms.Padding(3);
            this.LoginHeaderLablel.Name = "LoginHeaderLablel";
            this.LoginHeaderLablel.Size = new System.Drawing.Size(300, 23);
            this.LoginHeaderLablel.TabIndex = 0;
            this.LoginHeaderLablel.Text = "LOGIN";
            this.LoginHeaderLablel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelError
            // 
            this.PanelError.Controls.Add(this.ErrorTable);
            this.PanelError.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelError.Location = new System.Drawing.Point(0, 75);
            this.PanelError.Name = "PanelError";
            this.PanelError.Size = new System.Drawing.Size(300, 25);
            this.PanelError.TabIndex = 2;
            this.PanelError.Visible = false;
            // 
            // ErrorTable
            // 
            this.ErrorTable.ColumnCount = 1;
            this.ErrorTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ErrorTable.Controls.Add(this.ErrorLabel, 0, 0);
            this.ErrorTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorTable.Location = new System.Drawing.Point(0, 0);
            this.ErrorTable.Name = "ErrorTable";
            this.ErrorTable.RowCount = 1;
            this.ErrorTable.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ErrorTable.Size = new System.Drawing.Size(300, 25);
            this.ErrorTable.TabIndex = 0;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(120, 5);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(60, 15);
            this.ErrorLabel.TabIndex = 1;
            this.ErrorLabel.Text = "ErrorLabel";
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginBodyPanel
            // 
            this.LoginBodyPanel.Controls.Add(this.BodyPanelTableLayout);
            this.LoginBodyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginBodyPanel.Location = new System.Drawing.Point(0, 100);
            this.LoginBodyPanel.Name = "LoginBodyPanel";
            this.LoginBodyPanel.Size = new System.Drawing.Size(300, 100);
            this.LoginBodyPanel.TabIndex = 3;
            // 
            // BodyPanelTableLayout
            // 
            this.BodyPanelTableLayout.ColumnCount = 2;
            this.BodyPanelTableLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.66667F));
            this.BodyPanelTableLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.33334F));
            this.BodyPanelTableLayout.Controls.Add(this.LabelUsername, 0, 0);
            this.BodyPanelTableLayout.Controls.Add(this.LabelPassword, 0, 1);
            this.BodyPanelTableLayout.Controls.Add(this.textBoxUsername, 1, 0);
            this.BodyPanelTableLayout.Controls.Add(this.textBoxPassword, 1, 1);
            this.BodyPanelTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanelTableLayout.Location = new System.Drawing.Point(0, 0);
            this.BodyPanelTableLayout.Name = "BodyPanelTableLayout";
            this.BodyPanelTableLayout.RowCount = 2;
            this.BodyPanelTableLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BodyPanelTableLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BodyPanelTableLayout.Size = new System.Drawing.Size(300, 100);
            this.BodyPanelTableLayout.TabIndex = 0;
            // 
            // LabelUsername
            // 
            this.LabelUsername.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelUsername.Location = new System.Drawing.Point(11, 10);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(80, 29);
            this.LabelUsername.TabIndex = 0;
            this.LabelUsername.Text = "Username";
            this.LabelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelPassword
            // 
            this.LabelPassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelPassword.Location = new System.Drawing.Point(9, 50);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(82, 50);
            this.LabelPassword.TabIndex = 1;
            this.LabelPassword.Text = "Password";
            this.LabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxUsername.Location = new System.Drawing.Point(104, 13);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(150, 23);
            this.textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxPassword.Location = new System.Drawing.Point(104, 63);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(150, 23);
            this.textBoxPassword.TabIndex = 3;
            // 
            // PanelSubmit
            // 
            this.PanelSubmit.Controls.Add(this.tableLayoutPanel1);
            this.PanelSubmit.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSubmit.Location = new System.Drawing.Point(0, 200);
            this.PanelSubmit.Name = "PanelSubmit";
            this.PanelSubmit.Size = new System.Drawing.Size(300, 50);
            this.PanelSubmit.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.loginButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.AutoSize = true;
            this.loginButton.Location = new System.Drawing.Point(112, 11);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 27);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // PanelLoginUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelSubmit);
            this.Controls.Add(this.LoginBodyPanel);
            this.Controls.Add(this.PanelError);
            this.Controls.Add(this.LoginHeaderPanel);
            this.Name = "PanelLoginUser";
            this.Size = new System.Drawing.Size(300, 302);
            this.LoginHeaderPanel.ResumeLayout(false);
            this.PanelError.ResumeLayout(false);
            this.ErrorTable.ResumeLayout(false);
            this.ErrorTable.PerformLayout();
            this.LoginBodyPanel.ResumeLayout(false);
            this.BodyPanelTableLayout.ResumeLayout(false);
            this.BodyPanelTableLayout.PerformLayout();
            this.PanelSubmit.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel LoginHeaderPanel;
        private System.Windows.Forms.Label LoginHeaderLablel;
        private System.Windows.Forms.Panel LoginBodyPanel;
        private System.Windows.Forms.Label LabelUsername;
        private System.Windows.Forms.TableLayoutPanel BodyPanelTableLayout;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Panel PanelError;
        private System.Windows.Forms.Panel PanelSubmit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TableLayoutPanel ErrorTable;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}