using System;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class ChatView : Form
    {
        string chatName;
        string userName;
        public ChatView(string chatName, string userName)
        {
            this.chatName = chatName;
            this.userName = userName;
            InitializeComponent();
            labelChatName.Text = chatName;
            listUser.Items.Add("["+userName+"]");
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
            ChatListView chatListView = new ChatListView(userName);
            chatListView.Show();
        }
    }
}
