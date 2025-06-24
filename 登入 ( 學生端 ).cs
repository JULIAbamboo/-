using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework_6_1358004;
using Share_ClassLibrary;

namespace t2_Grade_ClientApp
{
    public partial class frm登入_學生端: Form
    {
        public frm登入_學生端()
        {
            InitializeComponent();
        }

        private void frm登入_Load(object sender, EventArgs e)
        { 
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int x = (screenWidth / 2) - this.Width - 210; //置中往左移
            int y = (screenHeight - this.Height) / 2;

            this.Location = new Point(x, y);
        }


        private void 使用說明HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("這是一個說明視窗。請依照指示操作～\n" + "\n" +
            "1. 請在左方輸入您的帳號密碼，若輸入正確，\n" +
            "    按下「登入」即可進入首頁。\n" + "\n" +
            "2. 若您為開發人員身分，按下 ☰ 即有「測試入口」，\n" +
            "    便於測試程式時使用。\n"
            , "使用說明",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 測試ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm測試表單_學生端().Show();
            this.Close();
        }

        private void btn登入_Click_1(object sender, EventArgs e)
        {
            string a = txt帳號.Text;
            string p = txt密碼.Text;

            // 學生甲：1158060 或 1258060，密碼是 "060"
            if (a == "1158060" || a == "1258060")
            {
                if (p == "060")
                {
                    Share.LoginIndex = 0; // 學生甲
                    登入成功並開啟首頁();
                }
                else
                {
                    MessageBox.Show("錯誤，請再次檢查輸入", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 學生乙：1358004、1358016、1358030，密碼是學號最後三碼
                if (a == "1358004" && p == "004")
                {
                    Share.LoginIndex = 1; // 學生乙
                    登入成功並開啟首頁();
                }
                else if(a == "1358016" && p == "016")
                {
                    Share.LoginIndex = 1; 
                    登入成功並開啟首頁();

                }
                else if(a == "1358030" && p == "030")
                {
                    Share.LoginIndex = 1; 
                    登入成功並開啟首頁();
                }
                else
                {
                    MessageBox.Show("錯誤，請再次檢查輸入", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void 登入成功並開啟首頁()
        {
            DateTime dateTime= DateTime.Now; //c#內建的資料型別，用來表示「日期和時間」
            System.IO.File.WriteAllText("last_login.txt", dateTime.ToString());

            //.ToString(): 2025/06/15 13:32:28
            //.ToShortDateString(): 6/15/2025
            //.ToShortTimeString(): 1:32 PM...

            new frm首頁_學生端().Show();
            this.Close();
        }
    }
}
