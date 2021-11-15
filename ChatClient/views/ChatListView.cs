using System;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class ChatListView : Form
    {
        string userName;
        public ChatListView(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            listChat.Items.Add("prueba");
            listChat.Items.Add("prueba1");
            listChat.Items.Add("prueba2");
            listChat.Items.Add("prueba3");
        }

        private void listChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chatname = listChat.Items[listChat.SelectedIndex].ToString()!;
            Hide();
            ChatView chatView = new ChatView(chatname, userName);
            chatView.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            LoginView loginView = new LoginView();
            loginView.Show();
        }
    }
}
