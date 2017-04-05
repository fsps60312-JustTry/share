using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Personal_Page : ContentPage
	{
        public Personal_Page()
        {

            // 下一頁 nav 的返回鍵 會變成 ""
            NavigationPage.SetBackButtonTitle(this, "取消");

            InitializeComponent();



            // Nav RIGHT
            ToolbarItems.Add(new ToolbarItem("編輯", "", () =>
            {
                var newPage = new Edit_Page();

                Navigation.PushAsync(newPage);
                //PushAsync = 到下一頁，有 Back 按鈕
                //PushModalAsync =  到下一頁，沒有 Back 按鈕

            }));



            ScrollView ScrollContainer = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
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
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(125, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(125, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Star) }
                },

                //row def.
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(150, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) }
                }

            };









            grid.Children.Add(new Image
            {
                Source = "addUser.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,

            }, 0, 4, 0, 1);

            {// Nick name
                var label = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                    FontAttributes = FontAttributes.None,
                    TextColor = Color.Gray,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Center
                };
                label.SetBinding(Label.TextProperty, "BindingText");
                label.BindingContext = new { BindingText = PersonalPage.PersonalData.main.data.NickName };
                grid.Children.Add(label, 0, 4, 1, 2);
            }

            grid.Children.Add(new Label
            {
                Text = "姓名",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            }, 1, 2);

            {// Name
                var label = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.None,
                    TextColor = Color.Gray,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End
                };
                label.SetBinding(Label.TextProperty, "BindingText");
                label.BindingContext = new { BindingText = PersonalPage.PersonalData.main.data.Name };
                grid.Children.Add(label, 2, 2);
            }

            grid.Children.Add(new Label
            {
                Text = "電話",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            }, 1, 3);

            {
                var label = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.None,
                    TextColor = Color.Gray,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                };
                label.SetBinding(Label.TextProperty, "BindingText");
                label.BindingContext = new { BindingText = PersonalPage.PersonalData.main.data.PhoneNumber };
                grid.Children.Add(label, 2, 3);
            }

            grid.Children.Add(new Label
            {
                Text = "會員種類",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            }, 1, 5);

            grid.Children.Add(new Button
            {
                Text = "一般會員", //firebase
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,

            }, 2, 5);

            grid.Children.Add(new Label
            {
                Text = "身份認證",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            }, 1, 6);



            grid.Children.Add(new Button
            {
                Text = "已完成認證",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,


            }, 2, 6);




            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);





            ScrollContainer.Content = grid;
            Content = ScrollContainer;
        }
	}
}
