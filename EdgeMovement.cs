//Real time Edge Detection
using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;

namespace Working_WithCamera
{
    class EdgeMovement
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

        public Mat CannyDetect(Mat image)
        {
            //Initialise a new Mat variable to store the edge detected image
            Mat edgeDetection = new Mat();
            //Run Canny algorithm to detect the edges with two threshold values. 
            //Cv2.Canny(image, edgeDetection, 100, 200);
            Cv2.Canny(image, edgeDetection, 150, 250);
            return edgeDetection;
        }

        /*private void MarkFeatures(Mat image)
        {
            Cv2.Rectangle(image, feature.Face, new Scalar(0, 255, 0), thickness: 2);

        }*/

        public void ShowImage()
        {
            Mat image;
            while (true)
            {
                image = GrabFrame();
                Mat gray = ConvertGrayScale(image);
                Mat detect = CannyDetect(gray);

                Cv2.ImShow("frame", detect);
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
