﻿using System;
using System.Windows;

using PAEF1.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF1.Presentation.Views
{
    public partial class MainDxLayout : ViewBase, IMain
    {
        public MainDxLayoutViewModel _viewModel;

        public MainDxLayout(MainDxLayoutViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
