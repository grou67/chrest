using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chrest
{
    public partial class Form1 : Form
    {
        Button[,] field;
        string player;
        bool isgameon = true;
        int iswin = 0;
        int isnotsigma = 0;
        public Form1()
        {
            InitializeComponent();

        }
        public void createFiled()
        {
            Random rand = new Random();

            player = "X";

            field = new Button[3, 3];

            field[0, 0] = button1;
            field[0, 1] = button2;
            field[0, 2] = button3;

            field[1, 0] = button4;
            field[1, 1] = button5;
            field[1, 2] = button6;

            field[2, 0] = button7;
            field[2, 1] = button8;
            field[2, 2] = button9;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j].Text = "";
                    field[i, j].Visible = true;
                    field[i, j].Enabled = true;
                }
            }
        }

        public bool IsWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0].Text == field[i, 1].Text && field[i, 1].Text == field[i, 2].Text && field[i, 0].Text != "")
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (field[0, i].Text == field[1, i].Text && field[1, i].Text == field[2, i].Text && field[0, i].Text != "")
                {
                    return true;
                }
            }

            if (field[0, 0].Text == field[1, 1].Text && field[1, 1].Text == field[2, 2].Text && field[0, 0].Text != "")
            {
                return true;
            }

            if (field[0, 2].Text == field[1, 1].Text && field[1, 1].Text == field[2, 0].Text && field[0, 2].Text != "")
            {
                return true;
            }

            return false;
        }

        
        private void button10_Click(object sender, EventArgs e)
        {
            createFiled();
            button10.Visible = false;
        }

        private void fieldElemClick(object sender, EventArgs e)
        {

            if (playera(sender))
            {
                return;
            }
            else
            {
                Bot();
            }


        }

        private bool playera(object sender)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (((Button)sender).Equals(field[i, j]))
                    {
                        if (field[i, j].Text == "")
                        {
                            field[i, j].Text = player;
                            if (IsWin())
                            {
                                MessageBox.Show($"Выиграл игрок");
                            }
                            if (player == "X")
                            {
                                player = "O";
                            }
                            else
                            {
                                player = "X";
                            }
                            if (IsFreeSpace() == false)
                            {
                                MessageBox.Show("Ничья");
                                createFiled();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool IsFreeSpace()
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j].Text == "")
                    {
                        counter++;
                    }
                }
            }
            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Bot()
        {
            Random r = new Random();
            if (field[0, 0].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[2, 2].Text == "")
            {
                field[2, 2].Text = player;
            }
            else if (field[0, 2].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[0, 2].Text == "")
            {
                field[2, 0].Text = player;
            }
            else if (field[0, 2].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[0, 2].Text == "")
            {
                field[0, 2].Text = player;
            }
            else if (field[0, 0].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[0, 0].Text == "")
            {
                field[0, 0].Text = player;
            }
            else if (field[0, 0].Text == field[1, 1].Text && field[1, 1].Text ==  "X" && field[0, 0].Text == "")
            {
                field[2, 2].Text = player;
            }
            else if (field[0, 1].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[0, 1].Text == "")
            {
                field[0, 1].Text = player;
            }
            else if (field[0, 1].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[0, 1].Text == "")
            {
                field[2, 1].Text = player;
            }
            else if (field[1, 0].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[1, 0].Text == "")
            {
                field[1, 0].Text = player;
            }
            else if (field[1, 0].Text == field[1, 1].Text && field[1, 1].Text == "X" && field[1, 0].Text == "")
            {
                field[1, 2].Text = player;
            }
            else
            {
                while(true)
                {
                    int x = r.Next(0, 3);
                    int j = r.Next(0, 3);
                    if (field[x,j].Text == "")
                    {
                        field[x, j].Text = player;
                        break;
                    }
                }
            }

            if (IsWin())
            {
                MessageBox.Show($"Выиграл игрок");
                createFiled();
                return;

            }
            else if (IsFreeSpace() == false)
            {
                MessageBox.Show("Ничья");
                createFiled();
                return;
            }
            if (player == "X")
            {
                player = "O";
            }
            else
            {
                player = "X";
            }
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createFiled();
        }
    }
}
