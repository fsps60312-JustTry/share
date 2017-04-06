using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class ConfirmVerification : ContentPage
	{

		public ConfirmVerification()
		{
			InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            //star : fill the remaining place
            //auto : minimum
            //absolute : specific


            // add a grid
            Grid grid = new Grid
			{
				// set vertical option
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				//column def.
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) },
					new ColumnDefinition { Width = GridLength.Star },
				},

				//row def.
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },

				}

			};


			// Button nextStep var
			var nexStep = new Button
			{
				Text = "馬上開啟您的租車之旅吧！",
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				WidthRequest = 250,
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.FromHex("#FF8A4A"),
				BorderColor = Color.FromHex("#FF8040"),
				BorderWidth = 3,
				BorderRadius = 5,

				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			nexStep.Clicked += Submit_Button_Clicked;







			// ProgressBar
			grid.Children.Add(new ProgressBar
			{
				Progress = 1,

				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200,
				HeightRequest = 5,

			}, 0, 3, 0, 1);




			// Label Of ProgressBar
			grid.Children.Add(new Label
			{
				Text = "身份證",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Blue,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.End,

			}, 0, 1);

			grid.Children.Add(new Label
			{
				Text = "駕照",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Blue,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center,

			}, 1, 1);

			grid.Children.Add(new Label
			{
				Text = "完成",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Blue,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,

			}, 2, 1);




			// Congrats!
			grid.Children.Add(new Label
			{
				Text = "恭喜您完成身份驗證",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.FromHex("#FF8A4A"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,

			}, 0, 3, 2, 3);






			// Left Over
			//grid.Children.Add(new Label
			//{
			//	Text = "Leftover space",
			//	TextColor = Color.White,
			//	BackgroundColor = Color.White,
			//	HorizontalTextAlignment = TextAlignment.Center,
			//	VerticalTextAlignment = TextAlignment.Center,
			//}, 0, 3, 4, 5);





			// Next Step
			// Add: left, right, top, bottom
			grid.Children.Add(nexStep, 0, 3, 3, 4);







			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);




			this.Content = grid;

		}

		void Submit_Button_Clicked(object sender, System.EventArgs e)
        {
            //進到下一頁
            var newPage = new NavigationPage(new Menu_Page());

            App.Current.MainPage = newPage;
            //await Navigation.PushModalAsync(newPage);
			//NavigationPage.SetHasBackButton(newPage, false);

			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}
	}
}
