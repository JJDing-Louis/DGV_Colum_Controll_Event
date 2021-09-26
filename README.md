# [C#] WinForm的DataGridView控鍵Event設定
## 1.  前言:
最近剛好遇到客戶有提出復判功能的需求，在建立各項檢測項目修改時，想說用DataGridView的方式呈現，卻在建立控鍵的觸發事件卡關，最後在資深前輩的幫助下，想到這方式呈現，並筆記。

---

## 2.  作法:
Step 1. 建立UI畫面

開啟新的專案並建立DataGridView，並開啟上方的小箭頭，並取消啟動加入後，點擊編輯資料行，建立表單格式
![Pasted image 20210926144406.png](https://github.com/JJDing-Louis/DGV_Colum_Controll_Event/blob/main/CSharp_WinForm%E7%9A%84DataGridView%E6%8E%A7%E9%8D%B5Event%E8%A8%AD%E5%AE%9Apic/Pasted%20image%2020210926144406.png?raw=true)

點擊後，會出現以下畫面，點選加入
![Pasted image 20210926144449.png](https://github.com/JJDing-Louis/DGV_Colum_Controll_Event/blob/main/CSharp_WinForm%E7%9A%84DataGridView%E6%8E%A7%E9%8D%B5Event%E8%A8%AD%E5%AE%9Apic/Pasted%20image%2020210926144449.png?raw=true)

點選後，會出現加入資料行的畫面，在這邊可以建立要建立的資料欄位格式
![Pasted image 20210926144623.png](https://github.com/JJDing-Louis/DGV_Colum_Controll_Event/blob/main/CSharp_WinForm%E7%9A%84DataGridView%E6%8E%A7%E9%8D%B5Event%E8%A8%AD%E5%AE%9Apic/Pasted%20image%2020210926144623.png?raw=true)

格式的部分，以下用表格說明:

| 類型                           | 說明 |
| ------------------------------ | ---- |
| DataGridViewTextBoxColumn      |  表單的內容只顯示`string`    |
| DataGridViewCheckColumn    | 表單的內容為`CheckBox`     |
| DataGridViewComboBoxColumn | 表單的內容為`ComboBox`     |
| DataGridViewButtonColumn       |  表單的內容為`Button`    |
| DataGridViewImageColumn        |  表單的內容為`Image`    |
| DataGridViewLinkColumn         |表單的內容為`Link`|

以上類型所建立的控鍵效果，讀者可以嘗試建立看看，或者參考   
**me1237guy**大大的文章: [Adding Something to DataGridView](https://me1237guy.pixnet.net/blog/post/59183044) 

根據想要建立的資料類型設定好後，將UI設定成以下畫面
![Pasted image 20210926150135.png](https://github.com/JJDing-Louis/DGV_Colum_Controll_Event/blob/main/CSharp_WinForm%E7%9A%84DataGridView%E6%8E%A7%E9%8D%B5Event%E8%A8%AD%E5%AE%9Apic/Pasted%20image%2020210926150135.png?raw=true)

Step 2. 模擬資料載入

在程式碼內建立一段資料顯示在DataGridView裡面，執行的時候載入:

Code
```cs
 private void Load_Data()
 {
     //將下拉式選單的選項，載入 DGV_Column_cbm裡面
     DGV_Column_cbm.DataSource = group;
     for (int i = 0; i < 6; i++)
     {
         for (int j = 0; j < DGV_Data.Columns.Count; j++)
         {
             data.Add($"Data_{i}");
             data.Add(false.ToString());
             data.Add("Show");
             data.Add("group_1");
         }
         DGV_Data.Rows.Add(data.ToArray());
         data.Clear();
     }
 }
```

關於ComboBox選單項目的部分，需要建立資料來源，並用**DataSource**的方式做繫結
Code:
建立表單項目資料
```cs
 //建立下拉式選單的選項
  private string[] group = new string[] { "group_1", "group_2", "group_3" };
```

在`Load_Data()`的函式內，執行時並做繫結
```cs
//將下拉式選單的選項，載入 DGV_Column_cbm裡面
DGV_Column_cbm.DataSource = group; 
```

最後在表單載入時，呼叫`Load_Data()`並執行

```cs
 /// <summary>
 /// WinForm載入時，開始初始化的部分
 /// </summary>
 public Form1()
 {
     InitializeComponent();
     //呼叫Load_Data進行資料載入
     Load_Data();
 }
```

以下是執行後的結果:
![Pasted image 20210926151326.png](https://github.com/JJDing-Louis/DGV_Colum_Controll_Event/blob/main/CSharp_WinForm%E7%9A%84DataGridView%E6%8E%A7%E9%8D%B5Event%E8%A8%AD%E5%AE%9Apic/Pasted%20image%2020210926151326.png?raw=true)

Step 3. 建立控鍵的觸發事件

這部分非常重要了，畢竟筆者當初在部分卡了很久也花了不少時間找資料與詢問前輩，建議這邊step by step去建立

- 建立**DataGridViewButtonColumn** 的觸發事件

點擊DataGirdView，並找到事件內容的`CellContentClick`，寫入要建立的事件名稱後，用滑鼠點擊兩下，程式會自動幫你建立對應的Method，在這邊筆者命名為`ShowDetail`==(畫紅線的部分)==
![Pasted image 20210926152134.png](https://github.com/JJDing-Louis/DGV_Colum_Controll_Event/blob/main/CSharp_WinForm%E7%9A%84DataGridView%E6%8E%A7%E9%8D%B5Event%E8%A8%AD%E5%AE%9Apic/Pasted%20image%2020210926152134.png?raw=true)

建立後的結果:
Code:
```cs
private void ShowDetail(object sender, DataGridViewCellEventArgs e)
{
    
}
```

這裡設定顯示的內容為該資料列的所有資訊:
Code:
```cs
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
```

==設定觸發條件(重要)==

透過`e`的這個引數，可以或的當下觸發控鍵的Index，藉由設定該Index的條件，來觸發顯示，如果沒做這個條件設定，`CellContentClick`的判定條件為，只要`DataGridView`內的Cell都有滑鼠點擊，皆會觸發該事件。

Code:
```cs
//取的當下點即時的ColumnIndex
int click_column_index = e.ColumnIndex;
//取的當下點即時的RowIndex
int click_row_index = e.RowIndex;

//限制當下點擊的ColumnIndex，為ColumnButton時，才進行對應的反應 (ColumnButton的ColumnIndex為2)
```


執行結果:
![](https://i.imgur.com/Xqswc58.png)



- 建立**DataGridViewComboBoxColumn** 的觸發事件

跟建立`DataGridViewButtonColumn`的方式一樣，點擊DataGirdView，並找到事件內容的`CellBeginEdit`，寫入要建立的事件名稱後，用滑鼠點擊兩下，程式會自動幫你建立對應的Method，在這邊筆者命名為`Modify_Option` ==(畫紅線的部分)==
![Pasted image 20210926152921.png](https://i.imgur.com/vuh6Wyz.png)

建立後的結果:
Code:
```cs
 private void Modify_Option(object sender, DataGridViewCellCancelEventArgs e)
 {
 }
```

這裡筆者設定，當使用者要修改選單時，需要跳出觸發事件體醒使用者
```cs
 private void Modify_Option(object sender, DataGridViewCellCancelEventArgs e)
 {
     if (e.ColumnIndex == 3)
     {
         MessageBox.Show("開始修改選項!");
     }
 }
```

設定觸發條件:
跟設定`DataGridViewButtonColumn`的方式一樣。

執行結果:
![Pasted image 20210926153712.png](https://i.imgur.com/8pYxDDS.png)


到這邊，基本上就大功告成了!!

附上Source Code: [DGV_Colum_Controll_Event]()

---

## 3.  完整程式碼:
Form1.cs
```cs
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
                    data.Add(false.ToString());
                    data.Add("Show");
                    data.Add("group_1");
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
```

Form1.Designer.cs
```cs
namespace DGV_Colum_Controll_Event
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV_Data = new System.Windows.Forms.DataGridView();
            this.DGV_Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_Column_State = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGV_Column_Btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGV_Column_cbm = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Data
            // 
            this.DGV_Data.AllowUserToAddRows = false;
            this.DGV_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGV_Column_Name,
            this.DGV_Column_State,
            this.DGV_Column_Btn,
            this.DGV_Column_cbm});
            this.DGV_Data.Location = new System.Drawing.Point(14, 20);
            this.DGV_Data.Name = "DGV_Data";
            this.DGV_Data.RowHeadersWidth = 51;
            this.DGV_Data.RowTemplate.Height = 27;
            this.DGV_Data.Size = new System.Drawing.Size(682, 397);
            this.DGV_Data.TabIndex = 0;
            this.DGV_Data.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Modify_Option);
            this.DGV_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowDetail);
            // 
            // DGV_Column_Name
            // 
            this.DGV_Column_Name.HeaderText = "Name";
            this.DGV_Column_Name.MinimumWidth = 6;
            this.DGV_Column_Name.Name = "DGV_Column_Name";
            this.DGV_Column_Name.Width = 125;
            // 
            // DGV_Column_State
            // 
            this.DGV_Column_State.HeaderText = "State";
            this.DGV_Column_State.MinimumWidth = 6;
            this.DGV_Column_State.Name = "DGV_Column_State";
            this.DGV_Column_State.Width = 125;
            // 
            // DGV_Column_Btn
            // 
            this.DGV_Column_Btn.HeaderText = "Detail";
            this.DGV_Column_Btn.MinimumWidth = 6;
            this.DGV_Column_Btn.Name = "DGV_Column_Btn";
            this.DGV_Column_Btn.Width = 125;
            // 
            // DGV_Column_cbm
            // 
            this.DGV_Column_cbm.HeaderText = "List";
            this.DGV_Column_cbm.MinimumWidth = 6;
            this.DGV_Column_cbm.Name = "DGV_Column_cbm";
            this.DGV_Column_cbm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Column_cbm.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Controls.Add(this.DGV_Data);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Data)).EndInit();
            this.ResumeLayout(false);

        }

        private void DGV_Data_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DGV_Data_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_Column_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGV_Column_State;
        private System.Windows.Forms.DataGridViewButtonColumn DGV_Column_Btn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGV_Column_cbm;
    }
}
```

---

## 4.  常見問題:

1. 表單點選的對應狀態

當點選表單是，讀者可以留意UI戶面的變化，如果出現箭頭畫面，表示DataGridView是在**點選模式**
如果出現鉛筆畫面，表示DataGridView為**編輯模式**

點選模式:

![Pasted image 20210926154343.png](https://i.imgur.com/zbbvVTD.png)


編輯模式:

![Pasted image 20210926154320.png](https://i.imgur.com/LWh7I20.png)

2. 建立資料時，程式顯示出現無效數值
![Pasted image 20210926155059.png](https://i.imgur.com/V1o4oRz.png)

建立資料時，需考慮當下欄位能接受的資料內容，例如:State欄位為CheckBox、所以只能接受`true`、`false`或者 `null`;建立ComboBox時，需要考慮帶入的值，是否在該欄位的選單項目裡面。

---

## 5.  參考資料:
1. [Adding Something to DataGridView](https://me1237guy.pixnet.net/blog/post/59183044)  From me1237guy
2. [DataGridView 類別(MSDN)](https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.datagridview?view=net-5.0)
3. [# DataGridViewButtonColumn 類別(MSDN)](https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.datagridviewbuttoncolumn?view=net-5.0)
4. [# DataGridViewComboBoxColumn 類別(MSDN)](https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.datagridviewcomboboxcolumn?view=net-5.0)
