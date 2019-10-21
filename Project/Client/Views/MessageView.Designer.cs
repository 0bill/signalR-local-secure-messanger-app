using System.ComponentModel;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.labeHl1 = new System.Windows.Forms.Label();
            this.MessagesItemsPanel = new System.Windows.Forms.Panel();
            this.MessageInputTable = new System.Windows.Forms.TableLayoutPanel();
            this.TextboxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.MessageInputTable.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labeHl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MessagesItemsPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
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
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.53345F));
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.46655F));
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 343);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(547, 105);
            this.tableLayoutPanel2.TabIndex = 2;
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(10, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(447, 85);
            this.textBox1.TabIndex = 1;
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Location = new System.Drawing.Point(485, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.labeHl1.Location = new System.Drawing.Point(3, 0);
            this.labeHl1.Name = "labeHl1";
            this.labeHl1.Size = new System.Drawing.Size(100, 23);
            this.labeHl1.TabIndex = 3;
            this.labeHl1.Text = "Header";
            this.MessagesItemsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessagesItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagesItemsPanel.Location = new System.Drawing.Point(5, 46);
            this.MessagesItemsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.MessagesItemsPanel.Name = "MessagesItemsPanel";
            this.MessagesItemsPanel.Size = new System.Drawing.Size(543, 289);
            this.MessagesItemsPanel.TabIndex = 4;
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
            this.buttonSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSend.AutoSize = true;
            this.buttonSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSend.Location = new System.Drawing.Point(174, 38);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(23, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MessageView";
            this.Text = "MessageView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.MessageInputTable.ResumeLayout(false);
            this.MessageInputTable.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox TextboxMessage;
        private System.Windows.Forms.TableLayoutPanel MessageInputTable;
        private System.Windows.Forms.Panel MessagesItemsPanel;
        private System.Windows.Forms.Label labeHl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}