using GoMemory.DataAccess;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using System;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    public class SequentialGamePlayViewModel : BaseViewModel, IGame
    {
        public DifficultySetting DifficultySetting { get; set; }
        public OrderedGame OrderedGame { get; set; }
        public int GuessesMade { get; set; }
        public ImageHelper ImageHelper { get; set; }

        public ResumeModel ResumeModel { get; set; }
        public SequentialGamePlayViewModel(Difficulty difficulty, ResumeModel resume)
        {
            DifficultySetting = SettingsData.SetCurrentDifficulty(GameType.Guess, difficulty);

            ImageHelper = new ImageHelper();
            GetDifficultyImages();

            //TODO refactor to own class
            if (resume != null)
            {
                OrderedGame.Level = resume.Level;
                OrderedGame.MatchesNeeded = resume.MatchesNeeded;
                ResumeModel = resume;
            }
            else
            {
                ResumeModel = new ResumeModel
                {
                    GameType = GameType.Sequential,
                    Difficulty = difficulty,
                };
            }
            GuessesMade = 0;
        }

        /// <summary>
        /// Retrieve the image need for the selection Grid and for
        /// generate sequences
        /// </summary>
        public void GetDifficultyImages()
        {
            OrderedGame = new OrderedGame
            {
                AllImages = ImageHelper.GetImages(DifficultySetting.MaxSelectable)
            };
        }

        /// <summary>
        /// Adds images for the round to the sequence layout
        /// </summary>
        /// <param name="layout"></param>
        /// <returns></returns>
        public StackLayout PopulateSequenceStackLayout(StackLayout layout)
        {
            for (int i = 0; i < OrderedGame.ToMatchImages.Length; i++)
            {
                StackLayout st = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,


                };
                Label itemnumber = new Label
                {
                    Text = $"{(i + 1)} . "
                };
                Image img = new Image
                {
                    Source = OrderedGame.ToMatchImages[i].Source,

                    Margin = new Thickness(2)
                };
                st.Children.Add(itemnumber);
                st.Children.Add(img);
                layout.Children.Add(st);

            }

            return layout;
        }


        /// <summary>
        /// Create a grid containing the image used at this level of difficulty
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Grid CreateNewGrid(Grid grid)
        {
            grid = GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
            grid = AddGridImages(grid);


            return grid;
        }

        public Grid AddGridImages(Grid grid)
        {
            return GridHelper.InsertGridImages(grid, OrderedGame.AllImages, DifficultySetting);

        }


        /// <summary>
        /// Determines if max level for difficulty is reached if not
        /// next round is initialized
        /// </summary>
        public bool NextRound()
        {
            OrderedGame.Level += 1;

            if (OrderedGame.Level <= DifficultySetting.MaxLevel)
            {
                ResumeModel.Level = OrderedGame.Level - 1;
                ResumeModel.MatchesNeeded = OrderedGame.MatchesNeeded;
                ResumeHelper.SetResume(ResumeModel);
                OrderedGame.MatchesNeeded += 1;
                InitializeRound();
                return true;
            }
            ResumeHelper.RemoveResume(ResumeModel.GameType);
            return false;
        }

        /// <summary>
        /// InitializeRound settings
        /// </summary>
        public void InitializeRound()
        {
            OrderedGame.ToMatchImages = new Image[OrderedGame.MatchesNeeded];
            OrderedGame.SelectedImages = new Image[OrderedGame.MatchesNeeded];

            GenerateToMatchSequence();
            GuessesMade = 0;
        }




        /// <summary>
        /// Generate the sequence that needs to be matched can have multiple images of the same type
        /// </summary>
        private void GenerateToMatchSequence()
        {

            Random rnd = new Random();
            for (int i = 0; i < OrderedGame.ToMatchImages.Length; i++)
            {

                int randomValue = rnd.Next(0, OrderedGame.AllImages.Length);
                Image img = new Image
                {
                    Source = OrderedGame.AllImages[randomValue].Source,
                    Aspect = Aspect.Fill,
                    Margin = new Thickness(2)

                };
                OrderedGame.ToMatchImages[i] = img;
            }
        }


        /// <summary>
        /// Check if the selected image is contain within 
        /// the array of image that are needed to be matched 
        /// must be in correct order
        /// </summary>
        /// <param name="selectedImage"></param>
        public bool CheckSequence(Image selectedImage)
        {
            OrderedGame.SelectedImages[GuessesMade] = selectedImage;

            for (int i = 0; i < GuessesMade + 1; i++)
            {
                if (OrderedGame.SelectedImages[i].Source != OrderedGame.ToMatchImages[i].Source)
                    return false;
                else
                    continue;
            }

            GuessesMade += 1;
            return true;
        }


        /// <summary>
        /// Set a Labels text to the current level
        /// </summary>
        /// <returns></returns>
        public string SetLevelText()
        {
            return $"Level : {OrderedGame.Level}";
        }

        /// <summary>
        /// Set retry values
        /// </summary>
        public void Retry()
        {
            OrderedGame.Level -= 1;
            OrderedGame.MatchesNeeded -= 1;


        }

        public bool CheckIsRoundComplete()
        {
            return GuessesMade == OrderedGame.ToMatchImages.Length;
        }

    }
}
