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
        private readonly Image[] _images;
        public ImageHelper()
        {

          //  const string imagesPath = "GoMemory.Images.Images.";
            //Uri  imagesPath = new Uri( "ms-appx:///Images/");
            _images = new[]
            {
                
                new Image{Source =   "apple.png"},
                new Image{Source =  "beer.png"},
                new Image{Source =  "bell.png"},
                new Image{Source =  "bison.png"},
                new Image{Source =  "cake.png"},
                new Image{Source =   "camera.png"},
                new Image{Source =   "carrot.png"},
                new Image{Source =   "cheese.png"},
                new Image{Source =   "chocolate.png"},
                new Image{Source =   "clock.png"},
                new Image{Source =   "codfish.png"},
                new Image{Source =   "crab.png"},
                new Image{Source =   "egg.png"},
                new Image{Source =   "frog.png"},
                new Image{Source =   "hammer.png"},
                new Image{Source =   "lightbulb.png"},
                new Image{Source =   "lightning.png"},
                new Image{Source =   "lolly.png"},
                new Image{Source =   "microphone.png"},
                new Image{Source =   "milkshake.png"},
                new Image{Source =   "orange.png"},
                new Image{Source =   "parrot.png"},
                new Image{Source =   "phone.png"},
                new Image{Source =   "pig.png"},
                new Image{Source =   "portobello.png"},
                new Image{Source =   "rabbit.png"},
                new Image{Source =   "robots.png"},
                new Image{Source =   "sausage.png"},
                new Image{Source =   "scissors.png"},
                new Image{Source =   "spider.png"},
                new Image{Source =   "star.png"},
                new Image{Source =   "strawberry.png"},
                new Image{Source =   "teapot.png"},
                new Image{Source =   "wasp.png"},
                new Image{Source =   "watermelon.png"},
                new Image{Source =   "wine.png"}

            };
        }


      



        /// <summary>
        /// zero argument method for getting a unmodified ObservableCollection of Image
        /// </summary>
        /// <returns>
        /// ObservableCollection of Image
        /// </returns>
        public Image[] GetImages(int totalImages)
        {
           Image[] shuffled =  ShuffleCollection();
            Image[] unsorted = new Image[totalImages];
            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted[i] = shuffled[i];
            }
            return unsorted;
        }

        /// <summary>
        /// Randomize the order of a Image Array
        /// </summary>
        /// <returns>
        /// ObservableCollection of Image
        /// </returns>
        public Image[] ShuffleCollection()
        {
            Random rnd = new Random();
            Image[] unsorted = _images;
            for (int i = 0; i < unsorted.Length; i++)
            {
                Image temp = unsorted[i];
                int randomIndex = rnd.Next(0, _images.Length);
                unsorted[i] = unsorted[randomIndex];
                unsorted[randomIndex] = temp;
            }
            return  unsorted;
        }



        /// <summary>
        /// Select a defined amount of random Image for game-play 
        /// </summary>
        /// <returns>
        /// Array of Image
        /// </returns>
        public List<Image> ToMatchImages(int numberOfImagesNeeded,Image[] images) 
        {

            List<Image> matchImages = new List<Image>();

            Random rnd = new Random();

            int count = 0;
            while (count != numberOfImagesNeeded)
            {
                Image selectedImage = images[rnd.Next(0, images.Length)];
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
