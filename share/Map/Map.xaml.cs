using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
            public RelativeLayoutMain()
            {
                this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                {
                    GDmain = new GridMain();
                    GDmain.PanelButtonClicked += delegate
                    {
                        GDmain.IsEnabled = false;
                        this.Children.Add(GDpanel,
                            Constraint.RelativeToParent((parent) => { return 0; }),
                            Constraint.RelativeToParent((parent) => { return 0; }),
                            Constraint.RelativeToParent((parent) => { return parent.Width * 0.5; }),
                            Constraint.RelativeToParent((parent) => { return parent.Height; }));
                    };
                    this.Children.Add(GDmain,
                        Constraint.RelativeToParent((parent) => { return 0; }),
                        Constraint.RelativeToParent((parent) => { return 0; }),
                        Constraint.RelativeToParent((parent) => { return parent.Width; }),
                        Constraint.RelativeToParent((parent) => { return parent.Height; }));
                }
                {
                    GDpanel = new GridPanel();
                    GDpanel.PanelButtonClicked +=async delegate (string option)
                      {
                          await App.Current.MainPage.DisplayAlert("", $"You clicked {option}", "OK");
                          GDmain.IsEnabled = true;
                          this.Children.Remove(GDpanel);
                      };
                }
            }
            GridMain GDmain;
            GridPanel GDpanel;
            private partial class GridPanel:Grid
            {
                public GridPanel()
                {
                    this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                    this.BackgroundColor = Color.FromRgb(1.0, 0.5, 0.0);
                    int n = 5;
                    for (int i = 0; i < n; i++) this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    for(int i=0;i<n;i++)
                    {
                        Button btn = new Button();
                        btn.Text = "Option " + (i + 1).ToString();
                        btn.Clicked += delegate { OnPanelButtonClicked(btn.Text); };
                        this.Children.Add(btn, 0, i);
                    }
                }
                public delegate void PanelButtonClickedEventHandler(string option);
                public event PanelButtonClickedEventHandler PanelButtonClicked;
                private void OnPanelButtonClicked(string option){ PanelButtonClicked?.Invoke(option); }
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
                    GDmiddle = new GridMiddle();
                    GDdown = new GridDown();
                    {
                        GDup.PanelButtonClicked += delegate { OnPanelButtonClicked(); };
                        GDup.ChangeMapCountyRequest += delegate (string countyName) { GDmiddle.SetCounty(countyName); };
                        this.Children.Add(GDup, 0, 0);
                    }
                    {
                        this.Children.Add(GDmiddle, 0, 1);
                    }
                    {
                        this.Children.Add(GDdown, 0, 2);
                    }
                }
                GridUp GDup;
                GridMiddle GDmiddle;
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
                private partial class GridMiddle:Grid
                {
                    Label LBtest;
                    public void SetCounty(string countyName)
                    {
                        LBtest.Text = $"You're now at {countyName}";
                    }
                    public GridMiddle()
                    {
                        this.VerticalOptions = this.HorizontalOptions = LayoutOptions.FillAndExpand;
                        {
                            LBtest = new Label();
                            LBtest.Text = "This is map";
                            this.Children.Add(LBtest, 0, 0);
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
