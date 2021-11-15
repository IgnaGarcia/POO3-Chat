using ChatClient.views;
using System;
using System.Windows.Forms;

namespace ChatClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginView());
        }
    }
}
