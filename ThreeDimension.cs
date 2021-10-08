using System;
using System.Collections.Generic;
using System.Text;

namespace SIGMA_5_3D_OBJECT_
{
    class ThreeDimension
    {
        public enum XYZ
        {
            XOY,
            XOZ,
            YOZ
        }

        private int[,,] threeDimension;

        private int[,] shadow;

        private int size;

        public int Size
        {
            get
            {
                return size;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid dimension size");
                    size = value;
                }
            }
        }



        public ThreeDimension()
        {
            Size = 3;
            threeDimension = new int[3, 3, 3]  { { { 0, 1, 0 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                        { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } },
                                        { { 0, 0, 0 }, { 1, 0, 1 }, { 0, 0, 1 } } };

        }

        public ThreeDimension(int size)
        {
            Size = size;
            threeDimension = new int[Size, Size, Size];

            Random rand = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        threeDimension[i, j, k] = rand.Next(0, 2);
                    }
                }
            }
        }


        public void printObject(XYZ plane)
        {
            shadow = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        switch (plane)
                        {
                            case XYZ.XOY:
                                shadow[i, j] += threeDimension[k, i, j];
                                break;

                            case XYZ.XOZ:
                                shadow[i, j] += threeDimension[i, j, k];
                                break;

                            case XYZ.YOZ:
                                shadow[i, j] += threeDimension[i, k, j];
                                break;
                        }

                        if (shadow[i, j] == 1) break;

                    }
                }
            }
            PrintShadow(plane);
        }


        private void PrintShadow(XYZ plane)
        {

            Console.WriteLine($"{plane}:");


            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(shadow[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
