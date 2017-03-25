using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Menu_Page : ContentPage
	{
		public Menu_Page()
		{

			NavigationPage.SetBackButtonTitle(this, "");

			InitializeComponent();

		}


		void Photo_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new Personal_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		void Go_To_History_Button_Clicked(object sender, System.EventArgs e) // // // // // //
		{
			//進到下一頁
			var newPage = new My_Purse_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}


		void Money_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new My_Purse_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		void Vehicle_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new My_Vehicle_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		void Collection_Button_Clicked(object sender, System.EventArgs e) // // // // // //
		{
			//進到下一頁
			var newPage = new My_Purse_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		void Service_Button_Clicked(object sender, System.EventArgs e)  // // // // // //
		{
			//進到下一頁
			var newPage = new My_Purse_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		} 



		void Setting_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new Setting_Page();
			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}

		//void Switch_To_Customer_Mode_Button_Clicked(object sender, System.EventArgs e)
		//{
		//	//進到下一頁
		//	var newPage = new NavigationPage(new DriverVerification());
		//	Navigation.PushAsync(newPage);
		//	//PushAsync = 到下一頁，有 Back 按鈕
		//	//PushModalAsync =  到下一頁，沒有 Back 按鈕
		//}
	

	}

}
