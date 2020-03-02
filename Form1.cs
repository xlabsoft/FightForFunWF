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
        Obstacle obs;
        Board board;
        
        Button[,] buttons = new Button[Board.boardSize, Board.boardSize];
        int top = 2;
        int left = 2;
        int buttonSize = 64;
        Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            Board.winterIsComing = RandomBool();
            panelMain.Width = 768;
            panelMain.Height = 768;

            for (int i = 0; i < Board.boardSize; i++)
            {
                for (int j = 0; j < Board.boardSize; j++)
                {
                    Button btn = new Button();
                    float new_size = 11.0f;
                    btn.Font = new Font(btn.Font.FontFamily, new_size, btn.Font.Style);

                    int value = GenerateRandomDigit(rnd);
                    btn.Text = value.ToString();
                    btn.Text = String.Empty;
                    btn.Tag = $"[{i},{j}]";
                    btn.Location = new Point(top, left);
                    btn.Top = top;
                    btn.Left = left;
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.BackColor = value < 0 ? Color.Coral : Color.Aqua;
                    btn.BackColor = Board.winterIsComing ? Color.White : Color.Green;
                    buttons[i, j] = btn;
                    buttons[i, j].Click += btns_Click;
                    panelMain.Controls.Add(buttons[i, j]);
                    top += btn.Height;// + 1;
                    if (j == Board.boardSize - 1)
                    {
                        left += buttonSize;
                        top = 2;
                    }
                }
            }
            Restart();
        }

        public void Restart(){
            Board.SetStartPosition();
            Board.BoardInit();
            SetAllUnits();
        }

        private void SetAllUnits()
        {
            for (int i = 0; i < Board.boardSize; i++)
            {
                for (int j = 0; j < Board.boardSize; j++)
                {
                    SetUnitAt(i, j);
                }
            }
        }
        public void SetUnitAt(int i, int j){
            buttons[i, j].BackgroundImage = GetUnitAt(i, j);
            buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
        }

        private Image GetUnitAt(int i, int j)
        {
            Image currentUnit = Properties.Resources.ground;
            switch (Board.gameField[i, j])
            {
                case 'P':
                    currentUnit = Properties.Resources.BlueInfantry;
                    break;
                case 'p':
                    currentUnit = Properties.Resources.RedInfantry;
                    break;
                case 'N':
                    currentUnit = Properties.Resources.BlueCavalry;
                    break;
                case 'n':
                    currentUnit = Properties.Resources.RedCavalry;
                    break;
                case 'T':
                    currentUnit = Properties.Resources.BlueTank;
                    break;
                case 't':
                    currentUnit = Properties.Resources.RedTank;
                    break;
                case 'A':
                    currentUnit = Properties.Resources.BlueArtillery;
                    break;
                case 'a':
                    currentUnit = Properties.Resources.RedArtillery;
                    break;
                case 'K':
                    currentUnit = Properties.Resources.BlueKing;
                    break;
                case 'k':
                    currentUnit = Properties.Resources.RedKing;
                    break;
                case '0':
                    currentUnit = Properties.Resources.ground;
                    break;
                case '1':
                    currentUnit = Properties.Resources.forest;
                    break;
                case '2':
                    if (Board.winterIsComing)
                    {
                        currentUnit = Properties.Resources.iceblock;
                    }
                    else
                    {
                        currentUnit = Properties.Resources.river;
                    }
                    break;
                case '3':
                    if (Board.winterIsComing)
                    {
                        currentUnit = Properties.Resources.swamp;
                    }
                    else
                    {
                        currentUnit = Properties.Resources.sand;
                    }
                    break;
                case '4':
                    currentUnit = Properties.Resources.bomb;
                    break;
                case '5':
                    currentUnit = Properties.Resources.barbware;
                    break;
            }
            return currentUnit;
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
            Button button = sender as Button;            
            btn_Restart.Text = button.Tag.ToString();
            //btn_Restart.Text = $"X{MousePosition.X.ToString()}, Y{MousePosition.Y.ToString()}";
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
