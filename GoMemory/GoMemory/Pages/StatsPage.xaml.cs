using GoMemory.Enums;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        public string PlayStyle { get; set; }

        public StatsPage(string playStyle)
        {
            InitializeComponent();

            PlayStyle = playStyle;
            Title = " Stats";
            GetStats();

        }


        public void GetStats()
        {

            var templist = App.StatRepository.GetGameStats(PlayStyle);

            foreach (var d in templist)
            {
                //    if (d == null) continue;
                switch (d.Difficulty)
                {
                    case Difficulty.Easy:
                        EasyLabel.Text = d.Level.ToString();

                        break;
                    case Difficulty.Normal:
                        NormalLabel.Text = d.Level.ToString();
                        break;
                    case Difficulty.Hard:
                        HardLabel.Text = d.Level.ToString();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

    }
}