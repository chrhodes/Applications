using PrismDemo.Core;
using System.Windows.Controls;
using ModuleRibbon.RibbonTabs;

namespace ModuleRibbon.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    [RibbonPage(typeof(ViewATab))]
    [DependentView(typeof(ViewATab), "RibbonPageCategoryRegion")]
    [DependentView(typeof(ViewATab2), "RibbonPageCategoryRegion")]
    public partial class ViewA : UserControl, ISupportDataContext
    {

        public ViewA()
        {
            InitializeComponent();
        }

        // Because ViewA is a UserControl, it already has a DataContext
        // Don't need to implement ISupportDataContext!
    }
}
