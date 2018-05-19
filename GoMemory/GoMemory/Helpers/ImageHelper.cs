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
                new ImagePath{Path =   imagesPath +   "apple.png",Name = "apple" },
                new ImagePath{Path =  imagesPath +  "beer.png", Name = "beer" },
                new ImagePath{Path =  imagesPath +  "bell.png", Name = "bell" },
                new ImagePath{Path =  imagesPath + "bison.png", Name = "bison" },
                new ImagePath{Path =  imagesPath + "cake.png", Name = "cake" },
                new ImagePath{Path =  imagesPath +  "camera.png", Name = "camera" },
                new ImagePath{Path =  imagesPath +  "carrot.png", Name = "carrot" },
                new ImagePath{Path =  imagesPath +  "cheese.png", Name = "cheese" },
                new ImagePath{Path =  imagesPath +  "chocolate.png", Name = "chocolate" },
                new ImagePath{Path =  imagesPath +  "clock.png", Name = "clock" },
                new ImagePath{Path =  imagesPath +  "codfish.png", Name = "codfish" },
                new ImagePath{Path =  imagesPath +  "crab.png", Name = "crab" },
                new ImagePath{Path =  imagesPath +  "egg.png", Name = "egg" },
                new ImagePath{Path =  imagesPath +  "frog.png", Name = "frog" },
                new ImagePath{Path =  imagesPath +  "hammer.png", Name = "hammer" },
                new ImagePath{Path =  imagesPath +  "lightbulb.png", Name = "lightbulb" },
                new ImagePath{Path =  imagesPath +  "lightning.png", Name = "lightning" },
                new ImagePath{Path =  imagesPath +  "lolly.png", Name = "lolly" },
                new ImagePath{Path =  imagesPath +  "microphone.png", Name = "mircophone" },
                new ImagePath{Path =  imagesPath +  "milkshake.png", Name = "milkshake" },
                new ImagePath{Path =  imagesPath +  "orange.png", Name = "orange" },
                new ImagePath{Path =  imagesPath +  "parrot.png", Name = "parrot" },
                new ImagePath{Path =  imagesPath +  "phone.png", Name = "phone" },
                new ImagePath{Path =  imagesPath +  "pig.png", Name = "pig" },
                new ImagePath{Path =  imagesPath +  "portobello.png", Name = "portobello" },
                new ImagePath{Path =  imagesPath +  "rabbit.png", Name = "rabbit" },
                new ImagePath{Path =  imagesPath +  "robots.png", Name = "robots" },
                new ImagePath{Path =  imagesPath +  "sausage.png", Name = "sausage" },
                new ImagePath{Path =  imagesPath +  "scissors.png", Name = "scissors" },
                new ImagePath{Path =  imagesPath +  "spider.png", Name = "spider" },
                new ImagePath{Path =  imagesPath +  "star.png", Name = "star" },
                new ImagePath{Path =  imagesPath +  "strawberry.png", Name = "strawberry" },
                new ImagePath{Path =  imagesPath +  "teapot.png", Name = "teapot" },
                new ImagePath{Path =  imagesPath +  "wasp.png", Name = "wasp" },
                new ImagePath{Path =  imagesPath +  "watermelon.png", Name = "watermelon" },
                new ImagePath{Path =  imagesPath +  "wine.png",Name = "wine"}

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
