using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class SignUp : ContentPage
	{
		public SignUp()
		{
			InitializeComponent();

			Grid grid = new Grid();
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });

			grid.Children.Add(new BoxView { BackgroundColor = Color.FromHex("26A65B") }, 0, 0);
			grid.Children.Add(new Entry(), 1, 0);

			this.Content = grid;
		}
	}
}
