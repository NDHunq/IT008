namespace Bai_2._6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DSSV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DiemVanTBx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DiemAnhTBx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DiemToanTBx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MaLopTBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HoTenTBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MSSVTBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ThemButt = new System.Windows.Forms.Button();
            this.SuaButt = new System.Windows.Forms.Button();
            this.XoaButt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSSV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.DSSV);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(723, 272);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sinh viên";
            // 
            // DSSV
            // 
            this.DSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DSSV.Location = new System.Drawing.Point(4, 25);
            this.DSSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DSSV.Name = "DSSV";
            this.DSSV.RowHeadersWidth = 51;
            this.DSSV.RowTemplate.Height = 24;
            this.DSSV.Size = new System.Drawing.Size(714, 242);
            this.DSSV.TabIndex = 0;
            this.DSSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DSSV_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.DiemVanTBx);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.DiemAnhTBx);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DiemToanTBx);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.MaLopTBx);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.HoTenTBx);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.MSSVTBx);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(14, 309);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(534, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // DiemVanTBx
            // 
            this.DiemVanTBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiemVanTBx.Location = new System.Drawing.Point(400, 162);
            this.DiemVanTBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DiemVanTBx.Name = "DiemVanTBx";
            this.DiemVanTBx.Size = new System.Drawing.Size(98, 26);
            this.DiemVanTBx.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(320, 167);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Điểm văn";
            // 
            // DiemAnhTBx
            // 
            this.DiemAnhTBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiemAnhTBx.Location = new System.Drawing.Point(400, 102);
            this.DiemAnhTBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DiemAnhTBx.Name = "DiemAnhTBx";
            this.DiemAnhTBx.Size = new System.Drawing.Size(98, 26);
            this.DiemAnhTBx.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điểm Anh";
            // 
            // DiemToanTBx
            // 
            this.DiemToanTBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiemToanTBx.Location = new System.Drawing.Point(400, 41);
            this.DiemToanTBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DiemToanTBx.Name = "DiemToanTBx";
            this.DiemToanTBx.Size = new System.Drawing.Size(98, 26);
            this.DiemToanTBx.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(320, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điểm toán";
            // 
            // MaLopTBx
            // 
            this.MaLopTBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaLopTBx.Location = new System.Drawing.Point(89, 162);
            this.MaLopTBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaLopTBx.Name = "MaLopTBx";
            this.MaLopTBx.Size = new System.Drawing.Size(192, 26);
            this.MaLopTBx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã lớp";
            // 
            // HoTenTBx
            // 
            this.HoTenTBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoTenTBx.Location = new System.Drawing.Point(89, 102);
            this.HoTenTBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HoTenTBx.Name = "HoTenTBx";
            this.HoTenTBx.Size = new System.Drawing.Size(192, 26);
            this.HoTenTBx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên";
            // 
            // MSSVTBx
            // 
            this.MSSVTBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSSVTBx.Location = new System.Drawing.Point(89, 44);
            this.MSSVTBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MSSVTBx.Name = "MSSVTBx";
            this.MSSVTBx.Size = new System.Drawing.Size(192, 26);
            this.MSSVTBx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSSV";
            // 
            // ThemButt
            // 
            this.ThemButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ThemButt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThemButt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.ThemButt.Location = new System.Drawing.Point(602, 340);
            this.ThemButt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ThemButt.Name = "ThemButt";
            this.ThemButt.Size = new System.Drawing.Size(99, 32);
            this.ThemButt.TabIndex = 2;
            this.ThemButt.Text = "Thêm";
            this.ThemButt.UseVisualStyleBackColor = false;
            this.ThemButt.Click += new System.EventHandler(this.ThemButt_Click);
            // 
            // SuaButt
            // 
            this.SuaButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuaButt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SuaButt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.SuaButt.Location = new System.Drawing.Point(602, 403);
            this.SuaButt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SuaButt.Name = "SuaButt";
            this.SuaButt.Size = new System.Drawing.Size(99, 32);
            this.SuaButt.TabIndex = 3;
            this.SuaButt.Text = "Sửa";
            this.SuaButt.UseVisualStyleBackColor = false;
            this.SuaButt.Click += new System.EventHandler(this.SuaButt_Click);
            // 
            // XoaButt
            // 
            this.XoaButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.XoaButt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XoaButt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.XoaButt.Location = new System.Drawing.Point(602, 467);
            this.XoaButt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XoaButt.Name = "XoaButt";
            this.XoaButt.Size = new System.Drawing.Size(99, 32);
            this.XoaButt.TabIndex = 4;
            this.XoaButt.Text = "Xóa";
            this.XoaButt.UseVisualStyleBackColor = false;
            this.XoaButt.Click += new System.EventHandler(this.XoaButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(748, 544);
            this.Controls.Add(this.XoaButt);
            this.Controls.Add(this.SuaButt);
            this.Controls.Add(this.ThemButt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DSSV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DSSV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DiemToanTBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MaLopTBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HoTenTBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MSSVTBx;
        private System.Windows.Forms.TextBox DiemVanTBx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DiemAnhTBx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ThemButt;
        private System.Windows.Forms.Button SuaButt;
        private System.Windows.Forms.Button XoaButt;
    }
}

