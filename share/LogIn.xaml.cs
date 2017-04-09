using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class LogIn : ContentPage
	{

		public LogIn()
		{

			// 下一頁 nav 的返回鍵 會變成 ""
			NavigationPage.SetBackButtonTitle(this, "");
	
			InitializeComponent();

			//Label name = new Label
			//{
			//	Text = "享卡出行",
			//	FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
			//	HorizontalOptions = LayoutOptions.Center,
			//	TextColor= Color.Orange

			//};

			var title_Image = new Image 
			{ 
				Source = "sharecar_fb.png",
				WidthRequest = 150,
				HeightRequest = 150
			};

			Button Facebook_Log_In = new Button
			{
				Text = "Log In With Facebook",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				TextColor = Color.Blue,
				WidthRequest = 150,
				BorderWidth = 2,
				BorderColor = Color.Blue,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			Facebook_Log_In.Clicked += Submit_Button_Clicked;

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


			StackLayout stackLayout = new StackLayout
			{

				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.Center,

				BackgroundColor = Color.White,

				Orientation = StackOrientation.Vertical,

				Children =
				{
					new Label{ Text = ""},
					title_Image,
					new Label{ Text = ""},

					Facebook_Log_In
					//grid




				},

			};
			// Build the page.
			this.Content = stackLayout;
		}
		void Submit_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new SignUp();

			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}
	}
}
