﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using MessengerLogic;

namespace Messenger
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtNickname.Text.Trim() == "")
                MessageBox.Show("Please fill in the nickname field");
            else
            {
                string nickname = txtNickname.Text;
                try
                {
                    Connection connection = new Connection();
                    connection.Connect(nickname);
                    FrmOnlineUsers frm = new FrmOnlineUsers();
                    this.Hide();
                    frm.Show();
                }
                catch (Exception)
                {

                    MessageBox.Show("Connection failed!");
                }
            }
            
        }
    }
}
