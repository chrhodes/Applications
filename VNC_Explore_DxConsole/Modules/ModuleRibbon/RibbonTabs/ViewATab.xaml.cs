using DevExpress.Xpf.Ribbon;
using PrismDemo.Core;

namespace ModuleRibbon.RibbonTabs
{
    /// <summary>
    /// Interaction logic for ViewATab.xaml
    /// </summary>
    public partial class ViewATab : RibbonPage, ISupportDataContext
    {
        public ViewATab()
        {
            InitializeComponent();
            //SetResourceReference(StyleProperty, typeof(BackstageTabItem));
        }
    }
}
