using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Add_Vehicle_Page : ContentPage
	{
		
		Dictionary<string, String> oilToName = new Dictionary<string, String>
		{
			{ "92", "92" },
			{ "95", "95" },
			{ "98", "98" },
			{ "柴油", "柴油" },

		};

		Dictionary<string, String> ageToName = new Dictionary<string, String>
		{
			{ "5年以下", "5年以下" },
			{ "5-10年間", "5-10年間" },
			{ "10年以上", "10年以上" },
		};

		Dictionary<string, String> typeToName = new Dictionary<string, String>
		{
			{ "擋車", "擋車" },
			{ "塑膠車", "塑膠車" },
		};


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
				Orientation = ScrollOrientation.Both,
			};


			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,


				RowSpacing = 4,
				ColumnSpacing = 1,
				BackgroundColor = Color.White,

				ColumnDefinitions =
				{
					new ColumnDefinition{ Width = GridLength.Star},
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) },
					new ColumnDefinition{ Width = GridLength.Star},

					//new ColumnDefinition{ Width = GridLength.Star},
					//new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) },

				},

				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition{ Height = new GridLength(150, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},

					//new RowDefinition{ Height = new GridLength(30, GridUnitType.Absolute)},
				},



			};



			Picker oilPicker = new Picker
			{
				Title="加什麼油",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest=150,
				TextColor=Color.Gray,



			};
			oilPicker.SelectedIndexChanged+=(sender, args) =>
				{
					if (oilPicker.SelectedIndex == -1)
					{
					oilPicker.Title= "加什麼油";
					}

					else
					{
					oilPicker.Title = oilPicker.Items[oilPicker.SelectedIndex];
					}
				};

			foreach (string colorName in oilToName.Keys)
			{
				oilPicker.Items.Add(colorName);
			}



			Picker agePicker = new Picker
			{
				Title = "何種車子",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 150,
				TextColor = Color.Gray,



			};
			agePicker.SelectedIndexChanged += (sender, args) =>
				  {
					  if (agePicker.SelectedIndex == -1)
					  {
						  agePicker.Title = "加油種類";
					  }

					  else
					  {
						  agePicker.Title = oilPicker.Items[agePicker.SelectedIndex];
					  }
				  };

			foreach (string colorName in ageToName.Keys)
			{
				agePicker.Items.Add(colorName);
			}


			Picker typePicker = new Picker
			{
				Title = "愛車種類",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 150,
				TextColor = Color.Gray,



			};
			typePicker.SelectedIndexChanged += (sender, args) =>
				  {
					  if (typePicker.SelectedIndex == -1)
					  {
						  typePicker.Title = "加油種類";
					  }

					  else
					  {
						  typePicker.Title = oilPicker.Items[typePicker.SelectedIndex];
					  }
				  };

			foreach (string colorName in typeToName.Keys)
			{
				typePicker.Items.Add(colorName);
			}



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
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				WidthRequest = 150,
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				TextColor=Color.Gray,


			}, 2, 2);



			grid.Children.Add(new Label
			{
				Text = "油種",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 3);
			grid.Children.Add(oilPicker, 2, 3);



			grid.Children.Add(new Label
			{
				Text = "車齡",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 4);
			grid.Children.Add(agePicker, 2, 4);


			grid.Children.Add(new Label
			{
				Text = "車種",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 5);
			grid.Children.Add(typePicker, 2, 5);


			grid.Children.Add(new Label
			{
				Text = "備註",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 6);


			// Entry 要變成兩格怎麼弄！
			// Entry 要變成兩格怎麼弄！
			// Entry 要變成兩格怎麼弄！

			grid.Children.Add(new Entry
			{
				Placeholder="車子注意事項",
				TextColor = Color.Gray,
			}, 2, 3, 6, 8);




			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


			ScrollContainer.Content = grid;
			Content = ScrollContainer;

		}

	}


}
