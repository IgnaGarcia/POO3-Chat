using System;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            goToChatList(loginUsername.Text);
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            goToChatList(signupUsername.Text);
        }

        private void goToChatList(string username)
        {
            Hide();
            ChatListView chatListView = new ChatListView(username);
            chatListView.Show();
        }
    }
}
