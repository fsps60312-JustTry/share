using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace share
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountiesPage : ContentPage
    {
        ScrollView SVmain;
        StackLayout SLmain;
        string[] counties = new string[] { "台北", "新北", "基隆", "桃園", "新竹", "宜蘭","花蓮","台東","苗栗","台中","彰化","南投","雲林","嘉義","台南","高雄","屏東" };
        public CountiesPage()
        {
            //InitializeComponent();
            {
                SVmain = new ScrollView();
                SVmain.VerticalOptions = SVmain.HorizontalOptions = LayoutOptions.FillAndExpand;
                {
                    SLmain = new StackLayout();
                    for(int i=0;i<counties.Length;i++)
                    {
                        Button btn = new Button();
                        btn.Text = counties[i];
                        btn.Clicked += delegate { OnCountySelected(btn.Text); };
                        SLmain.Children.Add(btn);
                    }
                    SVmain.Content = SLmain;
                }
                this.Content = SVmain;
            }
        }
        public delegate void CountySelectedEventHandler(string countyName);
        public CountySelectedEventHandler CountySelected;
        private void OnCountySelected(string countyName) { this.IsEnabled = false; Navigation.PopAsync(); CountySelected?.Invoke(countyName); }
    }
}
