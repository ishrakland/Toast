using Plugin.Toast.Abstractions;
using System;

namespace Plugin.Toast
{
    /// <summary>
    /// CrossToastPopUp
    /// </summary>
    public static class CrossToastPopUp
    {
        static readonly Lazy<IToastPopUp> Implementation = new Lazy<IToastPopUp>(CreateShowToast, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>S
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => Implementation.Value != null;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IToastPopUp Current
        {
            get
            {
                var ret = Implementation.Value;
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

#if NETSTANDARD1_0
            return null;
#else
        return new ShowToastPopUp();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

    }
}
