using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class History_Page : ContentPage
	{
		public History_Page()
		{
			InitializeComponent();



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





		}
	}
}
