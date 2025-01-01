using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using DataTable = System.Data.DataTable;
using System.Windows.Forms;

namespace BTTH5.Classes
{
    internal class Common
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();

        public string AutoSingKey(string tableName, string ID, string startCode)
        {
            Random random = new Random();
            string id = "";
            bool check = false;

            do
            {
                id = startCode + random.Next(1, 10000).ToString();
                DataTable dtHD = dtBase.ReadData("Select * from " + tableName + " where " + ID + " = '" + id + "'");
                if (dtHD.Rows.Count == 0)
                {
                    check = true;
                }
            } while (check == false);

            return id;
        }
    }
}
