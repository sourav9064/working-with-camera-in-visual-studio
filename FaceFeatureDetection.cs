//Real Time Face Eye Lips Detection
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Working_WithCamera
{
    class FaceFeatureDetection
    {
        VideoCapture videoCapture;
        CascadeClassifier face_cascade;
        CascadeClassifier eyes_cascade;
        CascadeClassifier lips_cascade;

        public void Init()
        {
            //Initialise the video capture module
            videoCapture = new VideoCapture(0);
            videoCapture.Set(3, 640); //Set the frame width
            videoCapture.Set(4, 480); //Set the frame height

            //Define the face and eyes and lips classifies using Haar-cascade xml
            face_cascade = new CascadeClassifier("C:/Users/HP/haarcascades/haarcascade_frontalface_default.xml");
            eyes_cascade = new CascadeClassifier("C:/Users/HP/haarcascades/haarcascade_eye.xml");
            lips_cascade = new CascadeClassifier("C:/Users/HP/haarcascades/haarcascade_smile.xml");
        }

        class FaceFeature
        {
            public Rect Face { get; set; }
            public Rect[] Eyes { get; set; }
            public Rect[] Lips { get; set; }
        }

        List<FaceFeature> features = new List<FaceFeature>();

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

        private Rect[] DetectFaces(Mat image)
        {
            //Detect the faces from the images using Cascade classifier
            Rect[] faces = face_cascade.DetectMultiScale(image, 1.3, 5);
            return faces;
        }

        private Rect[] DetectEyes(Mat image)
        {
            //Detect the eyes from the detected face
            Rect[] eyes = eyes_cascade.DetectMultiScale(image);
            return eyes;
        }

        private Rect[] DetectLips(Mat image)
        {
            //Detect the likps from the detected face
            Rect[] lips = lips_cascade.DetectMultiScale(image);
            return lips;
        }

        private void MarkFeatures(Mat image)
        {
            //Mark the features of the image by showing in rectangles
            foreach (FaceFeature feature in features)
            {
                Cv2.Rectangle(image, feature.Face, new Scalar(0, 255, 0), thickness: 2);
                var face_region = image[feature.Face];
                foreach (var eye in feature.Eyes)
                {
                    Cv2.Rectangle(face_region, eye, new Scalar(255, 0, 0), thickness: 2);
                }
                foreach (var lips in feature.Lips)
                {
                    Cv2.Rectangle(face_region, lips, new Scalar(0, 0, 255), thickness: 2);
                }
            }
        }

        public void DetectFeatures()
        {
            Mat image;
            while (true)
            {
                //Grab the current frame
                image = GrabFrame();
                //Convert to gray scale to improve the image processing
                Mat gray = ConvertGrayScale(image);
                //Detect faces using Cascase classifier
                Rect[] faces = DetectFaces(gray);
                if (image.Empty())
                    continue;
                //Loop through detected faces
                foreach (var item in faces)
                {
                    //Get the region of interest where you can find facial features
                    Mat face_roi = gray[item];

                    //Detect eyes
                    Rect[] eyes = DetectEyes(face_roi);

                    //Detect lips
                    Rect[] lips = DetectLips(face_roi);

                    //Record the facial features in a list
                    features.Add(new FaceFeature()
                    {
                        Face = item,
                        Eyes = eyes,
                        Lips = lips
                    });
                }
                //Mark the detected feature on the original frame
                MarkFeatures(image);
                Cv2.ImShow("frame", image);
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
