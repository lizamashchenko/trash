using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            string[] sports = new string[5] {"football","biathlon","running","high jump","alpine skiing" };
            comboBox1.DataSource = sports;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
