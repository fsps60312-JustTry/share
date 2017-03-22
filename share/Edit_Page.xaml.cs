using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	



	public partial class Edit_Page : ContentPage
	{




		public Edit_Page()
		{

			// 下一頁 nav 的返回鍵 會變成 ""
			NavigationPage.SetBackButtonTitle(this, "");

			InitializeComponent();



			// Nav RIGHT
			ToolbarItems.Add(new ToolbarItem("完成", "", () =>
			{
				var newPage = new Personal_Page();


				Navigation.PushAsync(newPage);


			}));



			// Table View
			// https://developer.xamarin.com/guides/xamarin-forms/user-interface/tableview/



			Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot("Table Title") {




					new TableSection ("圖片") {
						new ImageCell{
							ImageSource = "addUser.png",
							 Text = "變更圖片",
							//Detail = "This is some detail text",
						}
					},

					new TableSection ("基本資料") {

						new EntryCell {
							Label = "姓名",
							Placeholder = "請填寫本名",
							Keyboard = Keyboard.Default
						},

						new EntryCell {
							Label = "暱稱",
							Placeholder = "請填寫暱稱",
							Keyboard = Keyboard.Default
						},

						new EntryCell {
							Label = "電話",
							Placeholder = "請填寫電話號碼",
							Keyboard = Keyboard.Telephone
						},

						//new SwitchCell {
						//	Text = "SwitchCell:"
						//}
					},




				}
			};


		}

	




	}
}
