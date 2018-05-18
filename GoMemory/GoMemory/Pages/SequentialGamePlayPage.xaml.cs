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
	public partial class SequentialGamePlayPage : ContentPage
	{
	    private SequentialGamePlayViewModel _sequentialGamePlayViewModel;
		public SequentialGamePlayPage (Difficulty difficulty)
		{
			InitializeComponent ();
            _sequentialGamePlayViewModel = new SequentialGamePlayViewModel(difficulty);
		}
	}
}