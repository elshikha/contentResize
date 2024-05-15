// -----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ContentAwareResize
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Utilities
    {
        public static Bitmap ToBitmap(int[,] EnergyMatrix, bool normalize)
        {
            // Create Image:
            //==============
            int Height = EnergyMatrix.GetLength(0);
            int Width = EnergyMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            int Max = int.MinValue;
            int Min = int.MaxValue;

            if (normalize)
            {
                for (int i = 0; i < Height; i++)
                    for (int j = 0; j < Width; j++)
                    {
                        if (EnergyMatrix[i, j] > Max) Max = EnergyMatrix[i, j];
                        if (EnergyMatrix[i, j] < Min) Min = EnergyMatrix[i, j];
                    }
            }
            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                if (normalize)
                {
                    double Factor = 255.0 / (Max - Min);
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            byte GrayLevel = (byte)((EnergyMatrix[i, j] - Min) * Factor);
                            p[0] = p[1] = p[2] = GrayLevel;
                            p += 3;
                        }

                        p += nOffset;
                    }
                }
                else
                {
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            byte GrayLevel = (byte)(EnergyMatrix[i, j] );
                            p[0] = p[1] = p[2] = GrayLevel;
                            p += 3;
                        }

                        p += nOffset;
                    }
                }
                ImageBMP.UnlockBits(bmd);
            }
            return ImageBMP;
        
        }
        

    }
}
