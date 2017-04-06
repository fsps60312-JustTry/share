using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Emergency_Page : ContentPage
	{
		public Emergency_Page()
		{
			InitializeComponent();

			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Table Title")
				{

					new TableSection () {

						new TextCell{
							Text = "添加緊急聯絡人",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
					



					},






				}

			};//content
		}
	}
}
