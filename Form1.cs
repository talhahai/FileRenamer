using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        string FolderPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Status: In Progress";
            button1.Enabled = false;
            string[] Files = Directory.GetFiles(FolderPath);
            if (radioButton3.Checked)
            {
                foreach (string OldFile in Files)
                {
                    string NewName = OldFile.Replace(textBox5.Text, textBox6.Text);
                    File.Move(OldFile, NewName);
                }
            }
            if (radioButton2.Checked) //Delete First Characters
            {
                foreach (string OldFile in Files)
                {
                    string NewFile = OldFile.Substring(Convert.ToInt32(textBox3.Text), OldFile.Length);
                    File.Move(OldFile, NewFile);
                }
            }
            if (radioButton1.Checked) //Delete Last Characters
            {
                foreach (string OldFile in Files)
                {
                    string Ext = OldFile.Substring(OldFile.Length - 4, 4);
                    string NewFile = OldFile.Substring(0, OldFile.Length - Convert.ToInt32(textBox4.Text) - 4) + Ext;
                    File.Move(OldFile, NewFile);
                }
            }
            button1.Enabled = true;
            label1.Text = "Status: Successful";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = true;
                FolderPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = radioButton2.Checked;
            textBox5.Enabled = textBox6.Enabled = textBox4.Enabled = !radioButton2.Checked;
            textBox5.BackColor = textBox6.BackColor = textBox4.BackColor = Color.Empty;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[0-9]+$"))
            {
                button2.Enabled = true;
                textBox3.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox3.BackColor = Color.Tomato;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = textBox6.Enabled = radioButton3.Checked;
            textBox3.Enabled = textBox4.Enabled = !radioButton3.Checked;
            textBox3.BackColor = textBox4.BackColor = Color.Empty;
            if (textBox5.Text.Length > 0)
            {
                button2.Enabled = true;
                textBox5.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox5.BackColor = Color.Tomato;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = radioButton1.Checked;
            textBox5.Enabled = textBox6.Enabled = textBox3.Enabled = !radioButton1.Checked;
            textBox5.BackColor = textBox6.BackColor = textBox3.BackColor = Color.Empty;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]+$"))
            {
                button2.Enabled = true;
                textBox4.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox4.BackColor = Color.Tomato;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]+$"))
            {
                button2.Enabled = true;
                textBox4.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox4.BackColor = Color.Tomato;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[0-9]+$"))
            {
                button2.Enabled = true;
                textBox3.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox3.BackColor = Color.Tomato;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                button2.Enabled = true;
                textBox5.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox5.BackColor = Color.Tomato;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                button2.Enabled = true;
                textBox5.BackColor = Color.Empty;
            }
            else
            {
                button2.Enabled = false;
                textBox5.BackColor = Color.Tomato;
            }
        }
    }
}
