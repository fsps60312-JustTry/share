using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Edit_Page : ContentPage
	{
		public Edit_Page()
		{
			
			InitializeComponent();


			ScrollView ScrollContainer = new ScrollView
			{
				Orientation = ScrollOrientation.Both,
			};


			// add a grid
			Grid grid = new Grid
			{
				// set vertical option
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				//column def.
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) },
					new ColumnDefinition { Width = GridLength.Star },
				},

				//row def.
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(150, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(150, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },

				}

			};



			ScrollContainer.Content = grid;
			Content = ScrollContainer;
		}
	}
}
