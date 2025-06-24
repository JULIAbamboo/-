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

namespace t2_Grade_ClientApp
{
    public partial class frm網頁設計: Form
    {
        public frm網頁設計()
        {
            InitializeComponent();
            SidePanel.Height = btn成績查看.Height;
            SidePanel.Top = btn成績查看.Top;
            courseDescription1.Visible = false;
        }

        private void frm第一門課程_Activated(object sender, EventArgs e)
        {
            顯示成績與統計("網頁設計");
        }


        private void 顯示成績與統計(string 課程名稱)
        {
            if ((Share.S_Grades[Share.LoginIndex, 0]) != 0)
            {
                lbl無成績.Visible = false;
                lbl1.Visible = true;
                lbl3.Visible = true;
                lbl4.Visible = true;
                lbl5.Visible = true;

                lbl最高分.Visible = true;
                lbl最低分.Visible = true;
                lbl平均分.Visible = true;
                lbl總成績.Visible = true;
                lbl排名.Visible = true;

                if ((Share.S_Grades[Share.LoginIndex, 0]) < 60)
                {
                    lbl總成績.ForeColor = Color.Red;
                    lbl總成績.Text = (Share.S_Grades[Share.LoginIndex, 0]).ToString("F1");
                }
                else
                {
                    lbl總成績.ForeColor = Color.Black;
                    lbl總成績.Text = (Share.S_Grades[Share.LoginIndex, 0]).ToString("F1");                
                }

                lbl排名.Text = "第 " + (Share.S_Ranks[Share.LoginIndex, 0]) + " 名";

                double total = 0, max = 0, min = 100;


                for (int i = 0; i < 2; i++) //迴圈跑兩次，依序取出兩位學生的第一門課成績
                {
                    double grade = Share.S_Grades[i, 0]; 
                    total += grade;

                    if (grade > max) max = grade;
                    if (grade < min) min = grade;
                }

                double average = total / 2;
                lbl平均分.Text = average.ToString("F1");
                lbl最高分.Text = max.ToString("F1");
                lbl最低分.Text = min.ToString("F1");
            }
            else
            {
                lbl無成績.Visible = true;
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                lbl4.Visible = false;
                lbl5.Visible = false;

                lbl最高分.Visible = false;
                lbl最低分.Visible = false;
                lbl平均分.Visible = false;
                lbl總成績.Visible = false;
                lbl排名.Visible = false;      
            }        
        }

        private void btn課程首頁_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn成績查看.Height;
            SidePanel.Top = btn成績查看.Top;
            if (courseDescription1.Visible)
                courseDescription1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            courseDescription1.Visible = true;
            courseDescription1.BringToFront();
        }
    }
}
