using System;
using System.Windows.Forms;
using MessengerLogic;
using System.Collections.Generic;

namespace Messenger
{
    public partial class FrmOnlineUsers : Form
    {
        public static FrmSend frm;
        public FrmOnlineUsers()
        {
            InitializeComponent();
        }

        private void FrmOnlineUsers_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        { 
            Connection refresh = new Connection();
            List<string> allUsers = new List<string>();
            allUsers =  refresh.Refresh();
            listView1.Items.Clear();
            foreach (var person in allUsers)
            {
                ListViewItem item = new ListViewItem(person);
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            string s = listView1.Items[i].Text;
            frm = new FrmSend();
            frm.Text = s;
            frm.Show();
        }
    }
}
