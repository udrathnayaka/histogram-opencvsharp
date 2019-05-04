using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        GrayPreprocessing gp = new GrayPreprocessing();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gp.Negative();
            //pictureBox2.ImageLocation = "2.jpg";
            gp.Neg();
            pictureBox2.ImageLocation = "3.jpg";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select an Image";
            ofd.Filter = "Images (*.BMP; *.JPG; *.GIF) | *.BMP; *.JPG; *.GIF|"+"All Files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gp.LoadOriginalImage(ofd.FileName);
                String path = ofd.FileName.ToString();
                pictureBox1.ImageLocation = path;

            }

            gp.Extract();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gp.Log();
            pictureBox2.ImageLocation = "4.jpg";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gp.InverseLog();
            pictureBox2.ImageLocation = "5.jpg";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gp.gamma();
            pictureBox2.ImageLocation = "6.jpg";
        }

        

        private void button6_Click_1(object sender, EventArgs e)
        {
            gp.grayLevel();
            pictureBox2.ImageLocation = "7.jpg";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gp.drawHistogram();
            pictureBox2.ImageLocation = "hist.jpg";
        }
    }
}
