using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class LogIn : ContentPage
	{

		public LogIn()
		{
			InitializeComponent();

			Label name = new Label
			{
				Text = "享卡",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				HorizontalOptions = LayoutOptions.Center

			};

			var title_Image = new Image { Aspect = Aspect.AspectFit };
			title_Image.Source = "top.jpg";

			Button Facebook_Log_In = new Button
			{
				Text = "Log In With Facebook",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			Facebook_Log_In.Clicked += Submit_Button_Clicked;

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
				{
					name,
					title_Image,
					Facebook_Log_In
				}
			};

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
