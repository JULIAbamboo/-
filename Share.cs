using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Share_ClassLibrary
{
    public static class Share
    {
        public static string[,] S_Courses = new string[2, 2];          //存放兩個學生的兩門課程
        public static double[,] S_Grades = new double[2, 2];           //存放兩個學生的兩門成績
        public static int[,] S_Ranks = new int[2, 2];                  //存放兩個學生的兩門排名

        public static string[,] T_Mail_Course = new string[2, 2];      //老師端的預警內容存放(依課與人分開)
        public static string[] S_Mail = new string[2] {"",""};         //存放欲傳到學生端的預警(同帳號的訊息合併)

        public static string T_Selected_Course = "";                   //老師combox當前已選擇的課程
        public static int LoginIndex = -1;                             //紀錄第幾個學生帳號(尚未登入)

        public static string[] T_Passwords_array=new string[1];        //存放老師密碼


        // 設定預設資料的方法
        public static void 設定預設資料()
        {
            // 學生1
            S_Courses[0, 0] = "網頁設計";
            S_Courses[0, 1] = "作業系統";
            S_Grades[0, 0] = 0;
            S_Grades[0, 1] = 0;
            S_Ranks[0, 0] = 0;
            S_Ranks[0, 1] = 0;
            T_Mail_Course[0, 0] = "";
            T_Mail_Course[0, 1] = "";
           
            // 學生2     
            S_Courses[1, 0] = "網頁設計";
            S_Courses[1, 1] = "作業系統";
            S_Grades[1, 0] = 0;
            S_Grades[1, 1] = 0;
            S_Ranks[1, 0] = 0;
            S_Ranks[1, 1] = 0;
            T_Mail_Course[1, 0] = "";
            T_Mail_Course[1, 1] = "";

            //老師密碼
            T_Passwords_array[0] = "t01";
        }
    }
}


