using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class SignUp : ContentPage
	{

		private Grid gridDetail,bigGrid;
		private Button imageBt;

		public SignUp()
		{
			InitializeComponent();

			{
				bigGrid = new Grid();
				bigGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) });

				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(250, GridUnitType.Absolute) });
				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150, GridUnitType.Auto) });
				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Star) });
				bigGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Star) });

				imageBt = new Button
				{
					Image = "addUser.png"
				};




			}



			{
				gridDetail = new Grid();
				gridDetail.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Auto) });
				gridDetail.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });


				gridDetail.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });
				gridDetail.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });
				gridDetail.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });


				var name = new Label { Text = "  姓名  " };
				var gender = new Label { Text = "  性別  " };
				var phone = new Label { Text = "  電話  " };


				gridDetail.Children.Add(name, 0, 0);
				gridDetail.Children.Add(gender, 0, 1);
				gridDetail.Children.Add(phone, 0, 2);


				gridDetail.Children.Add(new Entry(), 1, 0);
				gridDetail.Children.Add(new Entry(), 1, 1);
				gridDetail.Children.Add(new Entry(), 1, 2);


			}

			var lawConfirm = new Label { Text = "我已閱讀並同意「享卡出行服務條款」" };

			Button nexStep = new Button
			{
				Text = "下一步",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			nexStep.Clicked += Submit_Button_Clicked;

			bigGrid.Children.Add(imageBt, 0, 0);
			bigGrid.Children.Add(gridDetail, 0, 1);
			bigGrid.Children.Add(lawConfirm, 0, 2);
			bigGrid.Children.Add(nexStep, 0, 3);

			this.Content = bigGrid;

		}

		void Submit_Button_Clicked(object sender, System.EventArgs e)
		{
			//進到下一頁
			var newPage = new IDVerification();

			Navigation.PushAsync(newPage);
			//PushAsync = 到下一頁，有 Back 按鈕
			//PushModalAsync =  到下一頁，沒有 Back 按鈕
		}
	}
}
