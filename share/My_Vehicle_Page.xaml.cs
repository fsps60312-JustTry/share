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


			Grid grid = new Grid
			{

				BackgroundColor = Color.White,
				RowSpacing = 1,
				ColumnSpacing = 2,

				ColumnDefinitions =
								{

								new ColumnDefinition{ Width = GridLength.Star},
								new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) },
								new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) },
								new ColumnDefinition { Width = new GridLength(40, GridUnitType.Absolute) },
								new ColumnDefinition{ Width = GridLength.Star},

								},

				RowDefinitions =
								{
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},

								},


			};//grid

			grid.Children.Add(new Image
			{ 
				Source="scooter.png"
			}, 1, 2, 0, 4);

			grid.Children.Add(new Label
			{
				Text = "車牌",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 2, 0);
			grid.Children.Add(new Label
			{
				Text = "133-KAW",
				TextColor = Color.Accent,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,

			}, 3, 0);


			StackLayout stackLayout = new StackLayout
			{
				Spacing = 10,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.Start,

				Orientation = StackOrientation.Vertical,

				Children =
				{


					
					new StackLayout
					{
						Spacing=0,

						Children =
						{
							
							new Grid
							{

								BackgroundColor = Color.White,

								ColumnDefinitions =
								{
											
								new ColumnDefinition{ Width = GridLength.Star},
								new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) },
								new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) },
								new ColumnDefinition { Width = new GridLength(40, GridUnitType.Absolute) },
								new ColumnDefinition{ Width = GridLength.Star},

								},

								RowDefinitions =
								{
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
									new RowDefinition{ Height = new GridLength(40, GridUnitType.Absolute)},
											
								},
										

							},//grid


								

						}

					},//new stacklayout


					new StackLayout
					{
						Spacing=0,
						VerticalOptions = LayoutOptions.Center,
						HorizontalOptions = LayoutOptions.Center,

						GestureRecognizers = {
							new TapGestureRecognizer {
							Command = new Command(()=> Navigation.PushAsync(new Payment_Page())),
							},
						},


						Children =
						{
							new Label
							{
								Text = "Stacking",
							},
							new Label
							{
								Text = "can also be",
								VerticalOptions = LayoutOptions.CenterAndExpand
							},
							new Label
							{
								Text = "fasdfadsfasd.",
							},
						}

					},//new stacklayout



				},

			};



			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


			ScrollContainer.Content = grid;
			Content = ScrollContainer;
		}


	}
}
