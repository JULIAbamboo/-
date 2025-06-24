using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share_ClassLibrary;


namespace t2_Grade_ClientApp
{
    public partial class frm首頁_學生端: Form
    {
        public frm首頁_學生端()
        {
            InitializeComponent();
        }

        private void frm進入_學生端_Load(object sender, EventArgs e)
        {
            timer時間.Start();
            lbl上次.Text = System.IO.File.ReadAllText("last_login.txt");

            設定畫面位置();
            更新預警();

            if (Share.LoginIndex == 0) // 學生 0
            {
                lbl姓名_個人資料.Text += " "+"學生甲";
                lbl學號_個人資料.Text += " " + "1x58060";
                pictureBox1.Image = Image.FromFile("student0.png");
                lbl歡迎.Text += "學生甲";
            }
            else if (Share.LoginIndex == 1) // 學生 1
            {
                lbl姓名_個人資料.Text += " " + "學生乙";
                lbl學號_個人資料.Text += " " + "13580xx";
                pictureBox1.Image = Image.FromFile("student1.png");
                lbl歡迎.Text += "學生乙";
            }
        }

        private void 設定畫面位置()
        {
            this.StartPosition = FormStartPosition.Manual;

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int x = (screenWidth / 2) - this.Width - 210; 
            int y = (screenHeight - this.Height) / 2;

            this.Location = new Point(x, y);
        }

        private void timer時間_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            lbl當前時間.Text = dateTime.ToString();
        }

        private void btn重新載入_Click(object sender, EventArgs e)
        {
            更新預警();
        }

        private void 更新預警()
        {
            string fail_mail = Share.S_Mail[Share.LoginIndex];//fail_mail:通知內容
            //取出目前登入的學生對應的通知內容

            if (!string.IsNullOrWhiteSpace(fail_mail))
            {
                txt公告.Text = fail_mail;
                //若內容不為空白，表示老師有發送預警通知
            }
            else
            {
                txt公告.Text = "✅ 沒有任何成績預警通知";
            }
        }

        private void btn課程1_Click_1(object sender, EventArgs e)
        {
            new frm網頁設計().Show();
        }

        private void btn課程2_Click_1(object sender, EventArgs e)
        {
            new frm作業系統().Show();
        }

        private void btn登出_Click(object sender, EventArgs e)
        {
            new frm登入_學生端().Show();
            this.Close();
        }
    }
}
