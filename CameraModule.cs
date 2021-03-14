//Face eye detection in picture mode
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Working_WithCamera
{
    class CameraModule
    {
        FrameSource frameSource;
        public void Init()
        {
            frameSource = Cv2.CreateFrameSource_Camera(0);
        }

        public Mat Capture(bool save)
        {
            //Initialise the image matrix
            Mat img = new Mat();
            //Grab the frame to the img variable
            frameSource.NextFrame(img);

            /*//Check save variable is true
            if (save)
            {
                string imagePath = string.Format("{0}\\cam.jpg", AppDomain.CurrentDomain.BaseDirectory);
                //Save the captured image
                img.SaveImage(imagePath);
            }*/

            return img;
        }

        public Mat Manipulate(Mat image)
        {
            //Initialise a new Mat variable to store the edge detected image
            Mat edgeDetection = new Mat();

            //Run Canny algorithm to detect the edges with two threshold values. 
            //Cv2.Canny(image, edgeDetection, 100, 200);
            Cv2.Canny(image, edgeDetection, 150, 250);
            return edgeDetection;
        }

        public void ShowImage(Mat image)
        {
            Cv2.ImShow("img", image);
            Cv2.WaitKey(0);
        }
        public void Release()
        {
            Cv2.DestroyAllWindows();
        }
    }
}
