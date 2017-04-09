using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace share
{
	public partial class Edit_Page : ContentPage
	{
        private PersonalPage.PersonalData.BindingData bindingData;
        private void LoadData()
        {
            // BindingContext
            // https://developer.xamarin.com/api/property/Xamarin.Forms.BindableObject.BindingContext/

            bindingData = new PersonalPage.PersonalData.BindingData(PersonalPage.PersonalData.main);
            bindingData.SetBinding(ECname, ECnickName, ECphoneNumber);
        }
        private void SaveData()
        {
            bindingData.SaveAsync(ref PersonalPage.PersonalData.main);
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
