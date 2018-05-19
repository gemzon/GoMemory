using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.Helpers
{
    public class ImageHelper
    {
        private readonly GameImage[] _images;
        public ImageHelper()
        {
           // const string new Uri ( imagesPath = "GoMemory.Images.GameImages.";
             //Uri  imagesPath = new Uri( "ms-appx:///GameImages/");
            _images = new[]
            {
                new GameImage{Location =  new Uri ( imagesPath +   "apple.png"), Name = "apple"},
                new GameImage{Location =  new Uri ( imagesPath +  "beer.png"), Name = "beer"},
                new GameImage{Location =  new Uri ( imagesPath +  "bell.png"), Name = "bell"},
                new GameImage{Location =  new Uri ( imagesPath + "bison.png"), Name = "bison"},
                new GameImage{Location =  new Uri ( imagesPath + "cake.png"), Name = "cake"},
                new GameImage{Location =  new Uri ( imagesPath +  "camera.png"), Name = "camera"},
                new GameImage{Location =  new Uri ( imagesPath +  "carrot.png"), Name = "carrot"},
                new GameImage{Location =  new Uri ( imagesPath +  "cheese.png"), Name = "cheese"},
                new GameImage{Location =  new Uri ( imagesPath +  "chocolate.png"), Name = "chocolate"},
                new GameImage{Location =  new Uri ( imagesPath +  "clock.png"), Name = "clock"},
                new GameImage{Location =  new Uri ( imagesPath +  "codfish.png"), Name = "codfish"},
                new GameImage{Location =  new Uri ( imagesPath +  "crab.png"), Name = "crab"},
                new GameImage{Location =  new Uri ( imagesPath +  "egg.png"), Name = "egg"},
                new GameImage{Location =  new Uri ( imagesPath +  "frog.png"), Name = "frog"},
                new GameImage{Location =  new Uri ( imagesPath +  "hammer.png"), Name = "hammer"},
                new GameImage{Location =  new Uri ( imagesPath +  "lightbulb.png"), Name = "lightbulb"},
                new GameImage{Location =  new Uri ( imagesPath +  "lightning.png"), Name = "lightning"},
                new GameImage{Location =  new Uri ( imagesPath +  "lolly.png"), Name = "lolly"},
                new GameImage{Location =  new Uri ( imagesPath +  "microphone.png"), Name = "microphone"},
                new GameImage{Location =  new Uri ( imagesPath +  "milkshake.png"), Name = "milkshake"},
                new GameImage{Location =  new Uri ( imagesPath +  "orange.png"), Name = "orange"},
                new GameImage{Location =  new Uri ( imagesPath +  "parrot.png"), Name = "parrot"},
                new GameImage{Location =  new Uri ( imagesPath +  "phone.png"), Name = "phone"},
                new GameImage{Location =  new Uri ( imagesPath +  "pig.png"), Name = "pig"},
                new GameImage{Location =  new Uri ( imagesPath +  "portobello.png"), Name = "portobello"},
                new GameImage{Location =  new Uri ( imagesPath +  "rabbit.png"), Name = "rabbit"},
                new GameImage{Location =  new Uri ( imagesPath +  "robots.png"), Name = "robots"},
                new GameImage{Location =  new Uri ( imagesPath +  "sausage.png"), Name = "sausage"},
                new GameImage{Location =  new Uri ( imagesPath +  "scissors.png"), Name = "scissors"},
                new GameImage{Location =  new Uri ( imagesPath +  "spider.png"), Name = "spider"},
                new GameImage{Location =  new Uri ( imagesPath +  "star.png"), Name = "star"},
                new GameImage{Location =  new Uri ( imagesPath +  "strawberry.png"), Name = "strawberry"},
                new GameImage{Location =  new Uri ( imagesPath +  "teapot.png"), Name = "teapot"},
                new GameImage{Location =  new Uri ( imagesPath +  "wasp.png"), Name = "wasp"},
                new GameImage{Location =  new Uri ( imagesPath +  "watermelon.png"), Name = "watermelon"},
                new GameImage{Location =  new Uri ( imagesPath +  "wine.png"), Name = "wine"}

            };
        }

        /// <summary>
        /// zero argument method for getting a unmodified ObservableCollection of GameImage
        /// </summary>
        /// <returns>
        /// ObservableCollection of GameImage
        /// </returns>
        public GameImage[] GetImages()
        {
            return _images;
        }

        /// <summary>
        /// Randomize the order of a GameImage Array
        /// </summary>
        /// <returns>
        /// ObservableCollection of GameImage
        /// </returns>
        public GameImage[] ShuffleCollection()
        {
            Random rnd = new Random();
            GameImage[] unsorted = _images;
            for (int i = 0; i < unsorted.Length; i++)
            {
                GameImage temp = unsorted[i];
                int randomIndex = rnd.Next(0, _images.Length);
                unsorted[i] = unsorted[randomIndex];
                unsorted[randomIndex] = temp;
            }
            return unsorted;
        }



        /// <summary>
        /// Select a defined amount of random GameImage for game-play 
        /// </summary>
        /// <returns>
        /// Array of GameImage
        /// </returns>
        public List<GameImage> ToMatchGameImages(int numberOfImagesNeeded)
        {

            List<GameImage> matchImages = new List<GameImage>();

            Random rnd = new Random();

            int count = 0;
            while (count != numberOfImagesNeeded)
            {
                GameImage selectedImage = _images[rnd.Next(0, _images.Length)];
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
        //            imagefolder = "ms-appx:///GameImages/";

        //        default:
        //            break;
        //    };
               
        //}
    }
}
