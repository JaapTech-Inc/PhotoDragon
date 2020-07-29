using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragon_Designer
{
    public partial class Form1 : Form
    {
        public int CountLabel;
        public int CountPicture;
        public int CountPanel;
        PictureBox picture = new PictureBox();
        Panel newPanel = new Panel();
        Label label = new Label();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        Size size = new Size();
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panelCanvas.CreateGraphics();
            pen = new Pen(colorDialog1.Color, 5);

        }

        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPanel.BackColor = Color.White;
            size.Width = 200;
            size.Height = 200;
            newPanel.Size = size;
            newPanel.Cursor = Cursors.SizeAll;
            CountPanel++;
            panelCanvas.Controls.Add(newPanel);
            newPanel.BringToFront();
            listBox1.Items.Add("newPanel" + CountPanel);
        }

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label.Text = "newLabel";
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            size.Width = 200;
            size.Height = 200;
            label.Size = size;
            CountLabel++;
            label.Cursor = Cursors.SizeAll;
            panelCanvas.Controls.Add(label);
            label.BringToFront();
            listBox1.Items.Add("newLabel" + CountLabel);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem);
            if(listBox1.GetItemText(listBox1.SelectedItem).Contains("newLabel"))
            {
                textBox2.Text = label.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                picture.Image = Image.FromFile(openFileDialog1.FileName);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Width = 200;
                picture.Height = 200;
                picture.Cursor = Cursors.SizeAll;
                CountPicture++;
                listBox1.Items.Add("newImage" + CountPicture);
                panelCanvas.Controls.Add(picture);
                picture.BringToFront();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                if(listBox1.GetItemText(listBox1.SelectedItem).Contains("newPanel"))
                {
                    panelCanvas.Controls.Remove(newPanel);
                    panelCanvas.Refresh();
                }
                if (listBox1.GetItemText(listBox1.SelectedItem).Contains("newLabel"))
                {
                    panelCanvas.Controls.Remove(label);
                    panelCanvas.Refresh();
                }
                if (listBox1.GetItemText(listBox1.SelectedItem).Contains("newImage"))
                {
                    panelCanvas.Controls.Remove(picture);
                    panelCanvas.Refresh();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label.Text = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label.Font = fontDialog1.Font;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (listBox1.GetItemText(listBox1.SelectedItem).Contains("newLabel"))
            {
                label.ForeColor = colorDialog1.Color;
            }
            if (listBox1.GetItemText(listBox1.SelectedItem).Contains("newPanel"))
            {
                newPanel.BackColor = colorDialog1.Color;
            }
            pen = new Pen(colorDialog1.Color, 5);
        }

        private void newPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void newPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                newPanel.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void newPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = newPanel.Location;
            newPanel.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newPanel.MouseDown += newPanel_MouseDown;
            newPanel.MouseMove += newPanel_MouseMove;
            newPanel.MouseUp += newPanel_MouseUp;
            label.MouseDown += label_MouseDown;
            label.MouseMove += label_MouseMove;
            label.MouseUp += label_MouseUp;
            picture.MouseDown += picture_MouseDown;
            picture.MouseUp += picture_MouseUp;
            picture.MouseMove += picture_MouseMove;
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                picture.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = picture.Location;
            picture.BringToFront();
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                label.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = label.Location;
            label.BringToFront();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                timer2.Start();
            }
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to continue?", "Dragon Designer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void paintingLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x!=-1 && y!=-1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g = panelCanvas.CreateGraphics();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            using (Bitmap bitmap = new Bitmap(panelCanvas.Width, panelCanvas.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, panelCanvas.Size);
                    bitmap.Save(saveFileDialog1.FileName);
                }

            }
            this.UseWaitCursor = false;
            timer2.Stop();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
