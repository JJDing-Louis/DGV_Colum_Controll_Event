
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

