using DevExpress.Xpf.Ribbon;
using PrismDemo.Core;

namespace ModuleRibbon.RibbonTabs
{
    /// <summary>
    /// Interaction logic for ViewBTab.xaml
    /// </summary>
    public partial class ViewBTab : RibbonPage, ISupportDataContext
    {
        public ViewBTab()
        {
            InitializeComponent();
            //SetResourceReference(StyleProperty, typeof(BackstageTabItem));
        }
    }
}
