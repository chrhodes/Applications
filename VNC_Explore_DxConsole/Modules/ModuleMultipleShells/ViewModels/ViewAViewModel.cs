﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using VNC.Core.Mvvm.Prism;
using VNCExploreConsole.Infrastructure;

namespace ModuleRMS.ViewModels
{
    public class ViewAViewModel : BindableBase, IRegionManagerAware
    {
        public DelegateCommand NavigateCommand { get; set; }

        public ViewAViewModel()
        {
            NavigateCommand = new DelegateCommand(Navigate);
        }

        void Navigate()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewB");
        }

        public IRegionManager RegionManager { get; set; }
    }
}