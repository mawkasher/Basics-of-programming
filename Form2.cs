using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullAndCows
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }
        public int randnum, rnum1 = 0, rnum2 = 0, rnum3 = 0, rnum4 = 0, unum1, unum2, unum3, unum4, usernum, cow, bull, count = 0;


        DateTime date1 = new DateTime(0, 0);
        private void timer1_Tick(object sender, EventArgs e)
        {

            date1 = date1.AddSeconds(1);

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
        private void button2_Click(object sender, EventArgs e)
        {

            Sure Sure = new Sure();
            Sure.Show();
            Sure.Activate();

        }
        //КНОПКА ПРАВИЛА
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила игры\r\n" +
                "\nКомпьютер задумывает четыре различные цифры из 0,1,2,...9. Игрок делает ходы, чтобы узнать эти цифры и их порядок.\r" +
                "\n\r" +
                "\nКаждый ход состоит из четырёх цифр, 0 может стоять на первом месте.\r\n\r" +
                "\nВ ответ компьютер показывает число отгаданных цифр, стоящих на своих местах (число быков) и число отгаданных цифр, стоящих не на своих местах (число коров).\r" +
                "\n\r" +
                "\nПример\r" +
                "\nКомпьютер задумал 0834.\r" +
                "\n\r" +
                "\nИгрок сделал ход 8134.\r" +
                "\n\r" +
                "\nКомпьютер ответил: 2 быка (цифры 3 и 4) и 1 корова (цифра 8).",
                "Правила");
        }
        //ДЕЙСТВИЕ ПРИ ЗАПУСКЕ ИГРЫ
        public int[] Cut(int randomnumber)
        {
            int[] runn = new int[4];
            runn[0] = randomnumber / 1000;
            runn[1] = (randomnumber / 100) % 10;
            runn[2] = (randomnumber / 10) % 10;
            runn[3] = randomnumber % 10;
            return runn;
        }
        private void Game_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            while (rnum1 == rnum2 || rnum1 == rnum3 || rnum1 == rnum4 || rnum2 == rnum3 || rnum2 == rnum4 || rnum3 == rnum4)
            {
                randnum = random.Next(0, 9999);
                rnum1 = Cut(randnum)[0];
                rnum2 = Cut(randnum)[1];
                rnum3 = Cut(randnum)[2];
                rnum4 = Cut(randnum)[3];
            }
            timer1.Enabled = true;


        }
        //КОЛИЧЕСТВО ПОПЫТОК
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //ВАШЕ ЧИСЛО
        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //КОЛИЧЕСТВО БЫКОВ
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //КОЛИЧЕСТВО КОРОВ
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //КНОПКА ПРОВЕРИТЬ
        public string CheckNum(int unum, int rnum1, int rnum2, int rnum3, int rnum4)
        {
            //Проверка  числа
            if (unum == rnum1)
            {
                return "Cow";
            }
            else
            {
                if (unum == rnum2)
                {
                    return "Bull";
                }
                else
                {
                    if (unum == rnum3)
                    {
                        return "Bull";
                    }
                    else
                    {
                        if (unum == rnum4)
                        {
                            return "Bull";
                        }
                    }
                }
            }
            return "default";

        }
        private void button4_Click(object sender, EventArgs e)
        {

            unum1 = Convert.ToInt32(numericUpDown1.Value);
            unum2 = Convert.ToInt32(numericUpDown2.Value);
            unum3 = Convert.ToInt32(numericUpDown3.Value);
            unum4 = Convert.ToInt32(numericUpDown4.Value);
            usernum = unum1 * 1000 + unum2 * 100 + unum3 * 10 + unum4;

            switch (CheckNum(unum1, rnum1, rnum2, rnum3, rnum4))
            {
                case "Cow":
                    cow++;
                    break;
                case "Bull":
                    bull++;
                    break;
            }
            switch (CheckNum(unum2, rnum2, rnum1, rnum3, rnum4))
            {
                case "Cow":
                    cow++;
                    break;
                case "Bull":
                    bull++;
                    break;
            }
            switch (CheckNum(unum3, rnum3, rnum1, rnum2, rnum4))
            {
                case "Cow":
                    cow++;
                    break;
                case "Bull":
                    bull++;
                    break;
            }
            switch (CheckNum(unum4, rnum4, rnum1, rnum2, rnum3))
            {
                case "Cow":
                    cow++;
                    break;
                case "Bull":
                    bull++;
                    break;
            }

            if (unum1 == unum2 || unum1 == unum3 || unum1 == unum4 || unum2 == unum3 || unum2 == unum4 || unum3 == unum4)
            {
                MessageBox.Show("Числа не могут повторятся", "Предупреждение");

            }
            else
            {
                if (usernum < 999)
                {
                    textBox2.Text = "0" + Convert.ToString(usernum);
                }
                else
                {
                    textBox2.Text = Convert.ToString(usernum);
                }

                count++;
                textBox1.Text = Convert.ToString(count);
                textBox4.Text = Convert.ToString(cow);
                textBox3.Text = Convert.ToString(bull);

                textBox5.Text = Convert.ToString(randnum);

                richTextBox1.Text = "\r" + richTextBox1.Text
                    + "\r Число: " + textBox2.Text
                    + "\r Коров: " + textBox4.Text
                    + "\r Быков: " + textBox3.Text
                    + "\r";


                if (cow == 4 && randnum == usernum)
                {
                    timer1.Enabled = false;

                    if (usernum < 999)
                    {
                        MessageBox.Show("Ты угадал!\r\n" +
                "\nВаши результаты:\r\r" +
                "\nЗагаданное число: \r" + "0" + usernum + "\n\r" +
                "\nКоличество попыток: \r" + count +
                //"\nПрошло времени: \r" + date1.ToString("tmm:ss") +
                "\n\r"
                , "Результаты");
                    }
                    else
                    {
                        MessageBox.Show("Ты угадал!\r\n" +
                "\nВаши результаты:\r\r" +
                "\nЗагаданное число: \r" + usernum + "\n\r" +
                "\nКоличество попыток: \r" + count +
                //"\nПрошло времени: \r" + date1.ToString("tmm:ss") +
                "\n\r"
                , "Результаты");
                    }
                    timer1 = null;
                    GameOver GameOver = new GameOver();
                    GameOver.Show();
                    Hide();
                    GameOver.Activate();


                }
                cow = 0;
            }
            bull = 0;
            cow = 0;
        }
    }
}
