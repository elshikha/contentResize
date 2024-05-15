using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ContentAwareResize
{
    public class ContentAwareResize
    {
        public MyColor[,] _imageMatrix;
        public int[,] _energyMatrix;
        int[,] _seamsCost;
        int[,] _seamsCostIndices;
        public int[,] _verIndexMap;

        public int Height
        {
            get { return _imageMatrix.GetLength(0); }
        }
        public int Width
        {
            get { return _imageMatrix.GetLength(1); }
        }
        
        public ContentAwareResize(string ImagePath)
        {
            _imageMatrix = ImageOperations.OpenImage(ImagePath);
            _energyMatrix = ImageOperations.CalculateEnergy(_imageMatrix);
            int _height = _energyMatrix.GetLength(0);
            int _width = _energyMatrix.GetLength(1);
            _seamsCost = new int[_height, _width];
            _seamsCostIndices = new int[_height, _width];
        }

        public void CalculateSeamsCost()
        {
            
            for (int j = 0; j < Width; j++)
            {
                _seamsCost[0, j] = _energyMatrix[0, j];
                _seamsCostIndices[0, j] = -2; //termination
            }

            int Min, Index;
            for (int i = 1; i < Height; i++)
            {
                #region 1st pixel of each row
                Min = _seamsCost[i - 1, 0];
                Index = 0;
                if (_seamsCost[i - 1, 1] < Min)
                {
                    Min = _seamsCost[i - 1, 1];
                    Index = +1;
                }
                _seamsCost[i, 0] = _energyMatrix[i, 0] + Min;
                _seamsCostIndices[i, 0] = Index;
                #endregion

                int j;
                for (j = 1; j < Width - 1; j++)
                {
                    Min = _seamsCost[i - 1, j];
                    Index = 0;

                    if (_seamsCost[i - 1, j - 1] < Min)
                    {
                        Min = _seamsCost[i - 1, j - 1];
                        Index = -1;
                    }

                    if (_seamsCost[i - 1, j + 1] < Min)
                    {
                        Min = _seamsCost[i - 1, j + 1];
                        Index = +1;
                    }

                    _seamsCost[i, j] = _energyMatrix[i, j] + Min;
                    _seamsCostIndices[i, j] = Index;
                }

                #region last pixel of each row
                Min = _seamsCost[i - 1, j];
                Index = 0;
                if (_seamsCost[i - 1, j - 1] < Min)
                {
                    Min = _seamsCost[i - 1, j - 1];
                    Index = -1;
                }
                _seamsCost[i, j] = _energyMatrix[i, j] + Min;
                _seamsCostIndices[i, j] = Index;
                #endregion

            }
        }

        public void CalculateVerIndexMap(int NumberOfSeams)
        {
            _verIndexMap = new int[Height, Width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    _verIndexMap[i, j] = int.MaxValue;

            bool[] RemovedSeams = new bool[Width]; 
            for (int j = 0; j < Width; j++)
                RemovedSeams[j] = false;

            for (int s = 1; s <= NumberOfSeams; s++)
            {
                //Search for Min Seam # s
                int Min = int.MaxValue;
                int Index = -1;
                for (int j = 0; j < Width; j++)
                    if (!(RemovedSeams[j])&& (_seamsCost[Height - 1, j] < Min))
                    {
                        Min = _seamsCost[Height - 1, j];
                        Index = j;
                    }
                RemovedSeams[Index] = true;

                //Mark all pixels of the current min Seam in the VerIndexMap

                for (int i = Height - 1; i >= 0; i--)
                {
                   // if (_verIndexMap[i, Index] != int.MaxValue)
                  //      throw new Exception("overalpped seams");
                    _verIndexMap[i, Index] = s;
                    //remove this seam from energy matrix by setting it to max value
                    _energyMatrix[i, Index] = 100000;
                    //update Index for next step
                    Index += _seamsCostIndices[i, Index];
                }
                //re-calculate Seams Cost
                CalculateSeamsCost();
                    
            }
        }

        public void RemoveColumns(int NumberOfCols)
        {
            ///Removing required number of min seams at once
            ///
            //CalculateSeamsCost();
            //CalculateVerIndexMap(NumberOfCols);
            //int OldWidth = Width;
            //MyColor[,] OldImage = _imageMatrix;
            //_imageMatrix = new MyColor[Height, OldWidth - NumberOfCols];
            //for (int i = 0; i < Height; i++)
            //{
            //    int cnt = 0;
            //    for (int j = 0; j < OldWidth; j++)
            //    {
            //        if (_verIndexMap[i, j] > NumberOfCols)
            //            _imageMatrix[i, cnt++] = OldImage[i, j];
            //    }
            //}

            ///Removing 1 min seam at a time and re-calculate the energy again
            ///
            for (int c = 0; c < NumberOfCols; c++)
            {
                _energyMatrix = ImageOperations.CalculateEnergy(_imageMatrix);
                CalculateSeamsCost();
                CalculateVerIndexMap(1);

                MyColor[,] OldImage = _imageMatrix;
                _imageMatrix = new MyColor[Height, Width - 1];
                for (int i = 0; i < Height; i++)
                {
                    int cnt = 0;
                    for (int j = 0; j < Width; j++)
                    {
                        if (_verIndexMap[i, j] > 1)
                            _imageMatrix[i, cnt++] = OldImage[i, j];
                    }
                }
            }

            ///Removing min energy pixels from each row
            ///
            //for (int c = 0; c < NumberOfCols; c++)
            //{
            //    _energyMatrix = ImageOperations.CalculateEnergy(_imageMatrix);
            //    //CalculateSeamsCost();
            //    //CalculateVerIndexMap(1);

            //    MyColor[,] OldImage = _imageMatrix;
            //    _imageMatrix = new MyColor[Height, Width - 1];
            //    for (int i = 0; i < Height; i++)
            //    {
            //        int min = int.MaxValue;
            //        int index = 0;
            //        for (int j = 0; j < Width; j++)
            //        {
            //            if (_energyMatrix[i, j] < min)
            //            {
            //                min = _energyMatrix[i, j];
            //                index = j;
            //            }
            //        }
            //        int cnt = 0;
            //        for (int j = 0; j < index; j++)
            //        {
            //            _imageMatrix[i, cnt++] = OldImage[i, j];
            //        }
            //        for (int j = index+1; j < Width; j++)
            //        {
            //            _imageMatrix[i, cnt++] = OldImage[i, j];
            //        }
            //    }
            //}
        }
    }
}
