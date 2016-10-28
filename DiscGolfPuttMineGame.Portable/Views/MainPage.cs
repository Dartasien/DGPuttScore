using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Portable.Views
{
    public class MainPage : ContentView
    {
        public MainPage()
        {
            Content = new Label { Text = "Hello View" };
        }
    }
}
