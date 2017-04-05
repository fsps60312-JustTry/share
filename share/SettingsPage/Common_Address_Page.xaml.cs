using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Common_Address_Page : ContentPage
	{
		public Common_Address_Page()
		{
			NavigationPage.SetBackButtonTitle(this, "");

			InitializeComponent();

			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Table Title")
				{

					new TableSection () {

						new TextCell{
							Text = "家",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "學校",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "公司",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "其他",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},



					},


				}

			};//content
		}
	}
}
