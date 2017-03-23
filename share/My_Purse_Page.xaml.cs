using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class My_Purse_Page : ContentPage
	{




		public My_Purse_Page()
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
							ImageSource = "payWay.png",
							Text = "支付方式",
							//https://forums.xamarin.com/discussion/46367/how-to-write-tap-event-for-textcell
							Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
					},

					new TableSection () {
						new ImageCell{
							ImageSource = "payWay.png",
							Text = "享幣",
							Detail = "This is some detail text",
							Command=new Command(()=> Navigation.PushAsync(new Edit_Page())),
						},

						new ImageCell{
							ImageSource = "payWay.png",
							Text = "優惠券",
							Detail = "兩張",
							Command=new Command(()=> Navigation.PushAsync(new Edit_Page())),
						},
					
					},

					new TableSection () {

						new ImageCell{
							ImageSource = "payWay.png",
							Text = "保險",
							//https://forums.xamarin.com/discussion/46367/how-to-write-tap-event-for-textcell
							Command=new Command(()=> Navigation.PushAsync(new Edit_Page())),

						},
					},


				}

			};//content




		}
	}
}
