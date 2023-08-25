using System.Diagnostics;
using Microsoft.Maui.Layouts;

namespace MauiSwipeGestureDirectionBug;

public partial class MainPage : ContentPage
{
    private bool _drawerOpened = false;

    public MainPage()
	{
		InitializeComponent();

        double w = DeviceDisplay.Current.MainDisplayInfo.Width;
        double h = DeviceDisplay.Current.MainDisplayInfo.Height;
        double d = DeviceDisplay.Current.MainDisplayInfo.Density;

        double dpW = w / d;
        double dpH = h / d;

        //position the tileDrawer futher down page
        AbsoluteLayout.SetLayoutBounds(this.tileDrawer, new Rect(0, 400, dpW, dpH));
        AbsoluteLayout.SetLayoutFlags(this.tileDrawer, AbsoluteLayoutFlags.None);
    }

    void SwipeGestureRecognizer_Swiped(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        if(!_drawerOpened)
        {
            this.tileDrawer.TranslateTo(0, -350, 250, Easing.SinInOut);

            this.swipeGesture.Direction = SwipeDirection.Down;

            _drawerOpened = true;
        }
        else
        {
            this.tileDrawer.TranslateTo(0, 0, 250, Easing.SinInOut);

            this.swipeGesture.Direction = SwipeDirection.Up;

            _drawerOpened = false;
        }
    }
}