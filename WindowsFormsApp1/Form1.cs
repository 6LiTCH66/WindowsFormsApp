using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox textbox;
        PictureBox pic_box;
        TabControl tabControl;
        TabPage page1, page2, page3;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            //label
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            //
            tn.Nodes.Add(new TreeNode("Markeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstast-TextBox"));
            tn.Nodes.Add(new TreeNode("PictureBox-Pildikast"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Markeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;

                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;

            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(RadioButton_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += new EventHandler(RadioButton_Changed);


                this.Controls.Add(r1);
                this.Controls.Add(r2);

            }
            else if (e.Node.Text == "Tekstast-TextBox")
            {
                string text_file;
                try
                {
                    StreamReader from_file = new StreamReader(@"C:\Users\Game\RiderProjects\FormsApp\FormsApp\bin\Debug\file.txt");
                    text_file = from_file.ReadToEnd();
                }
                catch (DirectoryNotFoundException)
                {
                    text_file = "Fail puudub";
                }
                textbox = new TextBox();
                textbox.Multiline = true;
                textbox.Text = text_file;
                textbox.Location = new Point(300, 300);
                textbox.Width = 200;
                textbox.Height = 200;
                Controls.Add(textbox);
            }
            else if (e.Node.Text == "PictureBox-Pildikast")
            {
                pic_box = new PictureBox();
                pic_box.Image = new Bitmap("pict.png");
                pic_box.Location = new Point(450, 10);
                pic_box.Size = new Size(100, 100);
                pic_box.SizeMode = PictureBoxSizeMode.Zoom;
                pic_box.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pic_box);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(350, 150);
                tabControl.Size = new Size(150, 100);
                page1 = new TabPage("Esimene");
                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);

                this.Controls.Add(tabControl);

            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MesageBox", "Kõige lithsam aken");

                var anwser = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupuga", MessageBoxButtons.YesNo);

                if (anwser == DialogResult.Yes)
                {
                    string inpu = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskatisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = inpu;
                        this.Controls.Add(lbl);
                    }
                }
            }
        }

        private void RadioButton_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}
