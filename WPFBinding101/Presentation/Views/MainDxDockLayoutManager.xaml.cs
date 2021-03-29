﻿using System;
using System.Windows;

using .Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace .Presentation.Views
{
    public partial class MainDxDockLayoutManager : ViewBase, IMain
    {
        public MainDxDockLayoutManagerViewModel _viewModel;

        public MainDxDockLayoutManager(MainDxDockLayoutManagerViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_CATEGORY);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
