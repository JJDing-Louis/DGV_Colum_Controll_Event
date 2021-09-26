using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGV_Colum_Controll_Event
{
    public partial class Form1 : Form
    {
        //建立資料格式
        private List<string> data = new List<string>();

        //建立下拉式選單的選項
        private string[] group = new string[] { "group_1", "group_2", "group_3" };

        /// <summary>
        /// WinForm載入時，開始初始化的部分
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //呼叫Load_Data進行資料載入
            Load_Data();
        }

        /// <summary>
        /// 讀取資料的Method(此部分的Code用自行產生的資料載入)
        /// </summary>
        private void Load_Data()
        {
            //將下拉式選單的選項，載入 DGV_Column_cbm裡面
            DGV_Column_cbm.DataSource = group;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < DGV_Data.Columns.Count; j++)
                {
                    data.Add($"Data_{i}");
                    data.Add(null);
                    data.Add("Show");
                    data.Add("555");
                }
                DGV_Data.Rows.Add(data.ToArray());
                data.Clear();
            }
        }

        /// <summary>
        /// 建立修改下拉式選地的觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modify_Option(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                MessageBox.Show("開始修改選項!");
            }
        }

        /// <summary>
        /// 使用者點擊後，顯示該欄位的細節
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDetail(object sender, DataGridViewCellEventArgs e)
        {
            //取的當下點即時的ColumnIndex
            int click_column_index = e.ColumnIndex;
            //取的當下點即時的RowIndex
            int click_row_index = e.RowIndex;

            //限制當下點擊的ColumnIndex，為ColumnButton時，才進行對應的反應 (ColumnButton的ColumnIndex為2)
            if (click_column_index == 2)
            {
                string detail = $"Name : {DGV_Data[0, click_row_index].Value.ToString()}\n" +
                                      $"State : {DGV_Data[1, click_row_index].Value.ToString()}\n" +
                                      $"List : {DGV_Data[3, click_row_index].Value.ToString()}";
                MessageBox.Show(detail);
            }
        }
    }
}