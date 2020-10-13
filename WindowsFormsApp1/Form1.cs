using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        ListBox lbox;
        DataGridView dgv;
        MainMenu menu;
        TreeNode tn;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            tn = new TreeNode("Elemendid");
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
            tn.Nodes.Add(new TreeNode("ListBox"));

            tn.Nodes.Add(new TreeNode("DataGridView"));


            tn.Nodes.Add(new TreeNode("Menu"));

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
                page1.BackColor = Color.Red;
                page2.BackColor = Color.Blue;
                page3.BackColor = Color.Yellow;

                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);


                string inpu = Interaction.InputBox("");
                if (inpu == "1")
                {
                    tabControl.SelectedIndex = 0;
                    //tabControl.SelectedTab = this.page1;
                }
                else if (inpu == "2")
                {
                    tabControl.SelectedIndex = 1;
                    //tabControl.SelectedTab = this.page2;
                }
                else if (inpu == "3")
                {
                    tabControl.SelectedIndex = 2;
                    //tabControl.SelectedTab = this.page3;
                }

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
            else if(e.Node.Text == "ListBox")
            {
                string[] colors_nim = new string []{ "Sinine", "Kollane", "Roheline", "Punane" };

                lbox = new ListBox();
                int sizeOfList;
                int maxLength;
                maxLength = colors_nim.Select(x => x.Length).Max();
                foreach (var item in colors_nim)
                {
                    lbox.Items.Add(item);
                }

                sizeOfList = colors_nim.Length;
                lbox.Click += Lbox_Click;
                lbox.Location = new Point(150, 300);
                lbox.Width = maxLength * 10;
                lbox.Height = sizeOfList * 15;
                
                Controls.Add(lbox);
                
            }
            else if(e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml("..//..Files//XMLFile1.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(200, 200);
                dgv.Width = 250;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "CATALOG";
                dgv.DataSource = dataSet;
                Controls.Add(dgv);
            }
            else if(e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuItem1 = new MenuItem("File");
                menuItem1.MenuItems.Add("Exit", new EventHandler(menuItem1_Exit));

                MenuItem menuItem = new MenuItem("My");
                menuItem.MenuItems.Add("BagroundColor", new EventHandler(menuItem_backColor));

                menuItem.MenuItems.Add("TreeView Color", new EventHandler(menuItem_treeColor));

                menuItem.MenuItems.Add("TreeView Font", new EventHandler(menuItem_treeFont));


                menu.MenuItems.Add(menuItem1);
                menu.MenuItems.Add(menuItem);

                this.Menu = menu;

            }
        }

        private void menuItem_treeFont(object sender, EventArgs e)
        {
            Font f = new Font("Arial", 10, FontStyle.Bold);
            tn.NodeFont = f;
        }

        private void menuItem_treeColor(object sender, EventArgs e)
        {
            tree.BackColor = Color.AliceBlue;
        }

        private void menuItem_backColor(object sender, EventArgs e)
        {
            BackColor = Color.Aquamarine;
        }

        private void Lbox_Click(object sender, EventArgs e)
        {

            if (lbox.Text == "Sinine")
            {
                lbox.BackColor = Color.Blue;
            }
            else if (lbox.Text == "Kollane")
            {
                lbox.BackColor = Color.Yellow;
            }
            else if (lbox.Text == "Roheline")
            {
                lbox.BackColor = Color.Green;
            }
            else if (lbox.Text == "Punane")
            {
                lbox.BackColor = Color.Red;
            }
        }

        private void menuItem1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Close();
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
