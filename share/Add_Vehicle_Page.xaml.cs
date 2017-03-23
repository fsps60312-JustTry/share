using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Add_Vehicle_Page : ContentPage
	{

		public Add_Vehicle_Page()
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



			ScrollView ScrollContainer = new ScrollView
			{
				Orientation = ScrollOrientation.Vertical,
			};


			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				RowSpacing = 1,
				ColumnSpacing = 1,
				BackgroundColor = Color.White,

				ColumnDefinitions =
				{
					new ColumnDefinition{ Width = GridLength.Star},
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) },
					new ColumnDefinition{ Width = GridLength.Star},

					//new ColumnDefinition{ Width = GridLength.Star},
					//new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) },

				},

				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition{ Height = new GridLength(150, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(30, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(30, GridUnitType.Absolute)},

					//new RowDefinition{ Height = new GridLength(30, GridUnitType.Absolute)},
				},



			};

			Label gasLabel = new Label
			{
				Text = "請選擇加油種類",
				TextColor=Color.Gray,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

			};

			Picker oilPicker = new Picker
			{
				Title="加油種類",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest=100,

			};
			oilPicker.SelectedIndexChanged+=(sender, args) =>
				{
					if (oilPicker.SelectedIndex == -1)
					{
					gasLabel.Text= "請選擇加油種類";
					}

					else
					{
					string colorName = oilPicker.Items[oilPicker.SelectedIndex];
					}
				};

			grid.Children.Add(new Button
			{
				Text="添加規則",
				TextColor = Color.Gray,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Start,

			}, 0, 4, 0, 1);


			grid.Children.Add(new Button
			{
				Text = "新增機車帥照",
				Image = "scooter.png",
				WidthRequest = 100,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Start,

			}, 0, 4, 1, 2);


			grid.Children.Add(new Label
			{
				Text = "車牌",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 2);
			grid.Children.Add(new Entry
			{
				Placeholder = "如：137-JAK",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				WidthRequest = 100,
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,


			}, 2, 2);



			grid.Children.Add(new Label
			{
				Text = "車牌",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 3);
			grid.Children.Add(oilPicker, 2, 3);



			//grid.Children.Add(new Label
			//{
			//	Text = "車牌",
			//	TextColor = Color.Accent,
			//	FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
			//	FontAttributes = FontAttributes.Bold,
			//	HorizontalOptions = LayoutOptions.Start,
			//	VerticalOptions = LayoutOptions.Center,

			//}, 1, 1);
			//grid.Children.Add(new Entry
			//{
			//	Text = "新增",
			//	TextColor = Color.Black,
			//	FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
			//	FontAttributes = FontAttributes.None,
			//	HorizontalOptions = LayoutOptions.Center,
			//	VerticalOptions = LayoutOptions.Center,


			//}, 2, 1);


			//grid.Children.Add(new Entry
			//{
			//	Placeholder = ""
			//	FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
			//	HorizontalOptions = LayoutOptions.End,

			//}, 1, 1);



			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


			ScrollContainer.Content = grid;
			Content = ScrollContainer;

		}

	}


}
