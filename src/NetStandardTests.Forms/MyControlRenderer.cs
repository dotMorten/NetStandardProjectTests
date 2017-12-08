using Xamarin.Forms;
#if __ANDROID__
using Xamarin.Forms.Platform.Android;
#elif __IOS__
using Xamarin.Forms.Platform.iOS;
#elif NETFX_CORE
using Xamarin.Forms.Platform.UWP;
#endif

#if !NETSTANDARD
[assembly: ExportRenderer(typeof(NetStandardTests.Forms.MyControl), typeof(NetStandardTests.Forms.MyControlRenderer))]
#endif
namespace NetStandardTests.Forms
{
#if !NETSTANDARD
    internal class MyControlRenderer : ViewRenderer<NetStandardTests.Forms.MyControl, NetStandardTests.UI.MyControl>
    {
#if __ANDROID__
        public MyControlRenderer(Android.Content.Context context) : base(context)
        {
        }
#endif
    }
#endif
}

#if NETSTANDARD
namespace NetStandardTests.UI
{
    internal class MyControl
    {
        public MyControl()
        {
            throw new System.NotImplementedException();
        }

        public SharedClass MyProperty { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
#endif
