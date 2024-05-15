using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

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
            label_seampathcorrectness.Text = "";
            label_SeamMINActual.Text = "-1";
            label_SeamMINExpected.Text = "-1";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int NumOfSeams = int.Parse(txtNumOfSeams.Text);
                string OpenedFilePath = openFileDialog1.FileName;
                ContentAwareResize CAR = new ContentAwareResize(OpenedFilePath);
                ImageOperations.DisplayImage(CAR._imageMatrix, pictureBox1);
                ImageOperations.DisplayEnergy(CAR._energyMatrix, pictureBox2);

                //AND the seams with the original image
                int Width = CAR._imageMatrix.GetLength(1);
                int Height = CAR._imageMatrix.GetLength(0);
                int minSeamValue = -1;
                List<ContentAwareResize.coord> seamPathCoord = null;
                CAR.CalculateVerIndexMap(NumOfSeams, ref minSeamValue, ref seamPathCoord);
                ImageOperations.DisplayEnergy(CAR._verIndexMap, pictureBox3);
                
                //Output valdiation
                if(NumOfSeams == 1)
                    CaseOutputValidation(CAR, openFileDialog1.FileName, minSeamValue, seamPathCoord);
                
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (CAR._verIndexMap[i, j] != int.MaxValue)
                        {
                            CAR._imageMatrix[i, j].R = 0;
                            CAR._imageMatrix[i, j].G = 0;
                            CAR._imageMatrix[i, j].B = 0;
                        }
                    }
                }
                ImageOperations.DisplayImage(CAR._imageMatrix, pictureBox1);
            }
        }

        public void CaseOutputValidation(ContentAwareResize CAR, string selectedImgPath, int minSeamValueActual, List<ContentAwareResize.coord> seamPathCoord)
        {
            // Read a text file line by line. 
            string inoutFilePath = "inout.txt";
            string[] lines = File.ReadAllLines(inoutFilePath);

            foreach (string line in lines)
            {
                string[] lineParts = line.Split(',');
                if (selectedImgPath.Contains(lineParts[0]))
                {
                    //Set labels with the expected and actual values
                    label_SeamMINActual.Text = minSeamValueActual.ToString();
                    string minSeamValueExpected = lineParts[1];
                    label_SeamMINExpected.Text = minSeamValueExpected;
                    if (int.Parse(lineParts[1]) != minSeamValueActual)
                    {
                        label_seampathcorrectness.Text = "The selected seam is NOT the MIN one!!.";
                        break;
                    }
                    if(CheckPathCorrectness(CAR, seamPathCoord))
                        label_seampathcorrectness.Text = "Congratulations :) Correct seam.";
                    else
                        label_seampathcorrectness.Text = "WRONG path for the selected seam!!.";
                    break;
                }
            }
        }

        public bool CheckPathCorrectness(ContentAwareResize CAR, List<ContentAwareResize.coord> seamPathCoord)
        {
            int Width = CAR._imageMatrix.GetLength(1);
            int Height = CAR._imageMatrix.GetLength(0);
            if (seamPathCoord.Count != Height)
                return false;

            seamPathCoord = seamPathCoord.OrderBy(x => x.row).ToList();
            int i;
            for (i = 0; i < seamPathCoord.Count-1; i++)
            {
                if (seamPathCoord[i].row != i)
                    return false;
                if (seamPathCoord[i].column != seamPathCoord[i+1].column-1 && seamPathCoord[i].column != seamPathCoord[i+1].column && seamPathCoord[i].column != seamPathCoord[i+1].column +1)
                    return false;
            }
            //Last row
            if (seamPathCoord[i].row != i)
                return false;

            return true;
            
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
                int Width = CAR._imageMatrix.GetLength(1);
                int Height = CAR._imageMatrix.GetLength(0);

                MyColor [,] ResizedMatrix = ImageOperations.NormalResize(CAR._imageMatrix, Width - NumOfCols, Height);
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