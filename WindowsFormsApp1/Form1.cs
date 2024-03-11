using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button[,] field;
        string player;
        public Form1()
        {
            InitializeComponent();
        }
        public void createField()
        {
            Random rand = new Random();

            if(rand.Next(0,2) == 0)
            {
                player = "O";
            }
            else
            {
                player = "X";
            }
            
            



        }
    }
}
