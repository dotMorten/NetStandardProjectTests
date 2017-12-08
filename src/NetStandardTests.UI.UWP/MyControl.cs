using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace NetStandardTests.UI
{
    /// <summary>
    /// Custom platform control for UWP
    /// </summary>
    public class MyControl : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyControl"/> class
        /// </summary>
        public MyControl() : base() { }

        /// <summary>
        /// Gets or sets the test property
        /// </summary>
        public SharedClass MyProperty
        {
            get { return (SharedClass)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="MyProperty"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(SharedClass), typeof(MyControl), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyControl)d).Content = (e.NewValue as SharedClass)?.Test();
            var c = ((e.NewValue as SharedClass)?.Color ?? System.Drawing.Color.Red);
            ((MyControl)d).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(c.A, c.R, c.G, c.B));
        }
    }
}
