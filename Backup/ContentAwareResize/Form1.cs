using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ContentAwareResize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string OpenedFilePath = openFileDialog1.FileName;
                MyColor[,] ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

                int[,] EnergyMatrix = ImageOperations.CalculateEnergy(ImageMatrix);

                ImageOperations.DisplayEnergy(EnergyMatrix, pictureBox2);
            }
        }

        private void btnCAR_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int NumOfSeams = int.Parse(txtNumOfSeams.Text);
                string OpenedFilePath = openFileDialog1.FileName;
                ContentAwareResize CAR = new ContentAwareResize(OpenedFilePath);
                ImageOperations.DisplayImage(CAR._imageMatrix, pictureBox1);
                ImageOperations.DisplayEnergy(CAR._energyMatrix, pictureBox2);
                
                CAR.CalculateSeamsCost();
                CAR.CalculateVerIndexMap(NumOfSeams);
                ImageOperations.DisplayEnergy(CAR._verIndexMap, pictureBox3);

                //AND the seams with the original image
                for (int i = 0; i < CAR.Height; i++)
                {
                    for (int j = 0; j < CAR.Width; j++)
                    {
                        CAR._imageMatrix[i, j].R &= (byte)CAR._verIndexMap[i, j];
                        CAR._imageMatrix[i, j].G &= (byte)CAR._verIndexMap[i, j];
                        CAR._imageMatrix[i, j].B &= (byte)CAR._verIndexMap[i, j];
                    }
                }
                ImageOperations.DisplayImage(CAR._imageMatrix, pictureBox1);
            }
        }

        private void btnRemoveCols_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int NumOfCols = int.Parse(txtNumOfSeams.Text);
                string OpenedFilePath = openFileDialog1.FileName;
                
                ContentAwareResize CAR = new ContentAwareResize(OpenedFilePath);
                ImageOperations.DisplayImage(CAR._imageMatrix, pictureBox1);
                ImageOperations.DisplayEnergy(CAR._energyMatrix, pictureBox2);
                MyColor [,] ResizedMatrix = ImageOperations.NormalResize(CAR._imageMatrix, CAR.Width - NumOfCols, CAR.Height);
                ImageOperations.DisplayImage(ResizedMatrix, pictureBox2);

                CAR.RemoveColumns(NumOfCols);
                ImageOperations.DisplayImage(CAR._imageMatrix, pictureBox3);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image.Save(saveFileDialog1.FileName + ".bmp", ImageFormat.Bmp);
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName + ".bmp", ImageFormat.Bmp);
            }
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName + ".bmp", ImageFormat.Bmp);
            }
        }
    }
}