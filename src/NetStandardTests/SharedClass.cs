using System;

namespace NetStandardTests
{
    /// <summary>
    /// The shared class used for testing
    /// </summary>
    public class SharedClass
    {
        /// <summary>
        /// Gets a unique platform string and current time
        /// </summary>
        /// <returns></returns>
        public string Test()
        {
            string prefix = "UNKNOWN";
#if NET461
            prefix = ".NET FX";
#elif __IOS__
            prefix = "iOS";
#elif __ANDROID__
            prefix = "Android";
#elif NETFX_CORE
            prefix = "UWP";
#elif NETSTANDARD2_0
            prefix = ".NET Standard";
#endif

#if XAMARIN
            prefix = "Xamarin." + prefix;
#endif
            return $"{prefix} : {DateTime.Now}";
        }

        /// <summary>
        /// Gets or sets the color
        /// </summary>
        public System.Drawing.Color Color { get; set; }

        // *******************************************************************************
        // Test that you can still expose platform specific members
        // These will only be available in projects that matches the target framework
        // *******************************************************************************

#if !NETSTANDARD2_0
        /// <summary>
        /// Platform property
        /// </summary>
#if NETFX
        public int NETFXProperty {get; set; } = 1;
#elif NETFX_CORE
        public int UWPProperty {get; set; } = 2;
#elif __IOS__
        public int IosProperty {get; set; } = 4;
#elif __ANDROID__
        public int AndroidProperty {get; set; } = 8;
#endif
#if XAMARIN
        /// <summary>
        /// Xamarin property
        /// </summary>
        public int XamarinProperty {get; set; } = 16;
#endif
#endif
    }
}
