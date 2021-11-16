using ChatClient.client;
using ChatEntities.entities;
using System;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class ChatView : Form
    {
        string chatName;
        User user;
        Client client;
        public ChatView(Client client, string chatName, User user)
        {
            this.chatName = chatName;
            this.user = user;
            this.client = client;
            InitializeComponent();
            labelChatName.Text = chatName;
            listUser.Items.Add("["+user.GetName()+"]");
            listUser.Items.Add("user2");
            listUser.Items.Add("user3");
            listUser.Items.Add("user4");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Console.WriteLine(message.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            ChatListView chatListView = new ChatListView(client, user);
            chatListView.Show();
        }
    }
}
