using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsStdApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var c = new NetStandardTests.SharedClass();
            c.Color = System.Drawing.Color.Yellow;
            testControl.MyProperty = c;
        }
    }
}
