using Xamarin.Forms;

namespace GoMemory.Helpers
{
    public static class ControlStyles
    {

        public static Button LargeTextGreenButton()
        {
            return  new Button
            {
              
                BackgroundColor = Color.Green,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                CornerRadius = 20,
            };
        }

        public static Label LargeTextBlueLabel()
        {
            return new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 50, 0),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.MidnightBlue,
                FontAttributes = FontAttributes.Bold


            };
        }
        public static Label LargeTextPurpleLabel()
        {
            return new Label
            {
               
                Margin = new Thickness(0),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.DarkSlateBlue,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center

            };
        }

        public static StackLayout SetStackLayout()
        {
           StackLayout stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(10)
            };


            return stackLayout;
        }

      
    }
}
