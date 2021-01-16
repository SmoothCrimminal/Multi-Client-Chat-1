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
            if (txtMessageBox.Text.Trim() == "")
            {

            }

            else
            {
                string message = txtMessageBox.Text;
                Connection sendMessage = new Connection();
                sendMessage.SendMessage(to, message);
                txtMessageBox.Text = "";
                txtMessages.AppendText($"You: {message}");
                txtMessages.AppendText(Environment.NewLine);
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

        public void AssignValues(string from, string msg)
        {
            _from = from;
            _msg = msg;
        }
    }
}
