using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework_6_1358004;
using Share_ClassLibrary;

namespace t2_Grade_ClientApp
{
    public partial class frm啟動: Form
    {
        public frm啟動()
        {
            InitializeComponent();
        }

        private void 啟動_Load(object sender, EventArgs e)
        {
            Share.設定預設資料();

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int x = (screenWidth - this.Width)  / 2 , y = (screenHeight - this.Height) / 2;  
            this.Location = new Point(x, y);         
        }

        private void btn學校端_Click(object sender, EventArgs e)
        {
            new frm登入_學校端().Show(); 
        }

        private void btn學生端_Click(object sender, EventArgs e)
        {
            new frm登入_學生端().Show();             
        }

        private void frm啟動_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("感謝您的使用，期待下次再見!\n\n.NET程式設計第二組 全體敬上。"
                   , "提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
