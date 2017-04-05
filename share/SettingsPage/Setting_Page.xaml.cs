using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Setting_Page : ContentPage
	{


		public Setting_Page()
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
							Text = "帳號",
							Command=new Command(()=> Navigation.PushAsync(new Account_Page())),

						},
						new TextCell{
							Text = "常用地址",
							Command=new Command(()=> Navigation.PushAsync(new Common_Address_Page())),

						},
						new TextCell{
							Text = "緊急聯絡人",
							Command=new Command(()=> Navigation.PushAsync(new Emergency_Page())),

						},


					},


					new TableSection () {

						new TextCell{
							Text = "用戶指南",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "給享卡好評",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "法律條款",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
						new TextCell{
							Text = "關於享卡",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},
					},



					 new TableSection () {

						new TextCell{
							Text = "登出",
							//Command=new Command(()=> Navigation.PushAsync(new Payment_Page())),

						},

					},




				}

			};//content
		}
	}
}
