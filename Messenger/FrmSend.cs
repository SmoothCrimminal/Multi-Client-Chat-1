using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessengerLogic;

namespace Messenger
{
    public partial class FrmSend : Form
    {
        public static string _from, _msg;
        public FrmSend()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string to = FrmSend.ActiveForm.Text;
            if (txtMessageBox.Text.Trim() == "" && txtFilePath.Text.Trim() == "")
            {

            }

            else if (txtMessageBox.Text.Trim() != "" && txtFilePath.Text.Trim() == "")
            {
                string message = txtMessageBox.Text;
                Connection sendMessage = new Connection();
                sendMessage.SendMessage(to, message);
                txtMessageBox.Text = "";
                txtMessages.AppendText($"You: {message}");
                txtMessages.AppendText(Environment.NewLine);
            }

            else if (txtMessageBox.Text.Trim() == "" && txtFilePath.Text.Trim() != "")
            {
                string path = txtFilePath.Text;
                string nick = FrmMenu._nickname;
                Connection sendFile = new Connection();
                sendFile.FileSend(path, nick);
            }
        }


        public void MessageFromClient()
        {

            txtMessages.Invoke(new Action(delegate ()
            {
                txtMessages.AppendText($"{_from}: {_msg}");
                txtMessages.AppendText(Environment.NewLine);
            }));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        public void AssignValues(string from, string msg)
        {
            _from = from;
            _msg = msg;
        }
    }
}
