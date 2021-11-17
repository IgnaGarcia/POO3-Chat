using ChatClient.client;
using ChatEntities.entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class ChatView : Form
    {
        List<Chat> chatList;
        User user;
        Client client;
        Chat chat;

        public ChatView(Client client, Chat chat, User user, List<Chat> chatList)
        {
            this.user = user;
            this.chat = chat;
            this.chatList = chatList;
            this.client = client;

            client.onUpdateMessages = UpdateMessage;
            client.onUpdateChat = UpdateChat;

            //client.Send(new Request(4, chat.GetId()));
            client.Send(new Request(8, chat.GetId(), user.GetId()));

            InitializeComponent();
            labelChatName.Text = chat.GetName();
            loadChats();
        }

        private void loadChats()
        {
            chatList.ForEach(el =>
            {
                viewListChat.Items.Add(el.GetName());
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = viewMessage.Text.Trim();
            if(message != null || message != "")
            {
                client.Send(new Request(5, chat.GetId(), user.GetId(), user.GetName(), message));
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            client.Send(new Request(7, chat.GetId(), user.GetId()));
            Hide();
            ChatListView chatListView = new ChatListView(client, user);
            chatListView.Show();
        }

        public void UpdateMessage(object o)
        {
            BeginInvoke(new Action(() =>
            {
                if (o is ChatEntities.entities.Message)
                {
                    AddMessage((ChatEntities.entities.Message)o);
                }
            }));
        }

        public void AddMessage(ChatEntities.entities.Message msg)
        {
            if(msg.GetFromId() == user.GetId()) viewChat.Items.Add(">>"+msg.GetFromId() + ": " + msg.GetMessage());
            else viewChat.Items.Add(msg.GetFromName() + ": " + msg.GetMessage());
            /*
            Label message = new Label();
            message.ForeColor = (msg.GetFromId() == user.GetId())? Color.Firebrick : Color.Snow;
            message.Text = msg.GetFromName() + ": " + msg.GetMessage();
            messagesContainer.Controls.Add(message);
            */
        }

        public void UpdateChat(object o)
        {
            BeginInvoke(new Action(() =>
            {
                if (o is Chat)
                {
                    viewListChat.Items.Add(((Chat)o).GetName());
                }
            }));
        }
    }
}
