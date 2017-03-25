using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class My_Vehicle_Page : ContentPage
	{



		public My_Vehicle_Page()
		{
			InitializeComponent();

			ScrollView ScrollContainer = new ScrollView
			{
				Orientation = ScrollOrientation.Vertical,
			};



			Grid grid1 = new Grid
			{

				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				GestureRecognizers =
				{
						new TapGestureRecognizer {
								Command = new Command(()=> Navigation.PushAsync(new Payment_Page())),
						},
				},

				RowSpacing = 3,
				ColumnSpacing = 4,
				BackgroundColor = Color.White,

				ColumnDefinitions =
				{

				new ColumnDefinition{ Width = new GridLength(30, GridUnitType.Absolute)},
				new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute) },
				new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) },
				new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute) },
				new ColumnDefinition{ Width = new GridLength(30, GridUnitType.Absolute)},

				},

				RowDefinitions =
				{
					new RowDefinition{ Height = new GridLength(5, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(5, GridUnitType.Absolute)},

				},


			};//grid

			grid1.Children.Add(new Image
			{ 
				Source="scooter.png",
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				WidthRequest = 50,
				HeightRequest = 50,

			}, 1, 2, 0, 6);

			grid1.Children.Add(new Label
			{
				Text = "車牌",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 1);
			grid1.Children.Add(new Label
			{
				Text = "133-KAW",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 1);



			grid1.Children.Add(new Label
			{
				Text = "油種",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 2);
			grid1.Children.Add(new Label
			{
				Text = "92",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 2);


			grid1.Children.Add(new Label
			{
				Text = "車齡",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 3);
			grid1.Children.Add(new Label
			{
				Text = "5-10年",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 3);

			grid1.Children.Add(new Label
			{
				Text = "車種",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 4);
			grid1.Children.Add(new Label
			{
				Text = "塑膠車",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 4);



			Grid grid = new Grid
			{

				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				GestureRecognizers =
				{
						new TapGestureRecognizer {
								Command = new Command(()=> Navigation.PushAsync(new Payment_Page())),
						},
				},

				RowSpacing = 3,
				ColumnSpacing = 4,
				BackgroundColor = Color.White,

				ColumnDefinitions =
				{

				new ColumnDefinition{ Width = new GridLength(30, GridUnitType.Absolute)},
				new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute) },
				new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) },
				new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute) },
				new ColumnDefinition{ Width = new GridLength(30, GridUnitType.Absolute)},

				},

				RowDefinitions =
				{
					new RowDefinition{ Height = new GridLength(5, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(20, GridUnitType.Absolute)},
					new RowDefinition{ Height = new GridLength(5, GridUnitType.Absolute)},

				},


			};//grid

			grid.Children.Add(new Image
			{
				Source = "scooter.png",
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				WidthRequest = 50,
				HeightRequest = 50

			}, 1, 2, 0, 6);

			grid.Children.Add(new Label
			{
				Text = "車牌",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 1);
			grid.Children.Add(new Label
			{
				Text = "133-KAW",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 1);



			grid.Children.Add(new Label
			{
				Text = "油種",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 2);
			grid.Children.Add(new Label
			{
				Text = "92",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 2);


			grid.Children.Add(new Label
			{
				Text = "車齡",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 3);
			grid.Children.Add(new Label
			{
				Text = "5-10年",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 3);

			grid.Children.Add(new Label
			{
				Text = "車種",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 4);
			grid.Children.Add(new Label
			{
				Text = "塑膠車",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,
			}, 3, 4);


			var sampleView = new ContentView
			{
				BackgroundColor = Color.Gray,
				Content = grid,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Padding = 2

			};
			var sampleView1 = new ContentView
			{
				BackgroundColor = Color.Gray,
				Content = grid1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Padding = 2
			};


			StackLayout stackLayout = new StackLayout
			{
				Spacing = 20,
				Margin = 5,

				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.Center,

				BackgroundColor = Color.White,

				Orientation = StackOrientation.Vertical,

				Children =
				{
					new Label{ Text = ""},
					sampleView,
					sampleView1
					//grid




				},

			};


			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


			ScrollContainer.Content = stackLayout;
			Content = ScrollContainer;
		}


	}
}
