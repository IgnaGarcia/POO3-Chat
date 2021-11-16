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
        List<Chat> listaDeChats;
        public ChatListView(Client client, User user)
        {
            this.client = client;
            client.onUpdateChatList = UpdateChatList;
            client.Send(new Request(3));
            this.user = user;
            InitializeComponent();
        }

        private void listChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chatname = listChat.Items[listChat.SelectedIndex].ToString()!;
            Hide();
            ChatView chatView = new ChatView(client, listaDeChats[listChat.SelectedIndex], user);
            chatView.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            //string username = user.GetName();

            //if (username != null && username != "")
            //    client.Send(new Request(6, username));

            LoginView loginView = new LoginView(client);
            loginView.Show();
        }

        public void UpdateChatList(object o)
        {
            BeginInvoke(new Action(() =>
            {
                if (o is List<Chat>)
                {
                    listaDeChats = (List<Chat>)o
                    listaDeChats!.ForEach(el => listChat.Items.Add(el.GetName()));
                }
            }));
        }
    }
}
