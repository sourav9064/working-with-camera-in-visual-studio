using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;

namespace Working_WithCamera
{
    class EdgeDetect
    {
        VideoCapture videoCapture;

        private Mat GrabFrame()
        {
            Mat image = new Mat();
            //Capture frame by frame
            videoCapture.Read(image);
            return image;
        }

        private Mat ConvertGrayScale(Mat image)
        {
            Mat gray = new Mat();
            //Convert the image to Grayscale
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            return gray;
        }

        private Mat ConvertLaplace(Mat gray)
        {
            Mat laplace = new Mat();
            //Convert the image to Laplacian
            Cv2.Laplacian(gray, laplace, MatType.CV_64F);
            return laplace;
        }

        private Mat ConvertSobel(Mat gray)
        {
            Mat sobel = new Mat();
            //Sobel algorithm
            Cv2.Sobel(gray, sobel, MatType.CV_64F, 0, 1);
            return sobel;
        }

        /*private Mat ConvertTopHat(Mat gray)
        {
            Mat tophat = new Mat();
            InputArray kernel = InputArray.Create(new Scalar(5, 5));
            //Transformation using Top Hat technique
            Cv2.MorphologyEx(gray, tophat, MorphTypes.TopHat, kernel);
            return tophat;
        }

        private Mat ConvertErode(Mat gray)
        {
            Mat erode = new Mat();
            InputArray kernel = InputArray.Create(new Scalar(5, 5));
            //Transformation using Erode technique
            Cv2.MorphologyEx(gray, erode, MorphTypes.Erode, kernel);
            return erode;
        }

        private Mat ConvertGradient(Mat gray)
        {
            Mat gradient = new Mat();
            InputArray kernel = InputArray.Create(new Scalar(5, 5));
            //Transformation using Gradient technique
            Cv2.MorphologyEx(gray, gradient, MorphTypes.Gradient, kernel);
            return gradient;
        }

        private Mat ConvertDilate(Mat gray)
        {
            Mat dilate = new Mat();
            InputArray kernel = InputArray.Create(new Scalar(5, 5));
            //Transformation using Dilate technique
            Cv2.MorphologyEx(gray, dilate, MorphTypes.Dilate, kernel);
            return dilate;
        }*/

        public void Main()
        {
            videoCapture = new VideoCapture(0);
            videoCapture.Set(3, 640);
            videoCapture.Set(4, 480);

            Mat image;
            while (true)
            {
                image = GrabFrame();
                Mat gray = ConvertGrayScale(image);
                Mat edge1 = ConvertLaplace(gray);
                Mat edge2 = ConvertSobel(gray);
                /*Mat edge3 = ConvertTopHat(gray);
                Mat edge4 = ConvertErode(gray);
                Mat edge5 = ConvertGradient(gray);
                Mat edge6 = ConvertDilate(gray);*/


                Cv2.ImShow("frame", image);
                Cv2.ImShow("frame_gray", gray);
                Cv2.ImShow("frame_laplace", edge1);
                Cv2.ImShow("frame_sobel", edge2);
                /*Cv2.ImShow("frame_tophat", edge3);
                Cv2.ImShow("frame_erode", edge4);
                Cv2.ImShow("frame_gradient", edge5);
                Cv2.ImShow("frame_dilate", edge6);*/

                if (Cv2.WaitKey(1) == (int)27)//(int)ConsoleKey.Enter)
                    break;

                videoCapture.Release();
                Cv2.DestroyAllWindows();
            }

        }
    }
}
