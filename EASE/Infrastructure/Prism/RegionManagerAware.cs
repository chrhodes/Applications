using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Infrastructure.Prism
{
    public static class RegionManagerAware
    {
        public static void SetRegionManagerAware(object item, IRegionManager regionManager)
        {
            // Want to support View and ViewModel first approaches so
            // Perhaps this could become an extension method on RegionManager!

            var isRegionManagerAware = item as IRegionManagerAware;

            // View supports IRegionManagerAware - View first approach
            if (isRegionManagerAware != null)
            {
                isRegionManagerAware.RegionManager = regionManager;
            }

            // If we get a ViewModel it will be a FrameworkElement in WPF
            // ViewModel first approach

            var isRegionManagerFrameworkElement = item as FrameworkElement;

            if (isRegionManagerFrameworkElement != null)
            {
                var isRegionManagerAwareDataContext = isRegionManagerFrameworkElement.DataContext as IRegionManagerAware;

                if (isRegionManagerAwareDataContext != null)
                {
                    isRegionManagerAwareDataContext.RegionManager = regionManager;
                }
            }
        }
    }
}
