using Prism.Commands;

namespace WPFBinding101.Core
{
    public class ApplicationCommands
    {
        public static CompositeCommand NavigateCommand = new CompositeCommand();
        public static CompositeCommand OpenShellCommand = new CompositeCommand();
    }
}
