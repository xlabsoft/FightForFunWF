using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightForFunWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Form1.Location = new Point(10, 10);
            
        }

        public static bool winterIsComing = false;
        public static int size = 15; // fieldSize
        public static char [,] board = new char[size, size];
        Button[,] buttons = new Button[size, size];
        int top = 2;
        int left = 2;
        int buttonSize = 47;
        Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            winterIsComing = RandomBool();
            panelMain.Width = 768;
            panelMain.Height = 768;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Button btn = new Button();
                    float new_size = 11.0f;
                    btn.Font = new Font(btn.Font.FontFamily, new_size, btn.Font.Style);

                    int value = GenerateRandomDigit(rnd);
                    btn.Text = value.ToString();
                    btn.Text = String.Empty;
                    btn.Tag = "btn" + i.ToString() + j.ToString();
                    btn.Location = new Point(top, left);
                    btn.Top = top;
                    btn.Left = left;
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.BackColor = value < 0 ? Color.Coral : Color.Aqua;
                    btn.BackColor = winterIsComing ? Color.White : Color.Green;
                    buttons[i, j] = btn;
                    buttons[i, j].Click += btns_Click;
                    panelMain.Controls.Add(buttons[i, j]);
                    top += btn.Height;// + 1;
                    if (j == size - 1)
                    {
                        left += buttonSize;
                        top = 2;
                    }
                }
            }

            
            BoardInit(); // unit & obstacles image
        }

        private void SetObstacles()
        {
            Image water;
            Image earth;
            if (winterIsComing)
            {
                water = Properties.Resources.iceblock;
                earth = Properties.Resources.swamp;
            } else
            {
                water = Properties.Resources.river;
                earth = Properties.Resources.sand;
            }
            buttons[0, 3].Image = water;
            buttons[0, 11].Image = earth;
        }

        private void SetUnits()
        {
            buttons[0, 0].Image = Properties.Resources.BlueTank;
            buttons[0, 1].Image = Properties.Resources.BlueTank;
            buttons[14, 0].Image = Properties.Resources.BlueTank;
            buttons[14, 1].Image = Properties.Resources.BlueTank;

            buttons[2, 0].Image = Properties.Resources.BlueInfantry;
            buttons[2, 1].Image = Properties.Resources.BlueInfantry;
            buttons[3, 0].Image = Properties.Resources.BlueInfantry;
            buttons[3, 1].Image = Properties.Resources.BlueInfantry;

            buttons[12, 0].Image = Properties.Resources.BlueInfantry;
            buttons[12, 1].Image = Properties.Resources.BlueInfantry;
            buttons[11, 0].Image = Properties.Resources.BlueInfantry;
            buttons[11, 1].Image = Properties.Resources.BlueInfantry;

            buttons[5, 0].Image = Properties.Resources.BlueCavalry;
            buttons[5, 1].Image = Properties.Resources.BlueCavalry;
            buttons[6, 1].Image = Properties.Resources.BlueCavalry;

            buttons[9, 0].Image = Properties.Resources.BlueCavalry;
            buttons[9, 1].Image = Properties.Resources.BlueCavalry;
            buttons[8, 1].Image = Properties.Resources.BlueCavalry;

            buttons[6, 0].Image = Properties.Resources.BlueArtillery;
            buttons[7, 1].Image = Properties.Resources.BlueArtillery;
            buttons[8, 0].Image = Properties.Resources.BlueArtillery;

            buttons[7, 0].Image = Properties.Resources.BlueKing;

            buttons[0, 14].Image = Properties.Resources.RedTank;
            buttons[0, 13].Image = Properties.Resources.RedTank;
            buttons[14, 14].Image = Properties.Resources.RedTank;
            buttons[14, 13].Image = Properties.Resources.RedTank;

            buttons[2, 14].Image = Properties.Resources.RedInfantry;
            buttons[2, 13].Image = Properties.Resources.RedInfantry;
            buttons[3, 14].Image = Properties.Resources.RedInfantry;
            buttons[3, 13].Image = Properties.Resources.RedInfantry;

            buttons[12, 14].Image = Properties.Resources.RedInfantry;
            buttons[12, 13].Image = Properties.Resources.RedInfantry;
            buttons[11, 14].Image = Properties.Resources.RedInfantry;
            buttons[11, 13].Image = Properties.Resources.RedInfantry;

            buttons[5, 14].Image = Properties.Resources.RedCavalry;
            buttons[5, 13].Image = Properties.Resources.RedCavalry;
            buttons[6, 13].Image = Properties.Resources.RedCavalry;

            buttons[9, 14].Image = Properties.Resources.RedCavalry;
            buttons[9, 13].Image = Properties.Resources.RedCavalry;
            buttons[8, 13].Image = Properties.Resources.RedCavalry;

            buttons[6, 14].Image = Properties.Resources.RedArtillery;
            buttons[7, 13].Image = Properties.Resources.RedArtillery;
            buttons[8, 14].Image = Properties.Resources.RedArtillery;

            buttons[7, 14].Image = Properties.Resources.RedKing;
        }

        private void BoardInit()
        {
            SetObstacles();
            SetUnits();
        }

        private int GenerateRandomDigit(Random rng)
        {
            return rng.Next(100) - 50;
        }

        bool RandomBool()
        {
            return rnd.Next(2) == 1;
        }

        private void btns_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
