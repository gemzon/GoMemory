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
            const string imagesPath = "GoMemory.Images.GameImages.";
            _images = new[]
            {
                new GameImage{Location =  imagesPath +   "apple.png", Name = "apple"},
                new GameImage{Location =  imagesPath +  "beer.png", Name = "beer"},
                new GameImage{Location =  imagesPath +  "bell.png", Name = "bell"},
                new GameImage{Location =  imagesPath + "bison.png", Name = "bison"},
                new GameImage{Location =  imagesPath + "cake.png", Name = "cake"},
                new GameImage{Location =  imagesPath +  "camera.png", Name = "camera"},
                new GameImage{Location =  imagesPath +  "carrot.png", Name = "carrot"},
                new GameImage{Location =  imagesPath +  "cheese.png", Name = "cheese"},
                new GameImage{Location =  imagesPath +  "chocolate.png", Name = "chocolate"},
                new GameImage{Location =  imagesPath +  "clock.png", Name = "clock"},
                new GameImage{Location =  imagesPath +  "codfish.png", Name = "codfish"},
                new GameImage{Location =  imagesPath +  "crab.png", Name = "crab"},
                new GameImage{Location =  imagesPath +  "egg.png", Name = "egg"},
                new GameImage{Location =  imagesPath +  "frog.png", Name = "frog"},
                new GameImage{Location =  imagesPath +  "hammer.png", Name = "hammer"},
                new GameImage{Location =  imagesPath +  "lightbulb.png", Name = "lightbulb"},
                new GameImage{Location =  imagesPath +  "lightning.png", Name = "lightning"},
                new GameImage{Location =  imagesPath +  "lolly.png", Name = "lolly"},
                new GameImage{Location =  imagesPath +  "microphone.png", Name = "microphone"},
                new GameImage{Location =  imagesPath +  "milkshake.png", Name = "milkshake"},
                new GameImage{Location =  imagesPath +  "orange.png", Name = "orange"},
                new GameImage{Location =  imagesPath +  "parrot.png", Name = "parrot"},
                new GameImage{Location =  imagesPath +  "phone.png", Name = "phone"},
                new GameImage{Location =  imagesPath +  "pig.png", Name = "pig"},
                new GameImage{Location =  imagesPath +  "portobello.png", Name = "portobello"},
                new GameImage{Location =  imagesPath +  "rabbit.png", Name = "rabbit"},
                new GameImage{Location =  imagesPath +  "robots.png", Name = "robots"},
                new GameImage{Location =  imagesPath +  "sausage.png", Name = "sausage"},
                new GameImage{Location =  imagesPath +  "scissors.png", Name = "scissors"},
                new GameImage{Location =  imagesPath +  "spider.png", Name = "spider"},
                new GameImage{Location =  imagesPath +  "star.png", Name = "star"},
                new GameImage{Location =  imagesPath +  "strawberry.png", Name = "strawberry"},
                new GameImage{Location =  imagesPath +  "teapot.png", Name = "teapot"},
                new GameImage{Location =  imagesPath +  "wasp.png", Name = "wasp"},
                new GameImage{Location =  imagesPath +  "watermelon.png", Name = "watermelon"},
                new GameImage{Location =  imagesPath +  "wine.png", Name = "wine"}

            };
        }

        /// <summary>
        /// zero argument method for getting a unmodified ObservableCollection of GameImage
        /// </summary>
        /// <returns>
        /// ObservableCollection of GameImage
        /// </returns>
        public ObservableCollection<GameImage> GetImages()
        {
            return ConvertArrayToObservableCollection(_images);
        }

        /// <summary>
        /// Randomize the order of a GameImage Array
        /// </summary>
        /// <returns>
        /// ObservableCollection of GameImage
        /// </returns>
        public ObservableCollection<GameImage> ShuffleCollection()
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
            return ConvertArrayToObservableCollection(unsorted);
        }


        /// <summary>
        /// Converts GameImage Array to Observable Collection of GameImage
        /// </summary>
        /// <returns>
        /// ObservableCollection of GameImage
        /// </returns>
        public ObservableCollection<GameImage> ConvertArrayToObservableCollection(GameImage[] array)
        {
            ObservableCollection<GameImage> collection = new ObservableCollection<GameImage>();
            foreach (var gameImage in array)
            {
                collection.Add(gameImage);
            }

            return collection;
        }

        /// <summary>
        /// Select a defined amount of random GameImage for game-play 
        /// </summary>
        /// <returns>
        /// Array of GameImage
        /// </returns>
        public GameImage[] ToMatchGameImages(int numberOfImagesNeeded)
        {

            GameImage[] matchImages = new GameImage[numberOfImagesNeeded];

            Random rnd = new Random();

            int count = 0;
            while (count != matchImages.Length)
            {
                GameImage selectedImage = _images[rnd.Next(0, _images.Length)];
                if (matchImages.Contains(selectedImage)) continue;
                matchImages[count] = selectedImage;
                count++;

            }

            return matchImages;

        }
    }
}
