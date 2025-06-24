using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share_ClassLibrary;

namespace homework_6_1358004
{
    public partial class frm登入_學校端: Form
    {   
        public frm登入_學校端()
        {
            InitializeComponent();
        }

        int i = 0; 
        string CAPTCHA = ""; 

        private void frm登入_學校端_Load(object sender, EventArgs e)
        { 
            panel_帳號登入.Visible = true;
            panel_確認舊密碼.Visible = false;
            panel_更改新密碼.Visible = false;

            設定畫面位置();
            產生驗證碼();
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

        private void 使用說明HToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("這是一個說明視窗。請依照指示操作～\n" + "\n" +
            "1. 請在左方輸入您的帳密以及驗證碼，\n" +
            "2. 若有更換密碼之需求，請點選「修改密碼」，\n" +
            "    並依指示進行驗證、更改。\n" + "\n" +
            "3. 若您為開發人員身分，按下 ☰ 即有「測試入口」\n" +
            "    便於測試程式時使用。\n" + "\n" + "\n" +
            "4. 最後，祝您有個美好的使用體驗。"
            , "使用說明",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn登入_Click(object sender, EventArgs e)
        {
            if (txt驗證碼.Text.ToUpper() != CAPTCHA.ToUpper())
            {
                MessageBox.Show("驗證碼輸入錯誤", "警告",MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt驗證碼.Text = "";
                產生驗證碼();
                return;
            }

            if (txt帳號.Text == "t01" && txt密碼.Text == Share.T_Passwords_array[0])
            {
 
                 new frm首頁_學校端().Show();
                 this.Close();
                
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤，請再試一次！", "警告",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn換一個_Click(object sender, EventArgs e)
        {
            產生驗證碼();
        }

        void 產生驗證碼()
        {
            if (i == 0)
            {
                CAPTCHA = "ABCD";
            }
            else if (i == 1)
            {
                CAPTCHA = "H7K3";
            }
            else if (i == 2)
            {
                CAPTCHA = "X9LM";
            }
            else if (i == 3)
            {
                CAPTCHA = "2PQR";
            }
               
            lbl驗證碼.Text = CAPTCHA;

            i++;
            if (i > 3)
            {
                i = 0;
            }
        }

        private void btn修改密碼_Click(object sender, EventArgs e)
        {
            panel_帳號登入.Visible = true;
            panel_確認舊密碼.Visible = true;
            panel_更改新密碼.Visible = false;
        }

        private void btn確定_Click_1(object sender, EventArgs e)
        {

            if (txt舊密碼.Text == Share.T_Passwords_array[0])
            {
                panel_帳號登入.Visible = true;
                panel_確認舊密碼.Visible = false;
                panel_更改新密碼.Visible = true;
            }
            else
            {
                MessageBox.Show("舊密碼錯誤！", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt舊密碼.Text = "";
            }
        }
        private void btn取消修改_Click(object sender, EventArgs e)
        {
            panel_帳號登入.Visible = true;
            panel_確認舊密碼.Visible = false;
            panel_更改新密碼.Visible = false;
        }

        private void btn完成_Click(object sender, EventArgs e)
        {
            if ((txt新密碼.Text == txt再一次.Text)&&(!string.IsNullOrEmpty(txt新密碼.Text)))
            {
                Share.T_Passwords_array[0] = txt新密碼.Text;

                MessageBox.Show("密碼修改成功！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                panel_帳號登入.Visible = true;
                panel_確認舊密碼.Visible = false;
                panel_更改新密碼.Visible = false;

            }
            else if (string.IsNullOrEmpty(txt新密碼.Text))
            {
                MessageBox.Show("密碼不可輸入空白！", "警告",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt再一次.Text = "";
                txt再一次.Focus();
            }
            else
            {
                MessageBox.Show("輸入的密碼不一致，請再試一次！", "警告",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt再一次.Text = "";
                txt再一次.Focus();
            }
        }

        private void 測試入口TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm測試表單_學校端().Show();
            this.Close();
        }
    }
}
