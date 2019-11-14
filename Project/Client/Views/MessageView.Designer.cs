using System.ComponentModel;
using System.Drawing;
using Client.Views.Controls;
using Domain;

namespace Client.Views
{
    partial class MessageView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendNewMessageButton = new System.Windows.Forms.Button();
            this.labeHl1 = new System.Windows.Forms.Label();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.MessageInputTable = new System.Windows.Forms.TableLayoutPanel();
            this.TextboxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.MessageInputTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labeHl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MessagePanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.05882F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.94118F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.53345F));
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.46655F));
            this.tableLayoutPanel2.Controls.Add(this.messageTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.sendNewMessageButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 343);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(545, 105);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.messageTextBox.AcceptsReturn = true;
            this.messageTextBox.AcceptsTab = true;
            this.messageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTextBox.Location = new System.Drawing.Point(10, 10);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(446, 85);
            this.messageTextBox.TabIndex = 1;
            // 
            // sendNewMessageButton
            // 
            this.sendNewMessageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendNewMessageButton.AutoSize = true;
            this.sendNewMessageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendNewMessageButton.Location = new System.Drawing.Point(484, 40);
            this.sendNewMessageButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sendNewMessageButton.Name = "sendNewMessageButton";
            this.sendNewMessageButton.Size = new System.Drawing.Size(43, 25);
            this.sendNewMessageButton.TabIndex = 2;
            this.sendNewMessageButton.Text = "Send";
            this.sendNewMessageButton.UseVisualStyleBackColor = true;
            this.sendNewMessageButton.Click += new System.EventHandler(this.sendNewMessageButton_Click);
            // 
            // labeHl1
            // 
            this.labeHl1.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labeHl1.Location = new System.Drawing.Point(4, 0);
            this.labeHl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeHl1.Name = "labeHl1";
            this.labeHl1.Size = new System.Drawing.Size(545, 23);
            this.labeHl1.TabIndex = 3;
            this.labeHl1.Text = "Header";
            this.labeHl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.Color.Transparent;
            this.MessagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagePanel.Location = new System.Drawing.Point(4, 44);
            this.MessagePanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(545, 293);
            this.MessagePanel.TabIndex = 4;
            // 
            // MessageInputTable
            // 
            this.MessageInputTable.ColumnCount = 2;
            this.MessageInputTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.53345F));
            this.MessageInputTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.46655F));
            this.MessageInputTable.Controls.Add(this.TextboxMessage, 0, 0);
            this.MessageInputTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageInputTable.Location = new System.Drawing.Point(0, 0);
            this.MessageInputTable.Name = "MessageInputTable";
            this.MessageInputTable.RowCount = 1;
            this.MessageInputTable.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MessageInputTable.Size = new System.Drawing.Size(200, 100);
            this.MessageInputTable.TabIndex = 0;
            // 
            // TextboxMessage
            // 
            this.TextboxMessage.AcceptsReturn = true;
            this.TextboxMessage.AcceptsTab = true;
            this.TextboxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextboxMessage.Location = new System.Drawing.Point(10, 10);
            this.TextboxMessage.Margin = new System.Windows.Forms.Padding(10);
            this.TextboxMessage.Multiline = true;
            this.TextboxMessage.Name = "TextboxMessage";
            this.TextboxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextboxMessage.Size = new System.Drawing.Size(151, 80);
            this.TextboxMessage.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSend.AutoSize = true;
            this.buttonSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSend.Location = new System.Drawing.Point(174, 38);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(23, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // MessageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(569, 490);
            this.Name = "MessageView";
            this.Text = "MessageView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.MessageInputTable.ResumeLayout(false);
            this.MessageInputTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox TextboxMessage;
        private System.Windows.Forms.TableLayoutPanel MessageInputTable;
        private System.Windows.Forms.Label labeHl1;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Button sendNewMessageButton;
    }
}