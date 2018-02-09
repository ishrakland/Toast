using Plugin.ToastPopUp.Abstractions;
using System;

namespace Plugin.ToastPopUp
{
    /// <summary>
    /// Cross Toast PopUp
    /// </summary>
    public static class CrossToastPopUp
    {
        static Lazy<IToastPopUp> implementation = new Lazy<IToastPopUp>(() => CreateShowToast(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IToastPopUp Current
        {
            get
            {
                var ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        /// <summary>
        /// Create Toast
        /// </summary>
        /// <returns></returns>
        static IToastPopUp CreateShowToast()
        {

#if PORTABLE
            return null;
#else
            return new ShowToastPopUp();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

    }
}
