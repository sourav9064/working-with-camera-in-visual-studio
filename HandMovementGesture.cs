using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OpenCvSharp;


namespace Working_WithCamera
{
    class HandMovementGesture
    {
        VideoCapture videoCapture;

        public void Init()
        {
            //Initialise the video capture module
            videoCapture = new VideoCapture(0);
            videoCapture.Set(3, 640); //Set the frame width
            videoCapture.Set(4, 480); //Set the frame height
        }

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

        private Mat EdgeDetect(Mat image)
        {
            Mat edgeDetect = new Mat();
            Cv2.Canny(image, edgeDetect, 150, 250);
            //Cv2.Laplacian(image, edgeDetect, MatType.CV_32F);
            return edgeDetect;
        }

        //private class HsvSkinDetector(){

        public void ShowVideo()
        {
            Mat image;
            while (true)
            {
                image = GrabFrame();
                Mat gray = ConvertGrayScale(image);
                Mat edge = EdgeDetect(gray);

                Cv2.ImShow("frame", edge);
                if (Cv2.WaitKey(1) == (int)27)//(int)ConsoleKey.Enter)
                    break;
            }
        }


        public void Release()
        {
            videoCapture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
