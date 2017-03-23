using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Vehicle_Page : ContentPage
	{
		public Vehicle_Page()
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
							Text = "添加車輛",
							//Detail = "This is some detail text",

							//https://forums.xamarin.com/discussion/46367/how-to-write-tap-event-for-textcell
							Command=new Command(()=> Navigation.PushAsync(new Add_Vehicle_Page())),

						},
					},

					new TableSection () {
						
						new TextCell{
							Text = "收藏車輛",
							//Detail = "This is some detail text",
							Command=new Command(()=> Navigation.PushAsync(new Edit_Page())),
						},


					},


				}

			};//content

		}
	}
}
