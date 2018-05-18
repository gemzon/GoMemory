using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColourComplexGamePlayPage : ContentPage
	{
	    readonly ColourComplexGamePlayViewModel _whatYouSeeGamePlayViewModel;
	    public ColourComplexGamePlayPage(Difficulty difficulty)
	    {
	        InitializeComponent();
	        _whatYouSeeGamePlayViewModel = new ColourComplexGamePlayViewModel(difficulty);
	    }
    }
}