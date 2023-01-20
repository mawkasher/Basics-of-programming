using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullAndCows
{
    public partial class Sure : Form
    {
        public Sure()
        {
            InitializeComponent();
        }
        //ПОКИНУТЬ
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //ОСТАТЬСЯ
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
