//Canny Edge Detection

using System;

namespace Working_WithCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            /*//CameraModule.cs
            CameraModule cameraModule = new CameraModule();
            try
            {
                cameraModule.Init();
                var capturedImage = cameraModule.Capture(save: true);
                var manipulatedImage = cameraModule.Manipulate(capturedImage);
                cameraModule.ShowImage(capturedImage);
                cameraModule.ShowImage(manipulatedImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops something happened! {0}", ex.Message);
            }
            finally
            {
                cameraModule.Release();
            }*/

            /*//FaceFeatureDetection.cs
            FaceFeatureDetection faceFeatureDetection = new FaceFeatureDetection();
            faceFeatureDetection.Init();
            faceFeatureDetection.DetectFeatures();
            //Console.WriteLine("Face Detected {0}");
            faceFeatureDetection.Release();*/

            /*//EdgeMovement.cs
            EdgeMovement edgeMovement = new EdgeMovement();
            edgeMovement.Init();
            edgeMovement.ShowImage();
            edgeMovement.Release();*/

            /*//HandMovementGesture.cs
            HandMovementGesture handMovementGesture = new HandMovementGesture();
            handMovementGesture.Init();
            handMovementGesture.ShowVideo();
            handMovementGesture.Release();*/

            /*//MovementDetect.cs
            MovementDetect movementDetect = new MovementDetect();
            movementDetect.Main();*/

            //EdgeDetect.cs
            EdgeDetect edgeDetect = new EdgeDetect();
            edgeDetect.Main();

        }
    }
}
