using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Color> colors = new List<Color>() { Color.FromArgb(204, 192, 179), Color.FromArgb(238, 228, 218), Color.FromArgb(237, 224, 200),
        Color.FromArgb(242, 177, 121), Color.FromArgb(245, 149, 99), Color.FromArgb(246, 124, 95), Color.FromArgb(246, 94, 59), Color.FromArgb(237, 207, 114),
        Color.FromArgb(237, 204, 97), Color.FromArgb(237, 200, 80), Color.FromArgb(237, 197, 63), Color.FromArgb(237, 194, 46) };

        public bool start = false;
        int attemp = 0; int postScore = 0;

        public void button1_Click(object sender, EventArgs e)
        {
            GameStart();
        }

        public void GameStart()
        {
            start = true;
            List<Label> labels = new List<Label>() { label1, label2, label3, label4, label5, label6,
            label7, label8, label9, label10, label11, label12, label13, label14, label15, label16 };

            for (int i = 0; i <= 15; i++)
            {
                labels[i].Text = "";
                Colors(i);
            }

            Random rnd = new Random();
            int start1 = rnd.Next(0, 16);
            int start2 = rnd.Next(0, 16);
            while (start1 == start2) { start2 = rnd.Next(0, 16); };

            labels[start1].Text = "2"; Colors(start1);
            labels[start2].Text = "2"; Colors(start2);
        }

        public void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (start == true)
            {
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.NumPad8) { Logic("Up"); }
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.NumPad2) { Logic("Down"); }
                else if (e.KeyCode == Keys.A || e.KeyCode == Keys.NumPad4) { Logic("Left"); }
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.NumPad6) { Logic("Right"); }
            }
        }

        public void Logic(string DirectionOfMove)
        {
            List<Label> labels = new List<Label>() { label1, label2, label3, label4, label5, label6,
            label7, label8, label9, label10, label11, label12, label13, label14, label15, label16 };

            List<Label> refrMatch = new List<Label>() { };
            List<Label> refrUnmatch = new List<Label>() { };

            int dynnum1 = 0; int dynnum2 = 0; int Score = 0;
            bool flag1 = false; bool flag2 = false; bool flag3 = false;

            if (DirectionOfMove == "Up")
            {
                for (int x = 0; x <= 3; x++)
                {
                    for (int y = 0; y <= 3; y++)
                    {
                        if (labels[x].Text == "" && labels[x + 4].Text != "")
                        {
                            labels[x].Text = labels[x + 4].Text;
                            labels[x + 4].Text = "";
                            Colors(x); Colors(x + 4);
                        }
                        if (labels[x + 4].Text == "" && labels[x + 8].Text != "")
                        {
                            labels[x + 4].Text = labels[x + 8].Text;
                            labels[x + 8].Text = "";
                            Colors(x + 4); Colors(x + 8);
                        }
                        if (labels[x + 8].Text == "" && labels[x + 12].Text != "")
                        {
                            labels[x + 8].Text = labels[x + 12].Text;
                            labels[x + 12].Text = "";
                            Colors(x + 8); Colors(x + 12);
                        }
                        if (labels[x].Text == labels[x + 4].Text && labels[x].Text != "" && labels[x + 4].Text != "")
                        {
                            if (flag1 == false)
                            { 
                                dynnum1 = Int32.Parse(labels[x].Text); dynnum2 = Int32.Parse(labels[x + 4].Text);
                                labels[x + 4].Text = "";
                                labels[x].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x); Colors(x + 4);
                                flag1 = true;
                            }
                        }
                        if (labels[x + 4].Text == labels[x + 8].Text && labels[x + 4].Text != "" && labels[x + 8].Text != "")
                        {
                            if (flag2 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x + 4].Text); dynnum2 = Int32.Parse(labels[x + 8].Text);
                                labels[x + 8].Text = "";
                                labels[x + 4].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x + 4); Colors(x + 8);
                                flag2 = true;
                            }
                        }
                        if (labels[x + 12].Text == labels[x + 8].Text && labels[x + 12].Text != "" && labels[x + 8].Text != "")
                        {
                            if (flag3 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x + 12].Text); dynnum2 = Int32.Parse(labels[x + 8].Text);
                                labels[x + 8].Text = "";
                                labels[x + 12].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x + 12); Colors(x + 8);
                                flag3 = true;
                            }
                        }
                    }
                }
            }

            if (DirectionOfMove == "Down")
            {
                for (int x = 12; x <= 15; x++)
                {
                    for (int y = 12; y <= 15; y++)
                    {
                        if (labels[x].Text == "" && labels[x - 4].Text != "")
                        {
                            labels[x].Text = labels[x - 4].Text;
                            labels[x - 4].Text = "";
                            Colors(x); Colors(x - 4);
                        }
                        if (labels[x - 4].Text == "" && labels[x - 8].Text != "")
                        {
                            labels[x - 4].Text = labels[x - 8].Text;
                            labels[x - 8].Text = "";
                            Colors(x - 4); Colors(x - 8);
                        }
                        if (labels[x - 8].Text == "" && labels[x - 12].Text != "")
                        {
                            labels[x - 8].Text = labels[x - 12].Text;
                            labels[x - 12].Text = "";
                            Colors(x - 8); Colors(x - 12);
                        }
                        if (labels[x].Text == labels[x - 4].Text && labels[x].Text != "" && labels[x - 4].Text != "")
                        {
                            if (flag1 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x].Text); dynnum2 = Int32.Parse(labels[x - 4].Text);
                                labels[x - 4].Text = "";
                                labels[x].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x); Colors(x - 4);
                                flag1 = true;
                            }
                        }
                        if (labels[x - 4].Text == labels[x - 8].Text && labels[x - 4].Text != "" && labels[x - 8].Text != "")
                        {
                            if (flag2 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x - 4].Text); dynnum2 = Int32.Parse(labels[x - 8].Text);
                                labels[x - 8].Text = "";
                                labels[x - 4].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x - 4); Colors(x - 8);
                                flag2 = true;
                            }
                        }
                        if (labels[x - 12].Text == labels[x - 8].Text && labels[x - 12].Text != "" && labels[x - 8].Text != "")
                        {
                            if (flag3 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x - 12].Text); dynnum2 = Int32.Parse(labels[x - 8].Text);
                                labels[x - 8].Text = "";
                                labels[x - 12].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x - 12); Colors(x - 8);
                                flag3 = true;
                            }
                        }
                    }
                }
            }

            if (DirectionOfMove == "Left")
            {
                int x = 3;
                for (int x1 = 0; x1 <= 3; x1++)
                {
                    for (int y1 = 0; y1 <= 3; y1++)
                    {
                        if (labels[x - 1].Text == "" && labels[x].Text != "")
                        {
                            labels[x - 1].Text = labels[x].Text;
                            labels[x].Text = "";
                            Colors(x); Colors(x - 1);
                        }
                        if (labels[x - 2].Text == "" && labels[x - 1].Text != "")
                        {
                            labels[x - 2].Text = labels[x - 1].Text;
                            labels[x - 1].Text = "";
                            Colors(x - 1); Colors(x - 2);
                        }
                        if (labels[x - 3].Text == "" && labels[x - 2].Text != "")
                        {
                            labels[x - 3].Text = labels[x - 2].Text;
                            labels[x - 2].Text = "";
                            Colors(x - 2); Colors(x - 3);
                        }
                        if (labels[x].Text == labels[x - 1].Text && labels[x].Text != "" && labels[x - 1].Text != "")
                        {
                            if (flag1 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x].Text); dynnum2 = Int32.Parse(labels[x - 1].Text);
                                labels[x].Text = "";
                                labels[x - 1].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x); Colors(x - 1);
                                flag1 = true;
                            }
                        }
                        if (labels[x - 1].Text == labels[x - 2].Text && labels[x - 1].Text != "" && labels[x - 2].Text != "")
                        {
                            if (flag2 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x - 1].Text); dynnum2 = Int32.Parse(labels[x - 2].Text);
                                labels[x - 1].Text = "";
                                labels[x - 2].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x - 1); Colors(x - 2);
                                flag2 = true;
                            }
                        }
                        if (labels[x - 3].Text == labels[x - 2].Text && labels[x - 3].Text != "" && labels[x - 2].Text != "")
                        {
                            if (flag3 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x - 3].Text); dynnum2 = Int32.Parse(labels[x - 2].Text);
                                labels[x - 3].Text = "";
                                labels[x - 2].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x - 3); Colors(x - 2);
                                flag3 = true;
                            }
                        }
                    }
                    x = x + 4;
                }
            }

            if (DirectionOfMove == "Right")
            {
                int x = 0;
                for (int x1 = 0; x1 <= 3; x1++)
                {
                    for (int y1 = 0; y1 <= 3; y1++)
                    {
                        if (labels[x + 1].Text == "" && labels[x].Text != "")
                        {
                            labels[x + 1].Text = labels[x].Text;
                            labels[x].Text = "";
                            Colors(x); Colors(x + 1);
                        }
                        if (labels[x + 2].Text == "" && labels[x + 1].Text != "")
                        {
                            labels[x + 2].Text = labels[x + 1].Text;
                            labels[x + 1].Text = "";
                            Colors(x + 1); Colors(x + 2);
                        }
                        if (labels[x + 3].Text == "" && labels[x + 2].Text != "")
                        {
                            labels[x + 3].Text = labels[x + 2].Text;
                            labels[x + 2].Text = "";
                            Colors(x + 2); Colors(x + 3);
                        }
                        if (labels[x].Text == labels[x + 1].Text && labels[x].Text != "" && labels[x + 1].Text != "")
                        {
                            if (flag1 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x].Text); dynnum2 = Int32.Parse(labels[x + 1].Text);
                                labels[x].Text = "";
                                labels[x + 1].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x); Colors(x + 1);
                                flag1 = true;
                            }
                        }
                        if (labels[x + 1].Text == labels[x + 2].Text && labels[x + 1].Text != "" && labels[x + 2].Text != "")
                        {
                            if (flag2 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x + 1].Text); dynnum2 = Int32.Parse(labels[x + 2].Text);
                                labels[x + 1].Text = "";
                                labels[x + 2].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x + 1); Colors(x + 2);
                                flag2 = true;
                            }
                        }
                        if (labels[x + 3].Text == labels[x + 2].Text && labels[x + 3].Text != "" && labels[x + 2].Text != "")
                        {
                            if (flag3 == false)
                            {
                                dynnum1 = Int32.Parse(labels[x + 3].Text); dynnum2 = Int32.Parse(labels[x + 2].Text);
                                labels[x + 3].Text = "";
                                labels[x + 2].Text = (dynnum1 + dynnum2).ToString();
                                Colors(x + 3); Colors(x + 2);
                                flag3 = true;
                            }
                        }
                    }
                    x = x + 4;
                }
            }

            for (int i = 0; i <= 15; i++) { if (labels[i].Text != "") { refrMatch.Add(labels[i]); } }
            for (int i = 0; i <= 15; i++) { if (labels[i].Text == "") { refrUnmatch.Add(labels[i]); } }

            NewNum(refrUnmatch, labels, Score);

            for (int num = 0; num <= 15; num++) { if (labels[num].Text != "") { Score = Score + Int32.Parse(labels[num].Text); } }
            label_score.Text = Score.ToString();

            refrUnmatch.Clear(); refrMatch.Clear();
        }

        public void NewNum(List<Label> Unmatched, List<Label> labels, int Score)
        {
            // Добавить проверку на доступность заполнения поля
            if (Unmatched.Count != 0)
            {
                int position = 0;
                Random randpos = new Random();
                position = randpos.Next(Unmatched.Count - 1);
                Unmatched[position].Text = "2";
                Unmatched[position].BackColor = Color.FromArgb(238, 228, 218);
                Unmatched.Clear();
            }
            else if (postScore == Score)
            {
                attemp = attemp + 1;
            }
            postScore = Score;
            if (attemp == 4)
            {
                DialogResult result = MessageBox.Show("У вас закончились ходы.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK) { GameStart(); }
                attemp = 0;
            }
        }

        public void Colors(int lblnum)
        {
            List<Label> labels = new List<Label>() { label1, label2, label3, label4, label5, label6,
            label7, label8, label9, label10, label11, label12, label13, label14, label15, label16 };
            int num = 0;
            if (labels[lblnum].Text == "") { num = 0; }
            else { num = Int32.Parse(labels[lblnum].Text); }
            switch(num)
            {
                case 2: labels[lblnum].BackColor = Color.FromArgb(238, 228, 218); break;
                case 4: labels[lblnum].BackColor = Color.FromArgb(237, 224, 200); break;
                case 8: labels[lblnum].BackColor = Color.FromArgb(242, 177, 121); break;
                case 16: labels[lblnum].BackColor = Color.FromArgb(245, 149, 99); break;
                case 32: labels[lblnum].BackColor = Color.FromArgb(246, 124, 95); break;
                case 64: labels[lblnum].BackColor = Color.FromArgb(246, 94, 59); break;
                case 128: labels[lblnum].BackColor = Color.FromArgb(237, 207, 114); break;
                case 256: labels[lblnum].BackColor = Color.FromArgb(237, 204, 97); break;
                case 512: labels[lblnum].BackColor = Color.FromArgb(237, 200, 80); break;
                case 1024: labels[lblnum].BackColor = Color.FromArgb(237, 197, 63); break;
                case 2048: labels[lblnum].BackColor = Color.FromArgb(237, 194, 46); break;
                case 0: labels[lblnum].BackColor = Color.FromArgb(204, 192, 179); break;
            }
        }
    }
}
