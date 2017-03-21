using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class CustomerMenu : ContentPage
	{
		public CustomerMenu()
		{
			InitializeComponent();
		}

		void Photo_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new Edit_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}


		void Switch_To_Car_Owner_Mode_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new NavigationPage(new Menu());
			Navigation.PushModalAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		void Go_To_History_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new NavigationPage(new DriverVerification());
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{

		}
	}
}
