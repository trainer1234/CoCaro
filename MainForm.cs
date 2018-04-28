using CoCaro.View.History;
using CoCaro.View.PlayWithCom;
using CoCaro.View.PlayWithPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnPlayWithCom_Click(object sender, EventArgs e)
        {
            PlayWithComViewForm form = new PlayWithComViewForm();
            form.Show();
        }

        private void btnPlayWithPlayer_Click(object sender, EventArgs e)
        {
            PlayWithPlayerViewForm form = new PlayWithPlayerViewForm();
            form.Show();
        }

        private void btnWatchRecord_Click(object sender, EventArgs e)
        {
            HistoryViewForm form = new HistoryViewForm();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        
    }
}
