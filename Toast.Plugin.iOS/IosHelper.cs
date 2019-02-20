using System;
using UIKit;

namespace Plugin.Toast
{
    /// <summary>
    /// 
    /// </summary>
    public static class IosHelper
    {

        /// <summary>
        /// Return currently active and visible controller
        /// </summary>
        /// <returns></returns>
        public static UIViewController GetVisibleViewController()
        {
            try
            {
                var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

                switch (rootController.PresentedViewController)
                {
                    case null:
                        return rootController;
                    case UINavigationController controller:
                        return controller.VisibleViewController;
                    case UITabBarController barController:
                        return barController.SelectedViewController;
                    default:
                        return rootController.PresentedViewController;
                }
            }
            catch (Exception)
            {
                return UIApplication.SharedApplication.KeyWindow.RootViewController;
            }
        }

    }
}