using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace textEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            login lg= new login();
            lg.ShowDialog();
            fontLb.Text = box.Font.FontFamily.ToString();
            sizeLb.Text = box.Font.Size.ToString();
        }

        public bool isSaved= true;
        string path="";
        string selectText="";
        private void _open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "|*.txt";
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName,Encoding.Unicode);
                    box.Text = sr.ReadToEnd();
                    sr.Close();
                    _edit.Enabled = true;
                    box.Enabled = false;
                    _save.Enabled = false;
                    isSaved = true;
             
                    path = ofd.FileName;
                  
                 
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void _new_Click(object sender, EventArgs e)
        {
            box.Enabled = true;
            box.Text = "";
            _save.Enabled = false;
            isSaved= true;
            path = "";
        }
        private void _edit_Click(object sender, EventArgs e)
        {
            box.Enabled = true;
            isSaved = true;
        }
        private void _save_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "|*.txt";
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        box.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                        MessageBox.Show("Lưu thành công");
                        isSaved = true;
                        _save.Enabled = false;

                    }
                }
                catch (Exception ex) { throw ex; }
            }
            else
            {
                box.SaveFile(path,RichTextBoxStreamType.UnicodePlainText);
                MessageBox.Show("Lưu thành công");
                isSaved = true;
                _save.Enabled = false;
            }
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void undoBut_Click(object sender, EventArgs e)
        {
            box.Undo();
        }
        private void redoBut_Click(object sender, EventArgs e)
        {
            box.Redo();
        }
        private void copyBut_Click(object sender, EventArgs e)
        {
            box.Copy();
        }
        private void cutBut_Click(object sender, EventArgs e)
        {
            box.Cut();
        }
        private void pasteBut_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                box.Paste();
            }
        }
        private void box_TextChanged(object sender, EventArgs e)
        {
            _save.Enabled = true;
            isSaved = false;
        }
        private void selectFontBut_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                fontLb.Text = fontDialog.Font.Name;
                sizeLb.Text = fontDialog.Font.Size.ToString();
                int st = box.SelectionStart;
                int ed = box.SelectionLength + st;
                selectText = box.SelectedText;
                box.Select(st, ed);
                box.SelectionFont = fontDialog.Font;

            }
        }
        private void forecolorBut_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                int st = box.SelectionStart;
                int ed = box.SelectionLength + st;
                selectText = box.SelectedText;
                box.Select(st, ed);
                box.SelectionColor = colorDialog.Color;
                forecolorBut.ForeColor = colorDialog.Color;

            }
        }
        private void backcolorBut_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                int st = box.SelectionStart;
                int ed = box.SelectionLength + st;
                selectText = box.SelectedText;
                box.Select(st, ed);
                box.SelectionBackColor = colorDialog.Color;
                backcolorBut.BackColor = colorDialog.Color;

            }
        }
        private void hleftBut_Click(object sender, EventArgs e)
        {
            box.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void hcenterBut_Click(object sender, EventArgs e)
        {
            box.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void hrightBut_Click(object sender, EventArgs e)
        {
            box.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isSaved==false) {
                DialogResult dialogResult = MessageBox.Show("Do you want to save file?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _save_Click(sender, e);
                }
                
            }
        }
    }
}
