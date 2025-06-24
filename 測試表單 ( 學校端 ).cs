using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Share_ClassLibrary;

namespace homework_6_1358004
{
    public partial class frm測試表單_學校端: Form
    {

        public frm測試表單_學校端()
        {
            InitializeComponent();
        }

        private void frm測試表單_學校端_Load(object sender, EventArgs e)
        {
            // 取得螢幕寬度和表單寬度
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int formWidth = this.Width;

            int x = screenWidth - formWidth - 50; ; // 靠左
            int y = 10; // 置中

            this.Location = new Point(x, y);
        }
        private void btn首頁_Click(object sender, EventArgs e)
        {
            new frm首頁_學校端().Show();
        }

        private void btn成績管理_Click(object sender, EventArgs e)
        {
            new frm成績管理_學校端().Show();
        }

        private void btn成績套用_Click(object sender, EventArgs e)
        {        
            Share.S_Grades[0, 0] = 85; // 第一個學生 第一門課
            Share.S_Grades[0, 1] = 88; //            第二門課
            Share.S_Grades[1, 0] = 78; // 第二個學生 第一門課
            Share.S_Grades[1, 1] = 90; //            第二門課
            Share.S_Ranks[0, 0] = 1;
            Share.S_Ranks[0, 1] = 2;
            Share.S_Ranks[1, 0] = 2;
            Share.S_Ranks[1, 1] = 1;
        }

        private void btn成績套用_不及格_Click(object sender, EventArgs e)
        {
            Share.S_Grades[0, 0] = 58; // 第一個學生 第一門課
            Share.S_Grades[0, 1] = 57; //            第二門課
            Share.S_Grades[1, 0] = 60; // 第二個學生 第一門課
            Share.S_Grades[1, 1] = 55; //            第二門課
            Share.S_Ranks[0, 0] = 2;
            Share.S_Ranks[0, 1] = 1;
            Share.S_Ranks[1, 0] = 1;
            Share.S_Ranks[1, 1] = 2;
        }
        private void btn還原預設_Click(object sender, EventArgs e)
        {
            // 學生 0
            Share.S_Grades[0, 0] = 0;
            Share.S_Ranks[0, 0] = 0;
            Share.S_Grades[0, 1] = 0;
            Share.S_Ranks[0, 1] = 0;
            Share.S_Mail[0] = "";

            // 學生 1
            Share.S_Grades[1, 0] = 0;
            Share.S_Ranks[1, 0] = 0;
            Share.S_Grades[1, 1] = 0;
            Share.S_Ranks[1, 1] = 0;
            Share.S_Mail[1] = "";

            MessageBox.Show("已還原為初始狀態！");
        }
    }
}
