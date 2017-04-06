using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Edit_Page : ContentPage
	{
        public static readonly BindableProperty BindingNameProperty = BindableProperty.Create("BindingName", typeof(string), typeof(Edit_Page));
        public static readonly BindableProperty BindingNickNameProperty = BindableProperty.Create("BindingNickName", typeof(string), typeof(Edit_Page));
        public static readonly BindableProperty BindingPhoneNumberProperty = BindableProperty.Create("BindingPhoneNumber", typeof(string), typeof(Edit_Page));

        // The following attributes must be public
        public string BindingName
        {
            get { return (string)GetValue(BindingNameProperty); }
            set { SetValue(BindingNameProperty, value); }
        }
        public string BindingNickName
        {
            get { return (string)GetValue(BindingNickNameProperty); }
            set { SetValue(BindingNickNameProperty, value); }
        }
        public string BindingPhoneNumber
        {
            get { return (string)GetValue(BindingPhoneNumberProperty); }
            set { SetValue(BindingPhoneNumberProperty, value); }
        }
        private void LoadData()
        {
            // BindingContext
            // https://developer.xamarin.com/api/property/Xamarin.Forms.BindableObject.BindingContext/
            
            ECname.SetBinding(EntryCell.TextProperty, "BindingName", BindingMode.TwoWay);
            ECname.BindingContext = this;

            ECnickName.SetBinding(EntryCell.TextProperty, "BindingNickName", BindingMode.TwoWay);
            ECnickName.BindingContext = this;

            ECphoneNumber.SetBinding(EntryCell.TextProperty, "BindingPhoneNumber", BindingMode.TwoWay);
            ECphoneNumber.BindingContext = this;

            var data = PersonalPage.PersonalData.main;

            BindingName = data.data.Name;
            BindingNickName = data.data.NickName;
            BindingPhoneNumber = data.data.PhoneNumber;
        }
        private void SaveData()
        {
            var data = PersonalPage.PersonalData.main;
            data.data.Name = BindingName;
            data.data.NickName = BindingNickName;
            data.data.PhoneNumber = BindingPhoneNumber;
            PersonalPage.PersonalData.main = data;
            PersonalPage.PersonalData.main.SaveAsync();
        }
        private EntryCell ECname, ECnickName, ECphoneNumber;
        private void InitializeViews()
        {
            // 下一頁 nav 的返回鍵 會變成 ""
            NavigationPage.SetBackButtonTitle(this, "");

            // Nav RIGHT
            ToolbarItems.Add(new ToolbarItem("完成", "", () =>
            {
                //DisplayAlert("", $"{ECname.Text}\r\n{ECnickName.Text}\r\n{ECphoneNumber.Text}\r\n{tname}\r\n{data.data.NickName}\r\n{data.data.PhoneNumber}", "OK");
                SaveData();
                Navigation.PopAsync();
            }));

            // Table View
            // https://developer.xamarin.com/guides/xamarin-forms/user-interface/tableview/

            ECname = new EntryCell
            {
                Label = "姓名",
                Placeholder = "請填寫本名",
                Keyboard = Keyboard.Default
            };
            ECnickName = new EntryCell
            {
                Label = "暱稱",
                Placeholder = "請填寫暱稱",
                Keyboard = Keyboard.Default
            };
            ECphoneNumber = new EntryCell
            {
                Label = "電話",
                Placeholder = "請填寫電話號碼",
                Keyboard = Keyboard.Telephone
            };

            Content = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Table Title") {
                    new TableSection ("圖片") {
                        new ImageCell{
                            ImageSource = "addUser.png",
                             Text = "變更圖片",
							//Detail = "This is some detail text",
						}
                    },
                    new TableSection ("基本資料") {
                        ECname,
                        ECnickName,
                        ECphoneNumber
						//new SwitchCell {
						//	Text = "SwitchCell:"
						//}
					}
                }
            };
        }
        public Edit_Page()
        {
            InitializeComponent();
            InitializeViews();
            LoadData();
		}
	}
}
