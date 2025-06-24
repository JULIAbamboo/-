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
    public partial class frm測試表單_學生端: Form
    {
        public frm測試表單_學生端()
        {
            InitializeComponent();
        }

        private void btn13580xx_Click(object sender, EventArgs e)
        {
            Share.LoginIndex = 1;
            new frm首頁_學生端().Show();
        }

        private void btn1x58060_Click(object sender, EventArgs e)
        {
            Share.LoginIndex = 0;
            new frm首頁_學生端().Show();
        }

        private void frm測試表單_學生端_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Height;
            int screenHeight = this.Height;

            int x = 50; 
            int y = 0; 

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
        }
    }
}
