using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp; 

namespace WindowsFormsApp1
{
    class test
    {
        IplImage src, gray, binary;
           public void loadOriginalImage(){
                src = Cv.LoadImage("apples.jpg", LoadMode.Color);
                Cv.SaveImage("apples-backup.jpg", src);
           }

           public void grayScale(){

                gray = Cv.CreateImage(src.Size, BitDepth.U8, 1);
                Cv.CvtColor(src, gray, ColorConversion.RgbToGray);
                Cv.SaveImage("grayimage.jpg", gray);
            }

            public void GrayToBinary(int t){

                grayScale();
                binary = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
                Cv.Threshold(gray, binary, t, 255, ThresholdType.Binary);
                Cv.SaveImage("binaryimage.jpg", binary);
            }
            
            public void Negative(){

                
            }

    }
}
