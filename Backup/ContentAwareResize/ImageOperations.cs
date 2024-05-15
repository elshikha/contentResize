using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ContentAwareResize
{
    public struct MyColor
    {
        public byte R, G, B;
    }
    public class ImageOperations
    {
        //public static byte [,] OpenImage(string ImagePath)
        //{
        //    Bitmap original_bm = new Bitmap(ImagePath);
        //    int Height = original_bm.Height;
        //    int Width = original_bm.Width;

        //    byte[,] Buffer = new byte[Height, Width];

        //    unsafe
        //    {
        //        BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
        //        int x, y;
        //        int nWidth = 0;
        //        bool Format32 = false;
        //        bool Format24 = false;
        //        bool Format8 = false;

        //        if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
        //        {
        //            Format24 = true;
        //            nWidth = Width * 3;
        //        }
        //        else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
        //        {
        //            Format32 = true;
        //            nWidth = Width * 4;
        //        }
        //        else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
        //        {
        //            Format8 = true;
        //            nWidth = Width;
        //        }
        //        int nOffset = bmd.Stride - nWidth;
        //        byte* p = (byte*)bmd.Scan0;
        //        for (y = 0; y < Height; y++)
        //        {
        //            for (x = 0; x < Width; x++)
        //            {
        //                if (Format8)
        //                {
        //                    Buffer[y, x]= p[0];
        //                    p++;
        //                }
        //                else
        //                {
        //                    Buffer[y, x]= (byte)((int)(p[0] + p[1] + p[2]) / 3);
        //                    if (Format24) p += 3;
        //                    else if (Format32) p += 4;
        //                }
        //            }
        //            p += nOffset;
        //        }
        //        original_bm.UnlockBits(bmd);
        //    }

        //    return Buffer;
        //}
        public static int GetHeight(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }
        public static int GetWidth(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }
        public static void DisplayImage(byte[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			
            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[0] = p[1] = p[2] = ImageMatrix[i, j];
                        p += 3;
                    }
                     
                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }
        public static byte[,] NormalResize(byte[,] ImageMatrix, int NewWidth, int NewHeight)
        {
            int i = 0, j = 0;
            int Height = ImageMatrix.GetLength(0); 
            int Width = ImageMatrix.GetLength(1);
            
            double WidthRatio = (double)(Width) / (double)(NewWidth);
            double HeightRatio = (double)(Height) / (double)(NewHeight);

            int OldWidth = Width;
            int OldHeight = Height;

            byte P1, P2, P3, P4;

            byte Y1, Y2, X = new byte();

            byte[,] Data = new byte[NewHeight, NewWidth];

            Width = NewWidth;
            Height = NewHeight;

            int floor_x, ceil_x;
            int floor_y, ceil_y;

            double x, y;
            double fraction_x, one_minus_x;
            double fraction_y, one_minus_y;

            for (j = 0; j < NewHeight; j++)
                for (i = 0; i < NewWidth; i++)
                {
                    x = (double)(i) * WidthRatio;
                    y = (double)(j) * HeightRatio;

                    floor_x = (int)(x);
                    ceil_x = floor_x + 1;
                    if (ceil_x >= OldWidth) ceil_x = floor_x;

                    floor_y = (int)(y);
                    ceil_y = floor_y + 1;
                    if (ceil_y >= OldHeight) ceil_y = floor_y;

                    fraction_x = x - floor_x;
                    one_minus_x = 1.0 - fraction_x;

                    fraction_y = y - floor_y;
                    one_minus_y = 1.0 - fraction_y;

                    P1 = ImageMatrix[ floor_y, floor_x];
                    P2 = ImageMatrix[ceil_y, floor_x];
                    P3 = ImageMatrix[floor_y, ceil_x];
                    P4 = ImageMatrix[ceil_y, ceil_x];

                    //GRAY
                    Y1 = (byte)(one_minus_y * P1 + fraction_y * P2);
                    Y2 = (byte)(one_minus_y * P3 + fraction_y * P4);
                    X = (byte)(one_minus_x * Y1 + fraction_x * Y2);

                    Data[j,i] = X;
                }

            return Data;
        }

        public static void DisplayEnergy(int[,] EnergyMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = EnergyMatrix.GetLength(0);
            int Width = EnergyMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            int Max = int.MinValue;
            int Min = int.MaxValue;

            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    if (EnergyMatrix[i, j] > Max) Max = EnergyMatrix[i, j];
                    if (EnergyMatrix[i, j] < Min) Min = EnergyMatrix[i, j];
                }
                
            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                double Factor = 255.0 / (Max - Min);
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        byte GrayLevel = (byte)((EnergyMatrix[i, j] - Min) * Factor);
                        p[0] = p[1] = p[2] = GrayLevel;
                        p+=3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }
        public static int [,] CalculateEnergy(byte[,] ImageMatrix)
        {
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);
            int[,] Energy = new int[Height, Width];

            for (int i = 0; i < Height - 1; i++)
            {
                for (int j = 0; j < Width - 1; j++)
                {
                    int dx = ImageMatrix[i, j + 1] - ImageMatrix[i, j];
                    int dy = ImageMatrix[i + 1, j] - ImageMatrix[i, j];

                    Energy[i, j] = Math.Abs(dx) + Math.Abs(dy);
                }
                //set energy value of last column same as the one of column before last
                Energy[i, Width - 1] = Energy[i, Width - 2];
            }

            //set energy value of last row same as the one of row before last
            for (int j = 0; j < Width ; j++)
                Energy[Height - 1, j] = Energy[Height - 2, j];
            
            return Energy;
        }


        public static MyColor[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);
            int Height = original_bm.Height;
            int Width = original_bm.Width;

            MyColor[,] Buffer = new MyColor[Height, Width];

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
                int x, y;
                int nWidth = 0;
                bool Format32 = false;
                bool Format24 = false;
                bool Format8 = false;

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;
                    nWidth = Width * 3;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;
                    nWidth = Width * 4;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;
                    nWidth = Width;
                }
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x].R = Buffer[y, x].G = Buffer[y, x].B = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x].R = p[0];
                            Buffer[y, x].G = p[1];
                            Buffer[y, x].B = p[2];
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }
        public static int GetHeight(MyColor[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }
        public static int GetWidth(MyColor[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }
        public static void DisplayImage(MyColor[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[0] = ImageMatrix[i, j].R;
                        p[1] = ImageMatrix[i, j].G;
                        p[2] = ImageMatrix[i, j].B;
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }

        public static int[,] CalculateEnergy(MyColor[,] ImageMatrix)
        {
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);
            int[,] Energy = new int[Height, Width];
            int dx, dy;
            for (int i = 0; i < Height - 1; i++)
            {
                for (int j = 0; j < Width - 1; j++)
                {
                    dx = Math.Abs(ImageMatrix[i, j + 1].R - ImageMatrix[i, j].R) ;
                    dy = Math.Abs(ImageMatrix[i + 1, j].R - ImageMatrix[i, j].R);

                    dx += Math.Abs(ImageMatrix[i, j + 1].G - ImageMatrix[i, j].G);
                    dy += Math.Abs(ImageMatrix[i + 1, j].G - ImageMatrix[i, j].G);

                    dx += Math.Abs(ImageMatrix[i, j + 1].B - ImageMatrix[i, j].B);
                    dy += Math.Abs(ImageMatrix[i + 1, j].B - ImageMatrix[i, j].B);

                    Energy[i, j] = dx+ dy;
                }
                //set energy value of last column same as the one of column before last
                Energy[i, Width - 1] = Energy[i, Width - 2];
            }

            //set energy value of last row same as the one of row before last
            for (int j = 0; j < Width; j++)
                Energy[Height - 1, j] = Energy[Height - 2, j];

            return Energy;
        }

        public static MyColor[,] NormalResize(MyColor[,] ImageMatrix, int NewWidth, int NewHeight)
        {
            int i = 0, j = 0;
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            double WidthRatio = (double)(Width) / (double)(NewWidth);
            double HeightRatio = (double)(Height) / (double)(NewHeight);

            int OldWidth = Width;
            int OldHeight = Height;

            MyColor P1, P2, P3, P4;

            MyColor Y1, Y2, X = new MyColor();

            MyColor[,] Data = new MyColor[NewHeight, NewWidth];

            Width = NewWidth;
            Height = NewHeight;

            int floor_x, ceil_x;
            int floor_y, ceil_y;

            double x, y;
            double fraction_x, one_minus_x;
            double fraction_y, one_minus_y;

            for (j = 0; j < NewHeight; j++)
                for (i = 0; i < NewWidth; i++)
                {
                    x = (double)(i) * WidthRatio;
                    y = (double)(j) * HeightRatio;

                    floor_x = (int)(x);
                    ceil_x = floor_x + 1;
                    if (ceil_x >= OldWidth) ceil_x = floor_x;

                    floor_y = (int)(y);
                    ceil_y = floor_y + 1;
                    if (ceil_y >= OldHeight) ceil_y = floor_y;

                    fraction_x = x - floor_x;
                    one_minus_x = 1.0 - fraction_x;

                    fraction_y = y - floor_y;
                    one_minus_y = 1.0 - fraction_y;

                    P1 = ImageMatrix[floor_y, floor_x];
                    P2 = ImageMatrix[ceil_y, floor_x];
                    P3 = ImageMatrix[floor_y, ceil_x];
                    P4 = ImageMatrix[ceil_y, ceil_x];

                    Y1.R = (byte)(one_minus_y * P1.R + fraction_y * P2.R);
                    Y1.G = (byte)(one_minus_y * P1.G + fraction_y * P2.G);
                    Y1.B = (byte)(one_minus_y * P1.B + fraction_y * P2.B);

                    Y2.R = (byte)(one_minus_y * P3.R + fraction_y * P4.R);
                    Y2.G = (byte)(one_minus_y * P3.G + fraction_y * P4.G);
                    Y2.B = (byte)(one_minus_y * P3.B + fraction_y * P4.B);

                    X.R = (byte)(one_minus_x * Y1.R + fraction_x * Y2.R);
                    X.G = (byte)(one_minus_x * Y1.G + fraction_x * Y2.G);
                    X.B = (byte)(one_minus_x * Y1.B + fraction_x * Y2.B);

                    Data[j, i] = X;
                }

            return Data;
        }
    }
}
