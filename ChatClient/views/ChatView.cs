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

            this.Text += " "+chat.GetName();
            listView1.Columns.Add("", -2, HorizontalAlignment.Left);
            listView1.View = View.Details;
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
            Console.WriteLine(message.Length);
            if(message != null && message != "")
            {
                client.Send(new Request(5, user.GetId(), chat.GetId(), user.GetName(), message));
                viewMessage.Text = "";
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
                } else if(o is List<ChatEntities.entities.Message>)
                {
                    ((List<ChatEntities.entities.Message>)o).ForEach(el =>
                        AddMessage(el));
                    if(listView1.Items.Count > 0)
                        listView1.Items[listView1.Items.Count - 1].EnsureVisible();
                }
            }));
        }

        public void AddMessage(ChatEntities.entities.Message msg)
        {
            string baseMsg = msg.GetFromName() + "(" + msg.GetCreatedDate() + "): " + msg.GetMessage();

            ListViewItem item = new ListViewItem();
            item.ForeColor = (msg.GetFromId() == user.GetId()) ? Color.Firebrick : Color.DeepSkyBlue;
            item.Text = baseMsg;
            
            listView1.Items.Add(item);
                    
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
