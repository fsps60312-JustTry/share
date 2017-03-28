using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class SignUp : ContentPage
	{
		Dictionary<string, String> GenderToName = new Dictionary<string, String>
		{
			{ "男", "男" },
			{ "女", "女" },
			{ "其他", "其他" },

		};


		public SignUp()
		{
			InitializeComponent();

			ScrollView ScrollContainer = new ScrollView
			{
				Orientation = ScrollOrientation.Vertical,
			};
			Grid grid = new Grid
			{
				// set vertical option
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				RowSpacing = 5,
				ColumnSpacing = 5,
				Margin = 10,

				//column def.
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = GridLength.Star},
					new ColumnDefinition { Width = new GridLength(40, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(160, GridUnitType.Absolute) },
					new ColumnDefinition { Width = GridLength.Star},

				},

				//row def.
				RowDefinitions =	
				{

					new RowDefinition { Height = new GridLength(15, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(200, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(25, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = GridLength.Star },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },

				}

			};

			//說明/
			grid.Children.Add(new Button
			{
				Text = "說明",
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.Gray,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),


			}, 3, 0);



			//圖片
			grid.Children.Add(new Button
			{
				Image = "addUser.png",	
				WidthRequest = 200,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Start,

			}, 0, 4, 1, 2);



			//姓名
			grid.Children.Add(new Label
			{
				Text = "姓名",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 3);

			grid.Children.Add(new Entry
			{
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				WidthRequest = 160,
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.Gray,
				Keyboard = Keyboard.Default
			}, 2, 3);



			//性別
			grid.Children.Add(new Label
			{
				Text = "性別",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 4);

			Picker genderPicker = new Picker
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 160,
				TextColor = Color.Gray,


			};
			genderPicker.SelectedIndexChanged += (sender, args) =>
				  {
					  if (genderPicker.SelectedIndex == -1)
					  {
						  genderPicker.Title = "選擇性別";
					  }

					  else
					  {
						  genderPicker.Title = genderPicker.Items[genderPicker.SelectedIndex];
					  }
				  };

			foreach (string genderName in GenderToName.Keys)
			{
				genderPicker.Items.Add(genderName);
			}
			grid.Children.Add(genderPicker, 2, 4);


			//電話
			grid.Children.Add(new Label
			{
				Text = "電話",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 5);
			grid.Children.Add(new Entry
			{
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				WidthRequest = 160,
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.Gray,
				Keyboard = Keyboard.Telephone
			}, 2, 5);

			//暱稱
			grid.Children.Add(new Label
			{
				Text = "暱稱",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 1, 6);

			grid.Children.Add(new Entry
			{
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
				WidthRequest = 160,
				FontAttributes = FontAttributes.None,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.Gray,
				Keyboard = Keyboard.Default,
			}, 2, 6);



			//checkbox 享卡條款
			StackLayout stacklayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				//WidthRequest = 250,
				//	Padding = 0,

				Children =
				{
					new Button
					{
						Image = "uncheck.png",
						WidthRequest = 20,
						HeightRequest = 20,
						HorizontalOptions = LayoutOptions.End,
						VerticalOptions = LayoutOptions.Center,

					},


					new Label
					{
						Text = "我已閱讀並同意",
						TextColor = Color.Gray,
						FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
						VerticalOptions = LayoutOptions.Center,
						HorizontalOptions = LayoutOptions.End,
						WidthRequest = 100,
					},
					new Button
					{
						Text = "《享卡出行服務條款》",
						TextColor = Color.Orange,
						FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
						VerticalOptions = LayoutOptions.Center,
						HorizontalOptions = LayoutOptions.Start,
						WidthRequest = 130,
					},


				},//children
			};
			grid.Children.Add(stacklayout, 0, 4, 8, 9);

			//下一步
			var nexStep = new Button
			{
				Text = "下一步",
				TextColor = Color.Blue,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				WidthRequest = 150,
				FontAttributes = FontAttributes.None,
				BorderWidth = 2,
				BorderColor = Color.Blue,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			nexStep.Clicked += Submit_Button_Clicked;
			grid.Children.Add(nexStep, 0, 4, 9, 10);

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);






			ScrollContainer.Content = grid;
			Content = ScrollContainer;


		}

		void Submit_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new IDVerification();

			Navigation.PushAsync(newPage);

			NavigationPage.SetHasBackButton(newPage, false);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}
	}
}
