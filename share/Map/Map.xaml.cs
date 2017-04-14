using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace share
{
	public partial class Map : ContentPage
	{
		public Map()
		{
            //InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            {
                RLmain = new RelativeLayoutMain();
                this.Content = RLmain;
            }
        }
        RelativeLayoutMain RLmain;
        private partial class RelativeLayoutMain : RelativeLayout
        {
            AbsoluteLayout cover;
            private void ShowPanel()
            {
                this.Children.Add(cover,
                    Constraint.RelativeToParent((parent) => { return 0; }),
                    Constraint.RelativeToParent((parent) => { return 0; }),
                    Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    Constraint.RelativeToParent((parent) => { return parent.Height; }));
                this.Children.Add(GDpanel,
                    Constraint.RelativeToParent((parent) => { return 0; }),
                    Constraint.RelativeToParent((parent) => { return 0; }),
                    Constraint.RelativeToParent((parent) => { return parent.Width * 0.5; }),
                    Constraint.RelativeToParent((parent) => { return parent.Height; }));
                const double animationRate = 5.0;
                this.Animate("ShowPanel", new Animation(new Action<double>((v) =>
                 {
                     GDpanel.TranslationX = this.Width * 0.5 * ((1.0-Math.Pow(2.0, animationRate * (1.0-v))/ Math.Pow(2.0, animationRate)) - 1.0);
                     cover.BackgroundColor = Color.FromRgba(0.0, 0.0, 0.0, 0.5*v);
                 }), 0, 1));
            }
            private void HidePanel()
            {
                const double animationRate = 5.0;
                this.Animate("HidePanel", new Animation(new Action<double>((v) =>
                {
                    GDpanel.TranslationX = this.Width * 0.5 * ( -(1.0 - Math.Pow(2.0, animationRate * (1.0 - v)) / Math.Pow(2.0, animationRate)));
                    cover.BackgroundColor = Color.FromRgba(0.0, 0.0, 0.0, 0.5 * (1.0 - v));
                }), 0, 1), 16, 250, null, new Action<double, bool>((double a, bool b) =>
                {
                    this.Children.Remove(GDpanel);
                    this.Children.Remove(cover);
                }));
            }
            public RelativeLayoutMain()
            {
                this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                {
                    GDmain = new GridMain();
                    GDmain.PanelButtonClicked += delegate { ShowPanel(); };
                    this.Children.Add(GDmain,
                        Constraint.RelativeToParent((parent) => { return 0; }),
                        Constraint.RelativeToParent((parent) => { return 0; }),
                        Constraint.RelativeToParent((parent) => { return parent.Width; }),
                        Constraint.RelativeToParent((parent) => { return parent.Height; }));
                }
                {
                    GDpanel = new GridPanel();
                    GDpanel.PanelButtonClicked += delegate () { HidePanel(); };
                }
                {
                    cover = new AbsoluteLayout();
                    cover.GestureRecognizers.Add(new TapGestureRecognizer
                    {
                        Command = new Command(() => HidePanel())
                    });
                }
            }
            GridMain GDmain;
            GridPanel GDpanel;
            private partial class GridPanel : Grid
            {
                private Button BTNphoto, BTNgoToHistory, BTNmoney, BTNvehicle, BTNcollection, BTNservice, BTNsetting;
                private ScrollView SVmain;
                private StackLayout SLmain;
                private void InitializeViews()
                {
                    this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                    this.BackgroundColor = Color.FromRgb(1.0, 0.8, 0.5);
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150, GridUnitType.Absolute) });
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    {
                        BTNphoto = new Button();
                        BTNphoto.VerticalOptions = BTNphoto.HorizontalOptions = LayoutOptions.FillAndExpand;
                        //BTNphoto.ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left, 5);
                        BTNphoto.Image = "addUser.png";
                        //BTNphoto.Source = "addUser.png";
                        BTNphoto.Clicked += delegate
                          {
                              var newPage = new Personal_Page();
                              Navigation.PushAsync(newPage);
                              OnPanelButtonClicked();
                          };
                        this.Children.Add(BTNphoto, 0, 0);
                    }
                    {
                        SVmain = new ScrollView();
                        SVmain.VerticalOptions = SVmain.HorizontalOptions = LayoutOptions.FillAndExpand;
                        {
                            SLmain = new StackLayout();
                            SLmain.VerticalOptions = SLmain.HorizontalOptions = LayoutOptions.FillAndExpand;
                            {
                                BTNgoToHistory = new Button();
                                BTNgoToHistory.Text = "訂單";
                                BTNgoToHistory.Clicked += delegate
                                {
                                    var newPage = new My_Purse_Page();
                                    Navigation.PushAsync(newPage);
                                    OnPanelButtonClicked();
                                };
                                SLmain.Children.Add(BTNgoToHistory);
                            }
                            {
                                BTNmoney = new Button();
                                BTNmoney.Text = "錢包";
                                BTNmoney.Clicked += delegate
                                {
                                    var newPage = new My_Purse_Page();
                                    Navigation.PushAsync(newPage);
                                    OnPanelButtonClicked();
                                };
                                SLmain.Children.Add(BTNmoney);
                            }
                            {
                                BTNvehicle = new Button();
                                BTNvehicle.Text = "車輛";
                                BTNvehicle.Clicked += delegate
                                {
                                    App.Current.MainPage.DisplayAlert("", "Not implement", "Back");
                                    OnPanelButtonClicked();
                                };
                                SLmain.Children.Add(BTNvehicle);
                            }
                            {
                                BTNcollection = new Button();
                                BTNcollection.Text = "收藏";
                                BTNcollection.Clicked += delegate
                                {
                                    var newPage = new My_Purse_Page();
                                    Navigation.PushAsync(newPage);
                                    OnPanelButtonClicked();
                                };
                                SLmain.Children.Add(BTNcollection);
                            }
                            {
                                BTNservice = new Button();
                                BTNservice.Text = "客服";
                                BTNservice.Clicked += delegate
                                {
                                    var newPage = new My_Purse_Page();
                                    Navigation.PushAsync(newPage);
                                    OnPanelButtonClicked();
                                };
                                SLmain.Children.Add(BTNservice);
                            }
                            {
                                BTNsetting = new Button();
                                BTNsetting.Text = "設定";
                                BTNsetting.Clicked += delegate
                                {
                                    var newPage = new Setting_Page();
                                    Navigation.PushAsync(newPage);
                                    OnPanelButtonClicked();
                                };
                                SLmain.Children.Add(BTNsetting);
                            }
                            SVmain.Content = SLmain;
                        }
                        this.Children.Add(SVmain, 0, 1);
                    }
                }
                public GridPanel()
                {
                    InitializeViews();
                }
                public delegate void PanelButtonClickedEventHandler();
                public event PanelButtonClickedEventHandler PanelButtonClicked;
                private void OnPanelButtonClicked() { PanelButtonClicked?.Invoke(); }
            }
            private partial class GridMain : Grid
            {
                public GridMain()
                {
                    this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    GDup = new GridUp();
                    GDmap = new GridMap();
                    GDdown = new GridDown();
                    {
                        GDup.PanelButtonClicked += delegate { OnPanelButtonClicked(); };
                        GDup.ChangeMapCountyRequest += delegate (string countyName) { GDmap.SetCounty(countyName); };
                        this.Children.Add(GDup, 0, 0);
                    }
                    {
                        this.Children.Add(GDmap, 0, 1);
                    }
                    {
                        this.Children.Add(GDdown, 0, 2);
                    }
                }
                GridUp GDup;
                GridMap GDmap;
                GridDown GDdown;
                public delegate void PanelButtonClickedEventHandler();
                public PanelButtonClickedEventHandler PanelButtonClicked;
                private void OnPanelButtonClicked() { PanelButtonClicked?.Invoke(); }
                private partial class GridDown:Grid
                {
                    Button BTNborrow, BTNbuy;
                    public GridDown()
                    {
                        this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                        this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        {
                            BTNborrow = new Button();
                            BTNborrow.VerticalOptions = BTNborrow.HorizontalOptions = LayoutOptions.FillAndExpand;
                            BTNborrow.Text = "Borrow";
                            this.Children.Add(BTNborrow, 0, 0);
                        }
                        {
                            BTNbuy = new Button();
                            BTNbuy.VerticalOptions = BTNbuy.HorizontalOptions = LayoutOptions.FillAndExpand;
                            BTNbuy.Text = "Buy";
                            this.Children.Add(BTNbuy, 1, 0);
                        }
                    }
                }
                private partial class GridMap:Grid
                {
                    Xamarin.Forms.Maps.Map map;
                    Dictionary<string, string> translation = new Dictionary<string, string>();
                    Dictionary<string, MapSpan> countyMapSpan = new Dictionary<string, MapSpan>();
                    public void SetCounty(string countyName)
                    {
                        if(!translation.ContainsKey(countyName))
                        {
                            App.Current.MainPage.DisplayAlert("Error", $"Can't identify such county: {countyName}", "OK");
                            return;
                        }
                        map.MoveToRegion(new MapSpan(new Position(25.033939, 121.564504), 0.5, 0.5));

                        App.Current.MainPage.DisplayAlert("", $"You're now at {countyName}, {translation[countyName]}", "OK");
                        //LBtest.Text = $"You're now at {countyName}";
                    }
                    public GridMap()
                    {
                        InitializeView();
                        LoadData();
                    }
                    private async void LoadData()
                    {
                        //translation.Add("臺北", "Taipei");
                        //translation.Add("高雄", "Kaohsiung");
                        //await App.Current.MainPage.DisplayAlert("", Newtonsoft.Json.JsonConvert.SerializeObject(translation),"OK");
                        //Debug.WriteLine("aa");
                        translation = DataStorer<Dictionary<string, string>>.Parse(Properties.Resources.CountyNameTranslations);
                        //Debug.WriteLine("bb");
                        {
                            countyMapSpan.Add("Taipei", new MapSpan(new Position(25.033939, 121.564504), 0.5, 0.5));
                            //Debug.WriteLine("cc");
                            var ds = new DataStorer<Dictionary<string, MapSpan>>(countyMapSpan, "debug", "debug");
                            Debug.WriteLine("dd");
                            await ds.SaveAsync();
                            //Debug.WriteLine("ee");
                            await ds.LoadAsync();
                            //Debug.WriteLine("ff");
                            countyMapSpan = ds.data;
                            //Debug.WriteLine("gg");
                            await App.Current.MainPage.DisplayAlert("", ds.ToString(), "OK");
                        }
                    }
                    private void InitializeView()
                    {
                        this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                        {
                            map = new Xamarin.Forms.Maps.Map(
                                MapSpan.FromCenterAndRadius(
                                        new Position(37, -122), Distance.FromMiles(0.3)))
                            {
                                IsShowingUser = true,
                                HeightRequest = 100,
                                WidthRequest = 960,
                                VerticalOptions = LayoutOptions.FillAndExpand
                            };
                            //new Pin { }
                            map.MoveToRegion(new MapSpan(new Position(25.033939, 121.564504), 0.5, 0.5));
                            this.Children.Add(map, 0, 0);
                        }
                    }
                }
                private partial class GridUp : Grid
                {
                    Button BTNpanel;
                    Button BTNsearch;
                    public GridUp()
                    {
                        this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                        this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                        this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        {
                            BTNpanel = new Button();
                            BTNpanel.Text = "<<";
                            BTNpanel.Clicked += delegate { OnPanelButtonClicked(); };
                            this.Children.Add(BTNpanel, 0, 0);
                        }
                        {
                            BTNsearch = new Button();
                            BTNsearch.Clicked += delegate
                            {
                                var countiesPage = new CountiesPage();
                                countiesPage.CountySelected += delegate (string countyName) { OnChangeMapCountyRequest(countyName); };
                                Navigation.PushAsync(countiesPage);
                            };
                            this.Children.Add(BTNsearch, 1, 0);
                        }
                    }
                    public PanelButtonClickedEventHandler PanelButtonClicked;
                    private void OnPanelButtonClicked() { PanelButtonClicked?.Invoke(); }
                    public delegate void ChangeMapCountyRequestEventHandler(string countyName);
                    public ChangeMapCountyRequestEventHandler ChangeMapCountyRequest;
                    private void OnChangeMapCountyRequest(string countyName) { ChangeMapCountyRequest?.Invoke(countyName); }
                }
            }
        }
    }
}
