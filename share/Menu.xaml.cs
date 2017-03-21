using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Menu : ContentPage
	{
		public Menu()
		{
			InitializeComponent();
		}


		void Switch_To_Customer_Mode_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new NavigationPage(new CustomerMenu());
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

		void Go_To_Add_A_Car_Page_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new NavigationPage(new DriverVerification());
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}


	}

}
