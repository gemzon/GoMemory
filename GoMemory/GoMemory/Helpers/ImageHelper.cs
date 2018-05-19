using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.Helpers
{
    public class ImageHelper
    {
        private readonly ImagePath[] _images;
        public ImageHelper()
        {

            const string imagesPath = "GoMemory.Images.GameImages.";
            //Uri  imagesPath = new Uri( "ms-appx:///Images/");
            _images = new[]
            {
                new ImagePath{Path =   imagesPath +   "apple.png"},
                new ImagePath{Path =  imagesPath +  "beer.png"},
                new ImagePath{Path =  imagesPath +  "bell.png"},
                new ImagePath{Path =  imagesPath + "bison.png"},
                new ImagePath{Path =  imagesPath + "cake.png"},
                new ImagePath{Path =  imagesPath +  "camera.png"},
                new ImagePath{Path =  imagesPath +  "carrot.png"},
                new ImagePath{Path =  imagesPath +  "cheese.png"},
                new ImagePath{Path =  imagesPath +  "chocolate.png"},
                new ImagePath{Path =  imagesPath +  "clock.png"},
                new ImagePath{Path =  imagesPath +  "codfish.png"},
                new ImagePath{Path =  imagesPath +  "crab.png"},
                new ImagePath{Path =  imagesPath +  "egg.png"},
                new ImagePath{Path =  imagesPath +  "frog.png"},
                new ImagePath{Path =  imagesPath +  "hammer.png"},
                new ImagePath{Path =  imagesPath +  "lightbulb.png"},
                new ImagePath{Path =  imagesPath +  "lightning.png"},
                new ImagePath{Path =  imagesPath +  "lolly.png"},
                new ImagePath{Path =  imagesPath +  "microphone.png"},
                new ImagePath{Path =  imagesPath +  "milkshake.png"},
                new ImagePath{Path =  imagesPath +  "orange.png"},
                new ImagePath{Path =  imagesPath +  "parrot.png"},
                new ImagePath{Path =  imagesPath +  "phone.png"},
                new ImagePath{Path =  imagesPath +  "pig.png"},
                new ImagePath{Path =  imagesPath +  "portobello.png"},
                new ImagePath{Path =  imagesPath +  "rabbit.png"},
                new ImagePath{Path =  imagesPath +  "robots.png"},
                new ImagePath{Path =  imagesPath +  "sausage.png"},
                new ImagePath{Path =  imagesPath +  "scissors.png"},
                new ImagePath{Path =  imagesPath +  "spider.png"},
                new ImagePath{Path =  imagesPath +  "star.png"},
                new ImagePath{Path =  imagesPath +  "strawberry.png"},
                new ImagePath{Path =  imagesPath +  "teapot.png"},
                new ImagePath{Path =  imagesPath +  "wasp.png"},
                new ImagePath{Path =  imagesPath +  "watermelon.png"},
                new ImagePath{Path =  imagesPath +  "wine.png"}

            };
        }


      



        /// <summary>
        /// zero argument method for getting a unmodified ObservableCollection of Image
        /// </summary>
        /// <returns>
        /// ObservableCollection of Image
        /// </returns>
        public ImagePath[] GetImages()
        {
            return _images;
        }

        /// <summary>
        /// Randomize the order of a Image Array
        /// </summary>
        /// <returns>
        /// ObservableCollection of Image
        /// </returns>
        public ImagePath[] ShuffleCollection()
        {
            Random rnd = new Random();
            ImagePath[] unsorted = _images;
            for (int i = 0; i < unsorted.Length; i++)
            {
                ImagePath temp = unsorted[i];
                int randomIndex = rnd.Next(0, _images.Length);
                unsorted[i] = unsorted[randomIndex];
                unsorted[randomIndex] = temp;
            }
            return unsorted;
        }



        /// <summary>
        /// Select a defined amount of random Image for game-play 
        /// </summary>
        /// <returns>
        /// Array of Image
        /// </returns>
        public List<ImagePath> ToMatchImages(int numberOfImagesNeeded)
        {

            List<ImagePath> matchImages = new List<ImagePath>();

            Random rnd = new Random();

            int count = 0;
            while (count != numberOfImagesNeeded)
            {
                ImagePath selectedImage = _images[rnd.Next(0, _images.Length)];
                if (matchImages.Contains(selectedImage)) continue;
                matchImages.Add(selectedImage);
                count++;

            }

            return matchImages;

        }

        //public void imageget()
        //{
        //    Uri imagefolder ;
        //    switch (Device.RuntimePlatform)
        //    {
        //        case Device.iOS:

        //            break;
        //        case Device.Android:
        //        case Device.UWP:
        //            imagefolder = "ms-appx:///Images/";

        //        default:
        //            break;
        //    };
               
        //}
    }
}
