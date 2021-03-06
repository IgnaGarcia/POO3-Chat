namespace ChatClient.views
{
    partial class ChatView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewListChat = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.messagesContainer = new System.Windows.Forms.Panel();
            this.chatHeader = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelChatName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.viewMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.chatHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewListChat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 611);
            this.panel1.TabIndex = 0;
            // 
            // viewListChat
            // 
            this.viewListChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.viewListChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.viewListChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewListChat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewListChat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.viewListChat.FormattingEnabled = true;
            this.viewListChat.ItemHeight = 21;
            this.viewListChat.Location = new System.Drawing.Point(0, 35);
            this.viewListChat.Name = "viewListChat";
            this.viewListChat.Size = new System.Drawing.Size(298, 574);
            this.viewListChat.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Chats";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.messagesContainer);
            this.panel2.Controls.Add(this.chatHeader);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(300, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 611);
            this.panel2.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.listView1.Location = new System.Drawing.Point(0, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(882, 539);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // messagesContainer
            // 
            this.messagesContainer.AutoScroll = true;
            this.messagesContainer.AutoScrollMinSize = new System.Drawing.Size(0, 5);
            this.messagesContainer.AutoSize = true;
            this.messagesContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.messagesContainer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messagesContainer.Location = new System.Drawing.Point(0, 35);
            this.messagesContainer.Name = "messagesContainer";
            this.messagesContainer.Size = new System.Drawing.Size(0, 539);
            this.messagesContainer.TabIndex = 3;
            // 
            // chatHeader
            // 
            this.chatHeader.Controls.Add(this.btnExit);
            this.chatHeader.Controls.Add(this.labelChatName);
            this.chatHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatHeader.Location = new System.Drawing.Point(0, 0);
            this.chatHeader.Name = "chatHeader";
            this.chatHeader.Size = new System.Drawing.Size(882, 35);
            this.chatHeader.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Volver";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelChatName
            // 
            this.labelChatName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.labelChatName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelChatName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelChatName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelChatName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelChatName.Location = new System.Drawing.Point(0, 0);
            this.labelChatName.Name = "labelChatName";
            this.labelChatName.Size = new System.Drawing.Size(882, 35);
            this.labelChatName.TabIndex = 0;
            this.labelChatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.viewMessage);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 574);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 35);
            this.panel3.TabIndex = 0;
            // 
            // viewMessage
            // 
            this.viewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewMessage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewMessage.Location = new System.Drawing.Point(0, 0);
            this.viewMessage.Name = "viewMessage";
            this.viewMessage.Size = new System.Drawing.Size(782, 36);
            this.viewMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(782, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 35);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ChatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatView";
            this.Text = "Chat - ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.chatHeader.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox viewListChat;
        private System.Windows.Forms.Panel chatHeader;
        private System.Windows.Forms.Label labelChatName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox viewMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox viewChat;
        private System.Windows.Forms.Panel messagesContainer;
        private System.Windows.Forms.ListView listView1;
    }
}