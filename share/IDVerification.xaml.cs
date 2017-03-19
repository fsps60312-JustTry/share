using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class IDVerification : ContentPage
	{
		private Grid bigGrid, idFront, idBack;
		private Button idPicF, idPicB;

		public IDVerification()
		{
			InitializeComponent();

			{
				bigGrid = new Grid();
				bigGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) });

				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Auto) });
				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150, GridUnitType.Auto) });
				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Auto) });
				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Auto) });


				//上傳身份證正面 圖片
				{
					idFront = new Grid();
					idFront.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Auto) });
					idFront.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Auto) });
					idFront.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Star) });


					var idButtonF = new Button
					{
						Text = "請橫向清晰拍攝身份證正面"
					};

					idPicF = new Button
					{
						Image = "camera.png"
					};

					idFront.Children.Add(idPicF, 0, 0);
					idFront.Children.Add(idButtonF, 0, 1);

				}

				//上傳身份證反面 圖片
				{
					idBack = new Grid();
					idBack.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Auto) });
					idBack.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Auto) });
					idBack.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Star) });


					var idButtonB = new Button
					{
						Text = "請橫向清晰拍攝身份證反面"
					};

					idPicB = new Button
					{
						Image = "camera.png"
					};

					idBack.Children.Add(idPicB, 0, 0);
					idBack.Children.Add(idButtonB, 0, 1);

				}


				var idButton = new Button
				{
					Text = "c9 c9 c9 "
				};

				Button nexStep = new Button
				{
					Text = "下一步",
					Font = Font.SystemFontOfSize(NamedSize.Medium),
					BorderWidth = 2,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				nexStep.Clicked += Submit_Button_Clicked;


				bigGrid.Children.Add(idButton, 0, 0);
				bigGrid.Children.Add(idFront, 0, 1);
				bigGrid.Children.Add(idBack, 0, 2);
				bigGrid.Children.Add(nexStep, 0, 3);

				this.Content = bigGrid;





			}



		}

		void Submit_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new DriverVerification();

			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}


	}
}
