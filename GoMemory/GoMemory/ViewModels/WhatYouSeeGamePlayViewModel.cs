using GoMemory.DataAccess;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    public class WhatYouSeeGamePlayViewModel : BaseViewModel, IGame
    {
        public DifficultySetting DifficultySetting { get; set; }
        public ImageHelper ImageHelper { get; set; }
        public UnorderedGame UnorderedGame { get; set; }
        public ResumeModel ResumeModel { get; set; }

        private int CorrectSelections;


        public WhatYouSeeGamePlayViewModel(Difficulty difficulty, ResumeModel resume)
        {
            DifficultySetting = SettingsData.SetCurrentDifficulty(GameType.Guess, difficulty);
            ImageHelper = new ImageHelper();
            SetGameImages();        
            CheckIfResume(difficulty, resume);
            NextRound();
        }

        //TODO move out to own class
        private void CheckIfResume(Difficulty difficulty, ResumeModel resume)
        {
            if (resume != null)
            {
                UnorderedGame.Level = resume.Level;
                UnorderedGame.MatchesNeeded = resume.MatchesNeeded;
                ResumeModel = resume;
            }
            else
            {
                ResumeModel = new ResumeModel
                {
                    GameType = GameType.Guess,
                    Difficulty = difficulty,
                };
            }
        }



        /// <summary>
        /// Retrieve collection of image
        /// amount depends on difficulty setting
        /// </summary>
        public void SetGameImages()
        {
            UnorderedGame = new UnorderedGame { AllImages = ImageHelper.GetImages(DifficultySetting.MaxSelectable) };

        }


        /// <summary>
        /// Determines if max level for difficulty is reached if not
        /// next round is initialized
        /// </summary>
        public bool NextRound()
        {

            UnorderedGame.Level += 1;
            if (UnorderedGame.Level <= DifficultySetting.MaxLevel)
            {
                ResumeModel.Level = UnorderedGame.Level - 1;
                //todo pull directly from App.DifficultSettings
                ResumeModel.MatchesNeeded = UnorderedGame.MatchesNeeded;
                ResumeHelper.SetResume(ResumeModel);
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
            CorrectSelections = 0;
            UnorderedGame.MatchesNeeded += 1;
            UnorderedGame.ToMatchImages = ImageHelper.ToMatchImagesList(UnorderedGame.MatchesNeeded, UnorderedGame.AllImages);
            UnorderedGame.SelectedImages = new List<Image>();
        }


        /// <summary>
        /// Create a new GameGrid
        /// </summary>
        /// <returns></returns>
        public Grid CreateNewGrid(Grid grid)
        {
            grid = GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
            grid = GridHelper.InsertGridImages(grid, UnorderedGame.AllImages, DifficultySetting);
            return grid;
        }


        /// <summary>
        /// Check if the selected image is contain within 
        /// the list of image that are needed to be matched
        /// </summary>
        /// <param name="selectedImage"></param>
        public bool CheckSelections(Image selectedImage)
        {
            foreach (var image in UnorderedGame.ToMatchImages)
            {
                if (image.Source == selectedImage.Source)
                {
                    CorrectSelections++;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check to see if the number of correct selection is
        /// equal to the total number of correct guesses needed
        /// </summary>
        /// <returns></returns>
        public bool CheckIsRoundComplete()
        {
            return CorrectSelections == UnorderedGame.ToMatchImages.Length;

        }

        /// <summary>
        /// Set a Labels text to the current level
        /// </summary>
        /// <returns></returns>
        public string SetLevelText()
        {
            return $"Level : {UnorderedGame.Level}";
        }

        /// <summary>
        /// Set retry values
        /// </summary>
        public void Retry()
        {

            UnorderedGame.Level -= 1;
            UnorderedGame.MatchesNeeded -= 1;

        }

        public FlexLayout CreateSequenceFlexLayout(FlexLayout flexLayout)
        {
            flexLayout.Children.Clear();
            for (int i = 0; i < UnorderedGame.ToMatchImages.Length; i++)
            {
                Image img = new Image
                {
                    Source = UnorderedGame.ToMatchImages[i].Source,
                    Margin = new Thickness(2)
                };

                flexLayout.Children.Add(img);
            }

            return flexLayout;
        }
    }
}
