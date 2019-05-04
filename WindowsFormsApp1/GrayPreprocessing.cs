using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WindowsFormsApp1
{
    class GrayPreprocessing
    {
        IplImage src, neg, gray, OriRed, OriGreen, OriBlue;
        IplImage resultedRed, resultedGreen, resultedBlue;
        IplImage resultedImage;
        public void LoadOriginalImage(string fname)
        {
            src = Cv.LoadImage(fname, LoadMode.Color);
            Cv.SaveImage("1.jpg", src);

        }

        public void Extract()
        {
            System.Windows.Forms.MessageBox.Show("Height: " + src.Height + " Width " + src.Width + " Number of channels: " + src.NChannels);
        }

        public void Negative()
        {
            gray = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, gray, ColorConversion.RgbToGray);
            neg = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            Cv.Not(gray, neg);
            Cv.SaveImage("2.jpg", gray);

        }

        public void Neg()
        {
            OriRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.Split(src, OriRed, OriGreen, OriBlue, null);
            
            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen =  Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            resultedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            for(int y=1; y<src.Height-1; y++)
            {
                for (int x=1; x<src.Width-1; x++)
                {
                    double getRed = 0;
                    double getGreen = 0;
                    double getBlue = 0;

                    getRed = Cv.GetReal2D(OriRed, y, x);
                    getGreen = Cv.GetReal2D(OriGreen, y, x);
                    getBlue = Cv.GetReal2D(OriBlue, y, x);

                    double r = 255 - getRed;
                    double g = 255 - getGreen;
                    double b = 255 - getBlue;

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);

                 }
            }
            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, resultedImage);

            Cv.SaveImage("3.jpg", resultedImage);

        }

        public void Log()
        {
            OriRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.Split(src, OriRed, OriGreen, OriBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            resultedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            for (int y = 1; y < src.Height - 1; y++)
            {
                for (int x = 1; x < src.Width - 1; x++)
                {
                    double getRed = 0;
                    double getGreen = 0;
                    double getBlue = 0;
                    double c = 105.886;

                    getRed = Cv.GetReal2D(OriRed, y, x);
                    getGreen = Cv.GetReal2D(OriGreen, y, x);
                    getBlue = Cv.GetReal2D(OriBlue, y, x);

                    double r = c * Math.Log(1 + getRed);
                    double g = c * Math.Log(1 + getGreen);
                    double b = c * Math.Log(1 + getBlue);

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);

                }
            }
            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, resultedImage);

            Cv.SaveImage("4.jpg", resultedImage);

        }

        public void InverseLog()
        {
            OriRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.Split(src, OriRed, OriGreen, OriBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            resultedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            for (int y = 1; y < src.Height - 1; y++)
            {
                for (int x = 1; x < src.Width - 1; x++)
                {
                    double getRed = 0;
                    double getGreen = 0;
                    double getBlue = 0;
                    double c = 255 * Math.Pow(10,-255);

                    getRed = Cv.GetReal2D(OriRed, y, x);
                    getGreen = Cv.GetReal2D(OriGreen, y, x);
                    getBlue = Cv.GetReal2D(OriBlue, y, x);

                    double r = c * Math.Pow(10, getRed);
                    double g = c * Math.Pow(10, getGreen);
                    double b = c * Math.Pow(10, getBlue);

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);

                }
            }
            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, resultedImage);

            Cv.SaveImage("5.jpg", resultedImage);

        }

        public void gamma()
        {
            OriRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.Split(src, OriRed, OriGreen, OriBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            resultedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            for (int y = 1; y < src.Height - 1; y++)
            {
                for (int x = 1; x < src.Width - 1; x++)
                {
                    double getRed = 0;
                    double getGreen = 0;
                    double getBlue = 0;
                    double gamma = 3.0;
                    double c = 255 * Math.Pow(255, -gamma);

                    getRed = Cv.GetReal2D(OriRed, y, x);
                    getGreen = Cv.GetReal2D(OriGreen, y, x);
                    getBlue = Cv.GetReal2D(OriBlue, y, x);

                    double r = c * Math.Pow(getRed, gamma);
                    double g = c * Math.Pow(getGreen, gamma);
                    double b = c * Math.Pow(getBlue, gamma);

                    Cv.SetReal2D(resultedRed, y, x, r);
                    Cv.SetReal2D(resultedGreen, y, x, g);
                    Cv.SetReal2D(resultedBlue, y, x, b);

                }
            }
            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, resultedImage);

            Cv.SaveImage("6.jpg", resultedImage);

        }

        public void grayLevel()
        {
            OriRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            OriBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.Split(src, OriRed, OriGreen, OriBlue, null);

            resultedRed = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedGreen = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            resultedBlue = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            resultedImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            for (int y = 1; y < src.Height - 1; y++)
            {
                for (int x = 1; x < src.Width - 1; x++)
                {
                    double getRed = 0;
                    double getGreen = 0;
                    double getBlue = 0;
                    double A = 175;
                    double B = 200;

                    getRed = Cv.GetReal2D(OriRed, y, x);
                    getGreen = Cv.GetReal2D(OriGreen, y, x);
                    getBlue = Cv.GetReal2D(OriBlue, y, x);

                    if ((getRed>=A) && (getRed <= B))
                    {
                        getRed = 255;
                    }
                    else
                    {
                        getRed = 20;
                    }
                    if ((getGreen >= A) && (getGreen <= B))
                    {
                        getGreen = 255;
                    }
                    else
                    {
                        getGreen = 20;
                    }
                    if ((getBlue >= A) && (getBlue <= B))
                    {
                        getBlue = 255;
                    }
                    else
                    {
                        getBlue = 20;
                    }

                    Cv.SetReal2D(resultedRed, y, x, getRed);
                    Cv.SetReal2D(resultedGreen, y, x, getGreen);
                    Cv.SetReal2D(resultedBlue, y, x, getBlue);

                }
            }
            Cv.Merge(resultedRed, resultedGreen, resultedBlue, null, resultedImage);

            Cv.SaveImage("7.jpg", resultedImage);

        }

        public void drawHistogram()
        {
            float[] range = { 0, 255 };
            float[][] ranges = { range };
            int hist_size = 255;
            float min, max = 0;

            IplImage gray = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, gray, ColorConversion.RgbaToGray);

            //To create an image to hold the histogram image
            IplImage histogram = Cv.CreateImage(gray.Size, BitDepth.U8, 1);

            //To create a hist variable to store the information from the image  
            CvHistogram hist = Cv.CreateHist(new int[] { hist_size },HistogramFormat.Array,ranges,true);

            //To Calculate the histogram and apply to hist
            Cv.CalcHist(gray, hist);

            //To Grab the minimum and the maximum values 
            Cv.GetMinMaxHistValue(hist, out min,out max);

            //Scale the bin values so that they will fit in the Image Representation.
            Cv.Scale(hist.Bins, hist.Bins,(double)histogram.Height/max,0);

            histogram.Set(CvColor.White);

            int bin_w = Cv.Round((double)histogram.Width / hist_size);

            for (int i=0;i<hist_size;i++)
            {
                histogram.Rectangle(new CvPoint(i * bin_w, gray.Height),new CvPoint((i+1) * bin_w,gray.Height-Cv.Round(hist.Bins[i])),CvColor.Black,1,LineType.Link8,0);
                ;
           
            }

            Cv.SaveImage("hist.jpg",histogram);

        }
    }
        
}
