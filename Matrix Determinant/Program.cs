using System;

namespace Matrix_Determinant
{
    class Program
    {
        public static double DET(int n, double[,] Mat)
        {
            double d = 0;
            int k, i, j, subi, subj;
            double[,] SUBMat = new double[n, n];

            if (n == 2)
            {
                return ((Mat[0, 0] * Mat[1, 1]) - (Mat[1, 0] * Mat[0, 1]));
            }

            else
            {
                for (k = 0; k < n; k++)
                {
                    subi = 0;
                    for (i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            SUBMat[subi, subj] = Mat[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * Mat[0, k] * DET(n - 1, SUBMat));
                    Console.WriteLine(d);
                }
                string log = "";
                for (int s = 0; s < SUBMat.GetLength(0); s++)
                {
                    for (int a = 0; a < SUBMat.GetLength(1); a++)
                    {
                        log += SUBMat[s, a].ToString() + " | ";
                    }
                    log += "\n";
                }
                Console.WriteLine(log);
            }
            return d;
        }

        public static float DET1(float[][] mas)
        {
            float sonuc = 0;
            if (mas.Length == 1)
            {
                sonuc = mas[0][0];
                return sonuc;
            }
            else if (mas.Length == 2)
            {
                sonuc = mas[0][0] * mas[1][1] - mas[0][1] * mas[1][0];
                return sonuc;
            }
            for (int i = 0; i < mas[0].Length; i++)
            {
                float[][] gecici = new float[mas.Length - 1][];
                for (int y = 0; y < mas.Length - 1; y++)
                {
                    gecici[y] = new float[mas[0].Length - 1];
                }

                for (int j = 1; j < mas.Length; j++)
                {
                    for (int k = 0; k < mas[0].Length; k++)
                    {
                        if (k < i)
                        {
                            gecici[j - 1][k] = mas[j][k];
                        }
                        else if (k > i)
                        {
                            gecici[j - 1][k - 1] = mas[j][k];
                        }
                    }
                }
                sonuc += mas[0][i] * (float)Math.Pow(-1, i) * DET1(gecici);
            }
            return sonuc;
        }

        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Matrix dimension:");
            n = int.Parse(Console.ReadLine());
            float[][] Mat = new float[n][];
            for (int y = 0; y < n; y++)
            {
                Mat[y] = new float[n];
            }
            int i, j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Random r = new Random();
                    Mat[i][j] = (float)r.NextDouble();
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Your Matrix:");
            for (i = 0; i < Mat.Length; i++)
            {
                for (j = 0; j < Mat[i].Length; j++)
                {
                    Console.Write(" " + Mat[i][j]);
                }

                Console.WriteLine();
                Console.ReadKey();
            }

            Console.WriteLine("Determinant: " + DET1(Mat));
            Console.ReadKey();


            /*int n;
            Console.WriteLine("Matrix dimension:");
            n = int.Parse(Console.ReadLine());
            double[,] Mat = new double[n, n];
            int i, j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Random r = new Random();
                    Mat[i, j] = r.NextDouble();
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Your Matrix:");
            for (i = 0; i < Mat.GetLength(0); i++)
            {
                for (j = 0; j < Mat.GetLength(1); j++)
                {
                    Console.Write(" " + Mat[i, j]);
                }

                Console.WriteLine();
                Console.ReadKey();
            }

            Console.WriteLine("Determinant: " + DET(n, Mat));
            Console.ReadKey();*/
        }
    }
}
