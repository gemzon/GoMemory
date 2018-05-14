using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RulesPage : ContentPage
	{
		public RulesPage ()
		{
			InitializeComponent ();
		    Title = "Go Memory";
           
		}
	}
}