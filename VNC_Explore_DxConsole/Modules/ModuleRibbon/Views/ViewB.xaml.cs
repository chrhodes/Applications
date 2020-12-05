using System.Windows.Controls;
using PrismDemo.Core;
using ModuleRibbon.RibbonTabs;
using Prism.Regions;

namespace ModuleRibbon.Views
{
    /// <summary>
    /// Interaction logic for ViewB
    /// </summary>
    [RibbonPage(typeof(ViewBTab))]
    [DependentView(typeof(ViewBTab2), "RibbonPageCategoryRegion2")]
    [DependentView(typeof(ViewBTab3), "RibbonPageCategoryRegion")]
    [DependentView(typeof(ViewC), "SubRegion")]
    public partial class ViewB : UserControl, ISupportDataContext, IRegionMemberLifetime

    {     
        public ViewB()
        {
            InitializeComponent();
        }

        #region IRegionMemberLifetime

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion

        #region ISupportDataContext

        // Because ViewB is a UserControl, it already has a DataContext
        // Don't need to implement ISupportDataContext!

        #endregion
    }
}
