using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace textEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.box = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._open = new System.Windows.Forms.ToolStripMenuItem();
            this._new = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._edit = new System.Windows.Forms.ToolStripMenuItem();
            this._save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.undoBut = new System.Windows.Forms.ToolStripButton();
            this.redoBut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyBut = new System.Windows.Forms.ToolStripButton();
            this.cutBut = new System.Windows.Forms.ToolStripButton();
            this.pasteBut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fontLb = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.sizeLb = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.selectFontBut = new System.Windows.Forms.ToolStripButton();
            this.forecolorBut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.backcolorBut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.hleftBut = new System.Windows.Forms.ToolStripButton();
            this.hcenterBut = new System.Windows.Forms.ToolStripButton();
            this.hrightBut = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.Enabled = false;
            this.box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box.Location = new System.Drawing.Point(13, 135);
            this.box.Name = "box";
            this.box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.box.Size = new System.Drawing.Size(1244, 583);
            this.box.TabIndex = 4;
            this.box.Text = "";
            this.box.TextChanged += new System.EventHandler(this.box_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1269, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._open,
            this._new,
            this.toolStripSeparator5,
            this._edit,
            this._save,
            this.toolStripSeparator1,
            this.logOutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 24);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // _open
            // 
            this._open.Name = "_open";
            this._open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._open.Size = new System.Drawing.Size(232, 26);
            this._open.Text = "Open";
            this._open.Click += new System.EventHandler(this._open_Click);
            // 
            // _new
            // 
            this._new.Name = "_new";
            this._new.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._new.Size = new System.Drawing.Size(232, 26);
            this._new.Text = "New";
            this._new.Click += new System.EventHandler(this._new_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(229, 6);
            // 
            // _edit
            // 
            this._edit.Enabled = false;
            this._edit.Name = "_edit";
            this._edit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this._edit.Size = new System.Drawing.Size(232, 26);
            this._edit.Text = "Edit";
            this._edit.Click += new System.EventHandler(this._edit_Click);
            // 
            // _save
            // 
            this._save.Enabled = false;
            this._save.Name = "_save";
            this._save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._save.Size = new System.Drawing.Size(232, 26);
            this._save.Text = "Save";
            this._save.Click += new System.EventHandler(this._save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 34);
            this.toolStripButton1.Text = "font";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 34);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // undoBut
            // 
            this.undoBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoBut.Image = ((System.Drawing.Image)(resources.GetObject("undoBut.Image")));
            this.undoBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoBut.Name = "undoBut";
            this.undoBut.Size = new System.Drawing.Size(29, 34);
            this.undoBut.Text = "undo";
            this.undoBut.Click += new System.EventHandler(this.undoBut_Click);
            // 
            // redoBut
            // 
            this.redoBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoBut.Image = ((System.Drawing.Image)(resources.GetObject("redoBut.Image")));
            this.redoBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoBut.Name = "redoBut";
            this.redoBut.Size = new System.Drawing.Size(29, 34);
            this.redoBut.Text = "redo";
            this.redoBut.Click += new System.EventHandler(this.redoBut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // copyBut
            // 
            this.copyBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyBut.Image = ((System.Drawing.Image)(resources.GetObject("copyBut.Image")));
            this.copyBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyBut.Name = "copyBut";
            this.copyBut.Size = new System.Drawing.Size(29, 34);
            this.copyBut.Text = "copy";
            this.copyBut.Click += new System.EventHandler(this.copyBut_Click);
            // 
            // cutBut
            // 
            this.cutBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutBut.Image = ((System.Drawing.Image)(resources.GetObject("cutBut.Image")));
            this.cutBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutBut.Name = "cutBut";
            this.cutBut.Size = new System.Drawing.Size(29, 34);
            this.cutBut.Text = "cut";
            this.cutBut.Click += new System.EventHandler(this.cutBut_Click);
            // 
            // pasteBut
            // 
            this.pasteBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteBut.Image = ((System.Drawing.Image)(resources.GetObject("pasteBut.Image")));
            this.pasteBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteBut.Name = "pasteBut";
            this.pasteBut.Size = new System.Drawing.Size(29, 34);
            this.pasteBut.Text = "toolStripButton5";
            this.pasteBut.Click += new System.EventHandler(this.pasteBut_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1,
            this.fontLb,
            this.toolStripSeparator8,
            this.sizeLb,
            this.toolStripSeparator9,
            this.selectFontBut,
            this.toolStripSeparator4,
            this.forecolorBut,
            this.toolStripSeparator10,
            this.backcolorBut,
            this.toolStripSeparator7,
            this.undoBut,
            this.redoBut,
            this.toolStripSeparator3,
            this.copyBut,
            this.cutBut,
            this.pasteBut,
            this.toolStripSeparator2,
            this.hleftBut,
            this.hcenterBut,
            this.hrightBut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1269, 37);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fontLb
            // 
            this.fontLb.AutoSize = false;
            this.fontLb.Name = "fontLb";
            this.fontLb.Size = new System.Drawing.Size(300, 34);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 37);
            // 
            // sizeLb
            // 
            this.sizeLb.AutoSize = false;
            this.sizeLb.Name = "sizeLb";
            this.sizeLb.Size = new System.Drawing.Size(40, 34);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 37);
            // 
            // selectFontBut
            // 
            this.selectFontBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectFontBut.Image = ((System.Drawing.Image)(resources.GetObject("selectFontBut.Image")));
            this.selectFontBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectFontBut.Name = "selectFontBut";
            this.selectFontBut.Size = new System.Drawing.Size(51, 34);
            this.selectFontBut.Text = "select";
            this.selectFontBut.Click += new System.EventHandler(this.selectFontBut_Click);
            // 
            // forecolorBut
            // 
            this.forecolorBut.AutoSize = false;
            this.forecolorBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.forecolorBut.Image = ((System.Drawing.Image)(resources.GetObject("forecolorBut.Image")));
            this.forecolorBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forecolorBut.Name = "forecolorBut";
            this.forecolorBut.Size = new System.Drawing.Size(34, 34);
            this.forecolorBut.Text = "A";
            this.forecolorBut.Click += new System.EventHandler(this.forecolorBut_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 37);
            // 
            // backcolorBut
            // 
            this.backcolorBut.AutoSize = false;
            this.backcolorBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.backcolorBut.Image = ((System.Drawing.Image)(resources.GetObject("backcolorBut.Image")));
            this.backcolorBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backcolorBut.Name = "backcolorBut";
            this.backcolorBut.Size = new System.Drawing.Size(25, 25);
            this.backcolorBut.Click += new System.EventHandler(this.backcolorBut_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 37);
            // 
            // hleftBut
            // 
            this.hleftBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hleftBut.Image = ((System.Drawing.Image)(resources.GetObject("hleftBut.Image")));
            this.hleftBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hleftBut.Name = "hleftBut";
            this.hleftBut.Size = new System.Drawing.Size(29, 34);
            this.hleftBut.Text = "left";
            this.hleftBut.Click += new System.EventHandler(this.hleftBut_Click);
            // 
            // hcenterBut
            // 
            this.hcenterBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hcenterBut.Image = ((System.Drawing.Image)(resources.GetObject("hcenterBut.Image")));
            this.hcenterBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hcenterBut.Name = "hcenterBut";
            this.hcenterBut.Size = new System.Drawing.Size(29, 34);
            this.hcenterBut.Text = "center";
            this.hcenterBut.Click += new System.EventHandler(this.hcenterBut_Click);
            // 
            // hrightBut
            // 
            this.hrightBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hrightBut.Image = ((System.Drawing.Image)(resources.GetObject("hrightBut.Image")));
            this.hrightBut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hrightBut.Name = "hrightBut";
            this.hrightBut.Size = new System.Drawing.Size(29, 34);
            this.hrightBut.Text = "right";
            this.hrightBut.Click += new System.EventHandler(this.hrightBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1140, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 789);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.box);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Box_SelectionChanged1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Box_SelectionChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.RichTextBox box;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _open;
        private System.Windows.Forms.ToolStripMenuItem _new;
        private System.Windows.Forms.ToolStripMenuItem _save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem _edit;
        private ToolStripButton toolStripButton1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton undoBut;
        private ToolStripButton redoBut;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton copyBut;
        private ToolStripButton cutBut;
        private ToolStripButton pasteBut;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStrip toolStrip1;
        private ToolStripLabel fontLb;
        private ToolStripLabel sizeLb;
        private ToolStripButton selectFontBut;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton forecolorBut;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton backcolorBut;
        private ToolStripButton hleftBut;
        private ToolStripButton hcenterBut;
        private ToolStripButton hrightBut;
        private Label label1;
    }
}

