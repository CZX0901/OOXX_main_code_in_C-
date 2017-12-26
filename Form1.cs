using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOXX
{
    public partial class Form1 : Form
    {
        bool start = false;
        int[,] array = new int[3, 3];
        string player;
        int p, which_player_counter = 0;
        int result_index = 0;
        int[] result = new int[8];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i, j;
            for(i=0;i<3;i++)
            {
                for(j=0;j<3;j++)
                {
                    array[i, j] = 0;
                }
            }
            for(i=0;i<8;i++)
            {
                result[i] = 0;
            }

            button11.BackColor = Color.Red;     //初始化O先下
            button12.BackColor = Color.White;
            player = "O";
            p = 1;

           

        }
        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if(!start)
            {
                Graphics graph = pictureBox1.CreateGraphics(); //將pictureBox1物件宣告成畫布
                Pen pen = new Pen(Color.Black, 3);
                graph.DrawLine(pen, 0, 155, 522, 155);      //畫橫線
                graph.DrawLine(pen, 0, 305, 522, 305);

                graph.DrawLine(pen, 175, 0, 175, 463);      //化縱線
                graph.DrawLine(pen, 340, 0, 340, 463);

                button1.Text = "";      //方格初始化，文字清空
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";

                start = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(start && button1.Text =="")
            {
                which();
                button1.Text = player;
                array[0, 0] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start && button2.Text == "")
            {
                which();
                button2.Text = player;
                array[0, 1] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (start && button3.Text == "")
            {
                which();
                button3.Text = player;
                array[0, 2] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (start && button4.Text == "")
            {
                which();
                button4.Text = player;
                array[1, 0] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (start && button5.Text == "")
            {
                which();
                button5.Text = player;
                array[1, 1] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (start && button6.Text == "")
            {
                which();
                button6.Text = player;
                array[1, 2] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (start && button7.Text == "")
            {
                which();
                button7.Text = player;
                array[2, 0] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (start && button8.Text == "")
            {
                which();
                button8.Text = player;
                array[2, 1] = p;
                jugde_counter();
                jugde();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (start && button9.Text == "")
            {
                which();
                button9.Text = player;
                array[2, 2] = p;
                jugde_counter();
                jugde();
            }
        }

        void jugde_counter()    //計算result裡的值，此為判斷是否連線的依據
        {
            int i, j;
            int index = 0;
            while(index != 8)
            {
                if (index >= 0 && index < 3)      //直的線 
                {
                    for(j=0;j<3;j++)
                    {
                        for(i=0;i<3;i++)
                        {
                            result[index] = result[index] + array[i, j];
                        }
                        index++;
                    }
                }
                else if (index >= 3 && index < 6)     //橫的線  
                {
                    for (i = 0; i < 3; i++)
                    {
                        for (j = 0; j < 3; j++)
                        {
                            result[index] = result[index] + array[i, j];
                        }
                        index++;
                    }
                }
                else if (index == 6)    //斜的線 左上至右下
                {
                    for(i=0;i<3;i++)
                    {
                        result[index] = result[index] + array[i, i];
                    }
                    index++;
                }
                else if (index == 7)    //斜的線 右上至左下
                {
                    for (i = 0; i < 3; i++)
                    {
                        result[index] = result[index] + array[i, 2-i];
                    }
                    index++;
                }
            }
        }
        void jugde()        //判斷是否連線，並秀出勝負提示
        {
            for(int i=0;i<8;i++)
            {
                if (result[i] == p * 3)   //player win
                {
                    MessageBox.Show(player+" win this game!!!!!", "Win", MessageBoxButtons.OK);
                    label1.Text = player + "\nis winner!!";
                    result_index = i;
                    redline();
                    break;
                }
                else//沒有連線
                {
                    int k, l, counter = 0;
                    for (k = 0; k < 3; k++)  //檢查空格是否填滿了(平手)
                    {
                        for (l = 0; l < 3; l++)
                        {
                            if (array[k, l] != 0)
                            {
                                counter++;
                            }
                        }
                    }
                    if (counter == 9)
                    {
                        MessageBox.Show("No Win No Lost try again!!", "No Win No Lost", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        reset_reslut_array(i);  //還沒有結果
                    }
                }
            }
               
        }
        

        void reset_reslut_array(int i)
        {
            result[i] = 0;
        }

        void redline() //畫線
        {      
            Graphics graph = pictureBox1.CreateGraphics(); //將pictureBox1物件宣告成畫布
            Pen pen2 = new Pen(Color.Red, 12);
            
                if(result_index == 0)
                {
                    graph.DrawLine(pen2, 85, 0, 85, 463);      //化縱線
                }
                else if(result_index == 1)
                {
                    graph.DrawLine(pen2, 260, 0, 260, 463); //化縱線
                }
                else if (result_index == 2)
                {
                    graph.DrawLine(pen2, 420, 0, 420, 463);  //化縱線
                }
                else if (result_index == 3)
                {
                    graph.DrawLine(pen2, 0, 75, 522, 75);      //畫橫線
                }
                else if (result_index == 4)
                {
                    graph.DrawLine(pen2, 0, 230, 522, 230);      //畫橫線
                }
                else if (result_index == 5)
                {
                    graph.DrawLine(pen2, 0, 380, 522, 380);     //畫橫線
                }
                else if (result_index == 6)
                {
                    graph.DrawLine(pen2, 0, 0, 522, 463); //畫斜線
                } 
                else if (result_index == 7)
                {
                    graph.DrawLine(pen2, 522, 0, 0, 463);   //畫斜線
                }
            
        }

        void which()
        {
            if (which_player_counter % 2 != 0)
            {
                button11.BackColor = Color.Red;
                button12.BackColor = Color.White;
                player = "X";
                p = 5;
            }
            else
            {
                button12.BackColor = Color.Red;
                button11.BackColor = Color.White;
                player = "O";
                p = 1;
            }
            which_player_counter++;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

    

        

    }
}
