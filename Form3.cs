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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }
        //ПОКИНУТЬ
        private void button3_Click(object sender, EventArgs e)
        {
            Sure Sure = new Sure();
            Sure.Show();
            Sure.Activate();
        }
        //ЕЩЕ РАЗ
        private void button1_Click(object sender, EventArgs e)
        {
            Game Game = new Game();
            Game.Show();
            this.Close();
            Game.Activate();
        }
        //ВЫЙТИ
        private void button2_Click(object sender, EventArgs e)
        {
            authorization auth = new authorization();
            auth.Show();
            this.Close();
            auth.Activate();
        }
        //ОБ ИГРЕ
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "Разработка: Батаев Александр\r" +
               "\nДизайн: Батаев Александр\r"
               , "ОБ ИГРЕ");
        }
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        
      
        private void GameOver_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
