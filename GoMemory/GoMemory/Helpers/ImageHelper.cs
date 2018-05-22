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
        public Image GameOverImage { get; set; }
        public Image CompleteImage { get; set; }
        public ImageHelper()
        {

          //  const string imagesPath = "GoMemory.Images.Images.";
            //Uri  imagesPath = new Uri( "ms-appx:///Images/");
            string folder = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    folder = "";
                    break;
                case Device.Android:
                    folder = "";
                    break;
                default:
                    folder = "Images/";
                    break;
            }
            GameOverImage = new Image{ Source = folder + "gameover.png" };
            CompleteImage = new Image { Source = folder + "complete.png" };
            _images = new[]
            {
                
                new Image{Source = folder +    "apple.png"},
                new Image{Source = folder +  "beer.png"},
                new Image{Source = folder +  "bell.png"},
                new Image{Source = folder +  "bison.png"},
                new Image{Source = folder +  "cake.png"},
                new Image{Source = folder +   "camera.png"},
                new Image{Source = folder +   "carrot.png"},
                new Image{Source = folder +   "cheese.png"},
                new Image{Source = folder +   "chocolate.png"},
                new Image{Source = folder +   "clock.png"},
                new Image{Source = folder +   "codfish.png"},
                new Image{Source = folder +   "crab.png"},
                new Image{Source = folder +   "egg.png"},
                new Image{Source = folder +   "frog.png"},
                new Image{Source = folder +   "hammer.png"},
                new Image{Source = folder +   "lightbulb.png"},
                new Image{Source = folder +   "lightning.png"},
                new Image{Source = folder +   "lolly.png"},
                new Image{Source = folder +   "microphone.png"},
                new Image{Source = folder +   "milkshake.png"},
                new Image{Source = folder +   "orange.png"},
                new Image{Source = folder +   "parrot.png"},
                new Image{Source = folder +   "phone.png"},
                new Image{Source = folder +   "pig.png"},
                new Image{Source = folder +   "portobello.png"},
                new Image{Source = folder +   "rabbit.png"},
                new Image{Source = folder +   "robots.png"},
                new Image{Source = folder +   "sausage.png"},
                new Image{Source = folder +   "scissors.png"},
                new Image{Source = folder +   "spider.png"},
                new Image{Source = folder +   "star.png"},
                new Image{Source = folder +   "strawberry.png"},
                new Image{Source = folder +   "teapot.png"},
                new Image{Source = folder +   "wasp.png"},
                new Image{Source = folder +   "watermelon.png"},
                new Image{Source = folder +   "wine.png"}

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
           Image[] shuffled =  ShuffleCollection(_images);
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
        public Image[] ShuffleCollection(Image[] imageArray)
        {
            Random rnd = new Random();
            Image[] unsorted = imageArray;
            for (int i = 0; i < unsorted.Length; i++)
            {
                Image temp = unsorted[i];
                int randomIndex = rnd.Next(0, imageArray.Length);
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
        public List<Image> ToMatchImagesList(int numberOfImagesNeeded,Image[] images)
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

        public Image[] ToMatchImagesArray(Image[]selectFromImages )
        {
            Random rnd = new Random();
            int maxIndex = selectFromImages.Length;
            Image[] matchImages = new Image[maxIndex];
            for (int i = 0; i < selectFromImages.Length; i++)
            {
                Image selectedImage = selectFromImages[rnd.Next(0, maxIndex)];
                if (matchImages.Contains(selectedImage)) continue;
                matchImages[i] =selectedImage;
            }
            return matchImages;

        }
    }
}
