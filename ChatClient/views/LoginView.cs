using ChatClient.client;
using ChatEntities.entities;
using System;
using System.Windows.Forms;

namespace ChatClient.views
{
    public partial class LoginView : Form
    {
        Client client;
        User _user;
        User user
        {
            set
            {
                if (value != null)
                {
                    _user = value;
                }
            }
            get { return _user; }
        }

        public LoginView(Client client)
        {
            this.client = client;
            client.onUpdateUser = UpdateUser;
            client.Connect();
            InitializeComponent();
        }
        public LoginView() : this(new Client()){ }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = loginUsername.Text.Trim();
            if (username != null && username != "")
            {
                client.Send(new Request(1, username));
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = signupUsername.Text.Trim();
            if (username != null && username != "")
            {
                client.Send(new Request(2, username));
            }
        }

        public void UpdateUser(object o)
        {
            BeginInvoke(new Action(() =>
            {
                if (o is User)
                {
                    user = (User)o;
                    goToChatList(user);
                }
            }));
        }

        private void goToChatList(User user)
        {
            Hide();
            ChatListView chatListView = new ChatListView(client, user);
            chatListView.Show();
        }
    }
}
