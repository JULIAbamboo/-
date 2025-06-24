using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share_ClassLibrary;

namespace homework_6_1358004
{
    public partial class frm首頁_學校端: Form
    {
        public frm首頁_學校端()
        {
            InitializeComponent();
        }
        private void frm首頁_學校端_Load(object sender, EventArgs e)
        {
            設定畫面位置();

            MessageBox.Show("歡迎使用本成績登記系統\n，請先至左側選單選擇課程", "提示",
             MessageBoxButtons.OK, MessageBoxIcon.Information);

            pictureBox.BackgroundImage = Image.FromFile("teacher.png");
           
            
        }

        private void 設定畫面位置()
        {
            this.StartPosition = FormStartPosition.Manual;

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int formWidth = this.Width;
            int formHeight = this.Height;

            int x = (screenWidth / 2) + 210; 
            int y = (screenHeight - formHeight) / 2;

            this.Location = new Point(x, y);
        }

        private void toolStripMenuItem三條橫線_Click(object sender, EventArgs e)
        {
            if (panel_首頁資料.Visible == true)
            {
                panel_首頁資料.Visible = false;  // 如果目前是顯示，就隱藏    
            }  
            else
            {
                panel_首頁資料.Visible = true;   // 如果目前是隱藏，就顯示
            }
        }

        //背景顏色-----------------------------------------
        private void 藍色BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void 紅色RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor=Color.SeaShell;
        }

        private void 綠色GToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this. BackColor = Color.MintCream;
        }

        private void 預設PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        //-------------------------------------------------------

        private void 說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm首頁使用說明_學校端().Show();
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm登入_學校端().Show();
            this.Close();
        }

        private void comboBox選擇課程_SelectedIndexChanged(object sender, EventArgs e)
        {
            Share.T_Selected_Course = comboBox選擇課程.SelectedItem.ToString();

            更新總表一覽();
        }

        private void btn刷新資料_Click(object sender, EventArgs e)
        {
            更新總表一覽();
        }

        public void 更新總表一覽()
        {
            dataGridView總表一覽.Rows.Clear();

            double grade0 = Share.S_Grades[0, comboBox選擇課程.SelectedIndex]; //學生甲成績
            double grade1 = Share.S_Grades[1, comboBox選擇課程.SelectedIndex]; //學生乙成績

            dataGridView總表一覽.Rows.Add("學生甲", "1x58060", grade0.ToString("F1"));
            dataGridView總表一覽.Rows.Add("學生乙", "13580xx", grade1.ToString("F1"));

            double average = (grade0 + grade1) / 2;
            double max = 0, min = 0;

            if (grade0 > grade1)
            {
                max = grade0;
                min = grade1;
            }
            else if (grade1 > grade0)
            {
                max = grade1;
                min = grade0;
            }
            else
            {
                max = grade1;
                max = grade1;
            }

            lbl平均.Text = average.ToString("F1");
            lbl最高分.Text = max.ToString("F1");
            lbl最低分.Text = min.ToString("F1");
        }

        private void btn成績管理_Click(object sender, EventArgs e)
        {
            new frm成績管理_學校端().Show();
        }

        private void btn發布公告_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Share.T_Selected_Course))
            {
                MessageBox.Show("請先選擇課程", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string course = Share.T_Selected_Course; 

            for (int i = 0; i < 2; i++) // 兩個學生
            {
                for (int j = 0; j < 2; j++) // 每人兩門課
                {
                    if (Share.S_Courses[i, j] == course)
                    {
                        double grade = Share.S_Grades[i, j];

                        if (grade < 60)
                        {
                            Share.T_Mail_Course[i, j] = course + " 總成績不及格!";
                        }
                        else
                        {
                            Share.T_Mail_Course[i, j] = " ";
                        }
                    }
                }
            }
            // 收集目前所有課程的通知，存入 Share.S_Mail
            for (int i = 0; i < 2; i++) //兩位學生
            {
                string mail = ""; //裝學生通知內容

                for (int j = 0; j < 2; j++)
                {
                    if (!string.IsNullOrWhiteSpace(Share.T_Mail_Course[i, j]))
                    {
                        mail += Share.T_Mail_Course[i, j] + "\n"; // 如果有內容就放進MAIL
                    }
                }

                if (!string.IsNullOrWhiteSpace(mail))
                {
                    Share.S_Mail[i] = mail; // 給學生的通知
                }
                else
                {
                    Share.S_Mail[i] = "目前無預警通知。"; // 無預警
                }
            }
    
                MessageBox.Show("成績預警已成功發布至相關學生端。", "提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn成績計算_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Share.T_Selected_Course))
            {
                MessageBox.Show("請先選擇課程", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panel_成績表.Visible = true;
        }
    }
}
