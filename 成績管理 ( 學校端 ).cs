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

namespace homework_6_1358004
{
    public partial class frm成績管理_學校端: Form
    {
        public frm成績管理_學校端()
        {
            InitializeComponent();
        }

        double 比重_平時 = 0.3 ;
        double 比重_期中 = 0.3 ;
        double 比重_期末 = 0.4 ;

        private void frm成績管理_學校端_Load(object sender, EventArgs e)
        {
            dataGridView比重檢視.Columns[0].Width = 120;
            dataGridView比重檢視.Columns[1].Width = 120;

            更新比重表格();
            設定畫面位置();

            groupBox輸入比重.Visible = false;     
        }

        private void 設定畫面位置()
        {
            this.StartPosition = FormStartPosition.Manual;

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int x = (screenWidth - this.Width) / 2;  // 置中
            int y = (screenHeight - this.Height) / 2;  // 置中
            this.Location = new Point(x, y);
        }

        private void btn使用說明_Click(object sender, EventArgs e)
        {
            MessageBox.Show("這是一個說明視窗。請依照指示操作～\n" + "\n" +
             "1. 請先選擇欲登記成績之學生\n" + "\n" +
             "2. 請依序輸入該學生的平時、期中期末考成績，\n" +
             "    可透過「當前比重顯示」來查看目前比重分配。\n" + "\n" +
             "3. 若有想自己設定比重的需求，請勾選「更改成績比重」，\n" +
             "    並自行修改數(以%為單位)\n" + "\n" +
             "4. 最後按下「計算總成績」，即顯示\n" +
             "    若確定登記完成，請按下「儲存」。\n" + "\n" +
             "5. 完成後，可進行下一位學生的成績登記，或關閉表單，成績即顯示在表格中"
             , "使用說明",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox更改成績比重_CheckedChanged(object sender, EventArgs e)
        {
            groupBox輸入比重.Visible = true;
        }

        private void btn總成績_Click(object sender, EventArgs e)
        {
            double 平時 = Convert.ToDouble(txt平時成績.Text);
            double 期中 = Convert.ToDouble(txt期中考.Text);
            double 期末 = Convert.ToDouble(txt期末考.Text);

            if (string.IsNullOrEmpty(txt平時成績.Text)|| string.IsNullOrEmpty(txt期中考.Text)|| string.IsNullOrEmpty(txt期末考.Text))
            {
                MessageBox.Show("⚠️ 輸入不完整，請重新檢查", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return; 
            }

            if ((平時 < 0 || 平時 > 100) || (期中 < 0 || 期中 > 100) ||
                (期末 < 0 || 期末 > 100))
            {
                MessageBox.Show("⚠️ 輸入成績範圍錯誤，請重新檢查", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (checkBox更改成績比重.Checked)
            {
                double 新_平時 = Convert.ToDouble(txt平時成績_比重.Text) / 100; 
                double 新_期中 = Convert.ToDouble(txt期中考_比重.Text) / 100;
                double 新_期末 = Convert.ToDouble(txt期末考_比重.Text) / 100;  

                比重_平時 = 新_平時;
                比重_期中 = 新_期中;
                比重_期末 = 新_期末;

                double 總比重 = 比重_平時 + 比重_期中 + 比重_期末;

                if (總比重 > 1)
                {
                    MessageBox.Show("❌ 比重相加大於100%，請重新檢查", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (總比重 < 1)
                {
                    MessageBox.Show("❌ 比重相加小於100%，請重新檢查", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    更新比重表格();
                }
            }
            else
            {
                groupBox輸入比重.Visible = false;
            }
               
            double total = 平時 * 比重_平時 + 期中 * 比重_期中 + 期末 * 比重_期末;
            lbl總成績.Text = total.ToString("F1");  // 顯示一位小數

            /* F1 的意思：
              "F" 表示 固定小數點格式（Fixed-point format），"1" 表示 小數點後顯示 1 位數字

              例:
                  double num = 87.456;
                  string s1 = num.ToString("F1");  // → "87.5"
                  string s2 = num.ToString("F2");  // → "87.46"
                  string s3 = num.ToString("F0");  // → "87"    */
        }

        //當前比重檢視:剛開始預設0.3、0.3、0.4
        private void 更新比重表格()
        {
            dataGridView比重檢視.Rows.Clear();
            dataGridView比重檢視.Rows.Add("平時成績", 比重_平時 * 100 + "%");
            dataGridView比重檢視.Rows.Add("期中考", 比重_期中 * 100 + "%");
            dataGridView比重檢視.Rows.Add("期末考", 比重_期末 * 100 + "%");
        }

        private void btn儲存_Click(object sender, EventArgs e)
        {
            if (cboName_Number.SelectedIndex == -1) // 檢查有沒有選學生
            {
                MessageBox.Show("請先選擇一位學生", "未選擇學生",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string choose = cboName_Number.SelectedItem.ToString();//combobox選項的字串

            int cboindex = -1; //combobox內學生的索引

            if (choose == "學生甲")   //將combobox選到的學生設索引值
            {
                cboindex = 0;
            }
            else if (choose == "學生乙")
            {
                cboindex = 1;
            }   

            int course_index = -1; //確認老師端從首頁選的這門課是學生資料中的第幾門

            if (Share.T_Selected_Course == Share.S_Courses[0, 0])
            {
                course_index = 0;
            }
            else
            {
                course_index = 1;
            }

            double 總成績 = Convert.ToDouble(lbl總成績.Text);

            // 儲存成績
            Share.S_Grades[cboindex, course_index] = Convert.ToDouble(lbl總成績.Text);

            double score0 = Share.S_Grades[0, course_index];
            double score1 = Share.S_Grades[1, course_index];

            if (score0 > score1)
            {
                Share.S_Ranks[0, course_index] = 1;
                Share.S_Ranks[1, course_index] = 2;
            }
            else if (score0 < score1)
            {
                Share.S_Ranks[0, course_index] = 2;
                Share.S_Ranks[1, course_index] = 1;
            }
            else
            {
                Share.S_Ranks[0, course_index] = 1;
                Share.S_Ranks[1, course_index] = 1;
            }

            MessageBox.Show("✅ 成績已儲存給：" + choose
                + "\n總成績：" + 總成績.ToString("F1"), "儲存成功",
                MessageBoxButtons.OK, MessageBoxIcon.Information);        
        }
    }
}
