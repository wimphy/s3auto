using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s3auto
{
    public partial class Form2 : Form
    {
        Form f1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            this.Hide();
            Point p = new Point();
            WinAPI.GetCursorPos(out p);
            MessageBox.Show("x:" + p.X + "y:" + p.Y + " " + WinAPI.GetColor(p.X, p.Y).ToString());
            f1.Show();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        public void Show(Form f)
        {
            this.Show();
            f1 = f;
        }
    }
}
