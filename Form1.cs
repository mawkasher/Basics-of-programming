using System.IO;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BullAndCows
{
    public partial class authorization : Form
    {

        string Username;
        string Password;
        public bool GameOn = true;
        public string Path = @"D:\bncUSER\bncUSER.txt";
        public string line;

        public authorization()
        {
            InitializeComponent();
        }
        //КНОПКА ОБ ИГРЕ
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "Разработка: Батаев Александр\r" +
               "\nДизайн: Батаев Александр\r"
               , "ОБ ИГРЕ");
        }
        //КНОПКА ПОКИНУТЬ
        private void button2_Click_1(object sender, EventArgs e)
        {
            Sure Sure = new Sure();
            Sure.Show();
            Sure.Activate();

        }
        //КНОПКА АВТОРИЗАЦИЯ
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button7.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";



        }
        //КНОПКА РЕГИСТРАЦИЯ большая
        private void button4_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = true;
            button7.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }
        //ЛОГИН
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Username = textBox1.Text;
        }
        //ПАРОЛЬ
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = textBox2.Text;
        }


        //КНОПКА ВОЙТИ
        public bool authoriz(string path, string username, string password)
        {
            if (username == "" || username == " " || password == "" || password == " ")
            {
                MessageBox.Show("Поля не могут быть пустыми!");
                return false;
            }
            else
            {
                using (StreamReader reader = new StreamReader(path, true))
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        string UsernameCheck = line.Split(' ')[0];
                        if (Username == UsernameCheck)
                        {
                            string PasswordCheck = line.Split(' ')[1];
                            if (Password != PasswordCheck)
                            {
                                MessageBox.Show("Неправильный логин или пароль");
                                return false;
                            }
                            return true;
                        }
                    }
                    MessageBox.Show("Неправильный логин или пароль");
                    return false;



                }

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            GameOn = authoriz(Path, textBox1.Text, textBox2.Text);
            if (GameOn)
            {
                MessageBox.Show("Успешно!");
                Game Game = new Game();
                Game.Show();
                Hide();
                Game.Activate();
            }

        }
        //КНОПКА НАЗАД
        private void button7_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button6.Visible = false;
            button5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button7.Visible = false;
        }
        //КНОПКА РЕГИСТРАЦИЯ маленькая

        public bool registrate(string path, string username, string password)
        {
            if (username == "" || username == " " || password == "" || password == " ")
            {
                MessageBox.Show("Поля не могут быть пустыми!");
                return false;
            }
            else
            {
                using (StreamReader reader = new StreamReader(path, true))
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        string UsernameCheck = line.Split(' ')[0];
                        if (Username == UsernameCheck)
                        {
                            MessageBox.Show("Такой пользователь уже существует");
                            return false;
                        }
                    }
                    return true;
                }

            }

           
        }
        private void button6_Click_1(object sender, EventArgs e)
        {

            GameOn = registrate(Path, textBox1.Text, textBox2.Text);

            if (GameOn)
            {
                using (StreamWriter writer = new StreamWriter(Path, true))
                {

                    writer.Write($"{Username} {Password}\n");


                    MessageBox.Show("Регистрация прошла успешно!");
                    button7_Click(sender, e);
                }
            }
        }
    }
}
