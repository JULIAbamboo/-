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
    public partial class frm作業系統: Form
    {
        public frm作業系統()
        {
            InitializeComponent();
            SidePanel.Height = btn成績查看.Height;
            SidePanel.Top = btn成績查看.Top;
            courseDescription21.Visible = false;
        }

        private void frm第二門課程_Activated(object sender, EventArgs e)
        {
            顯示成績與統計("第二門課程");
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

                if ((Share.S_Grades[Share.LoginIndex, 1]) < 60)
                {
                    lbl總成績.ForeColor = Color.Red;
                    lbl總成績.Text = (Share.S_Grades[Share.LoginIndex, 1]).ToString("F1");
                }
                else
                {
                    lbl總成績.ForeColor = Color.Black;
                    lbl總成績.Text = (Share.S_Grades[Share.LoginIndex, 1]).ToString("F1");
                }

                lbl排名.Text = "第 " + (Share.S_Ranks[Share.LoginIndex, 1]) + " 名";

                //算班上情況
                double total = 0, max = 0, min = 100;


                for (int i = 0; i < 2; i++) 
                {
                    double grade = Share.S_Grades[i, 1];
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

        private void btn課程介紹_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            courseDescription21.Visible = true;
            courseDescription21.BringToFront();
        }

        private void btn成績查看_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn成績查看.Height;
            SidePanel.Top = btn成績查看.Top;
            if (courseDescription21.Visible)
                courseDescription21.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            courseDescription21.Visible = true;
            courseDescription21.BringToFront();
        }
    }
}
