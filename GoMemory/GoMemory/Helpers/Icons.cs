﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.Helpers
{
    public class Icons
    {
        public ObservableCollection<GameImage> images;
        public Icons()
        {
            var imagesPath =  "GoMemory.Images.GameImages.";
            images = new ObservableCollection<GameImage>
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
        public IEnumerable<string> GenerateIconList()
        {
            return null;
        }
    }
}
