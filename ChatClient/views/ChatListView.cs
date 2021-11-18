using ChatClient.client;
using ChatEntities.entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class ChatListView : Form
    {
        Client client;
        User user;
        List<Chat> chatList;
        public ChatListView(Client client, User user)
        {
            this.client = client;
            this.user = user;

            client.onUpdateChatList = UpdateChatList;
            client.onUpdateChat = UpdateChat;

            client.Send(new Request(3));

            InitializeComponent();
        }

        private void listChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hide();
                ChatView chatView = new ChatView(client, chatList[viewListChat.SelectedIndex], user, chatList);
                chatView.Show();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            client.Send(new Request(6));
            client.Disconnect();
            LoginView loginView = new LoginView();
            loginView.Show();
        }

        public void UpdateChatList(object o)
        {
            BeginInvoke(new Action(() =>
            {
                if (o is List<Chat>)
                {
                    chatList = (List<Chat>)o;
                    chatList.ForEach(el => viewListChat.Items.Add(el.GetName()));
                }
            }));
        }
        public void UpdateChat(object o)
        {
            BeginInvoke(new Action(() =>
            {
                if (o is Chat)
                {
                    viewListChat.Items.Add(((Chat)o).GetName());
                    chatList.Add((Chat)o);
                }
            }));
        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            string chatname = createChat.Text.Trim();
            if (chatname != null && chatname != "")
            {
                client.Send(new Request(9, chatname));
                createChat.Text = "";
            }
        }
    }
}
