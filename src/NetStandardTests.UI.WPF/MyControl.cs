using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NetStandardTests.UI
{
    /// <summary>
    /// Custom platform control for WPF
    /// </summary>
    public class MyControl : ContentControl
    {
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
            ((MyControl)d).Foreground = new SolidColorBrush(Color.FromArgb(c.A, c.R, c.G, c.B));
        }
    }
}
