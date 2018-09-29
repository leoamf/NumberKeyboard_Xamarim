using System;
using Xamarin.Forms;
namespace NumberKeyboard_Xamarim
{
    public class MainPage : ContentPage
    {
        Label label = new Label { HorizontalTextAlignment = TextAlignment.End };
        StackLayout stackChild = new StackLayout
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Padding = 0
        };
        Button backSpace = new Button
        {
           Text = "\u21E6",
            StyleId="back"
        };


        public MainPage()
        {
            stackChild.Children.Add(label); 
            stackChild.Children.Add(backSpace);
            StackLayout threeNumber = new StackLayout{
                Orientation =  StackOrientation.Horizontal,
                Padding = 0
            };
            for (int x = 0; x <= 9; x++)
            {
                Button btNumber = new Button
                {
                    Text = x.ToString(),
                    StyleId = x.ToString(),
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                btNumber.Clicked += BtNumber_Clicked;
                threeNumber.Children.Add(btNumber);
                stackChild.Children.Add(threeNumber);
                if (x % 3 == 0)
                {
                    threeNumber = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = 0
                    };
                }
            }

            backSpace.Clicked += BtNumber_Clicked;

            Content = new ScrollView
            {
                Content = new StackLayout()
                {
                    Children ={
                        stackChild
                    },
                    Padding = 0
                }
            };


        }
         
        void BtNumber_Clicked(object sender, EventArgs e)
        {
            if(((Button)sender).StyleId != "back")
            {
                label.Text +=  ((Button)sender).StyleId;

            }else{
                label.Text = label.Text.Substring(  0, label.Text.Length -1); 
            }

        }

    }
}