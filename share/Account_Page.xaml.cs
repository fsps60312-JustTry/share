using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Account_Page : ContentPage
	{
		public Account_Page()
		{
			InitializeComponent();

			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Table Title")
				{

					new TableSection () {

						new TextCell{
							Text = "手機認證",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "身份認證",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "密碼設置",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},



					},

					new TableSection(){
						new TextCell{
							Text = "註銷帳號",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
					},



				}

			};//content


		}
	}
}
