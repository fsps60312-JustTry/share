using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Payment_Page : ContentPage
	{
		public Payment_Page()
		{

			NavigationPage.SetBackButtonTitle(this, "");

			InitializeComponent();
			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Table Title")
				{
					
					new TableSection () {

						new ImageCell{
							ImageSource = "cash.png",
							Text = "現金支付",
							//https://forums.xamarin.com/discussion/46367/how-to-write-tap-event-for-textcell
							Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},


						new ImageCell{
							ImageSource = "wechat.jpg",
							Text = "微信支付",
							//https://forums.xamarin.com/discussion/46367/how-to-write-tap-event-for-textcell
							Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},


					},

				}
			}; //content


		}
	}
}
