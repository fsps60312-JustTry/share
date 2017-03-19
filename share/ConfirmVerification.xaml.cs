using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class ConfirmVerification : ContentPage
	{
		private Grid bigGrid;

		public ConfirmVerification()
		{
			InitializeComponent();

			bigGrid = new Grid();
			bigGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) });

			bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Auto) });
			bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150, GridUnitType.Star) });
			bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Star) });


			//照理說為ProgressBar
			var idButton = new Button
			{
				Text = "c9 c9 c9 "
			};

			var confirmMessage = new Label { Text = "恭喜您完成身份驗證！" };

			Button nexStep = new Button
			{
				Text = "馬上開啟您的租車之旅吧！",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			nexStep.Clicked += Submit_Button_Clicked;



			bigGrid.Children.Add(idButton, 0, 0);
			bigGrid.Children.Add(confirmMessage, 0, 1);
			bigGrid.Children.Add(nexStep, 0, 2);

			this.Content = bigGrid;

		}

		void Submit_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new Map();

			Navigation.PushModalAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}
	}
}
