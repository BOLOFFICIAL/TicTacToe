using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private bool action = false;
        private int count_free = 9;
        private string winner = "НИЧЬЯ";
        private bool endgame = false;

        private int[,] points = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
        }

        private void Logic(Button button)
        {
            int number = int.Parse(button.Name.Substring(6));
            int x = (number + 2) / 3 - 1;
            int y = (number + 2) % 3;
            bool cheack;
            label1.Text = action ? "КРЕСТИК" : "НОЛИК";
            button.Text = action ? "O" : "X";
            winner = action ? "Выйграл НОЛИК" : "Выйграл КРЕСТИК";
            points[x, y] = action ? 1 : 2;
            button.BackColor = action ? Color.Green : Color.Red;
            button.Enabled = false;
            action = !action;
            count_free--;
            cheack = CheckWin();
            endgame = (count_free == 0) || cheack;
            if (count_free == 0 && cheack == false) 
            {
                winner = "НИЧЬЯ";
            }
            if (endgame)
            {
                MessageBox.Show($"{winner}", "Крестики-Нолики");
                foreach (var el in buttons)
                {
                    el.Enabled = true;
                    el.BackColor = Color.White;
                    el.Text = "";
                }
                count_free = 9;
                label1.Text = "Start";
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        points[i, j] = 0;
                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Logic((Button)sender);
        }

        private bool CheckWin() 
        {
            if (points[0, 0] == points[0, 1] && points[0, 0] == points[0, 2])
            {
                return points[0, 0] > 0;
            }
            if (points[1, 0] == points[1, 1] && points[1, 0] == points[1, 2])
            {
                return points[1, 0] > 0;
            }
            if (points[2, 0] == points[2, 1] && points[2, 0] == points[2, 2])
            {
                return points[2, 0] > 0;
            }
            if (points[0, 0] == points[1, 0] && points[0, 0] == points[2, 0])
            {
                return points[0, 0] > 0;
            }
            if (points[0, 1] == points[1, 1] && points[0, 1] == points[2, 1])
            {
                return points[0, 1] > 0;
            }
            if (points[0, 2] == points[1, 2] && points[0, 2] == points[2, 2])
            {
                return points[0, 2] > 0;
            }
            if (points[0, 0] == points[1, 1] && points[0, 0] == points[2, 2])
            {
                return points[0, 0] > 0;
            }
            if (points[2, 0] == points[1, 1] && points[2, 0] == points[0, 2])
            {
                return points[2, 0] > 0;
            }
            return false;
        }
    }
}
