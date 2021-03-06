﻿using System;
using System.Windows;

using PAEF1.Animals.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF1.Animals.Presentation.Views
{
    public partial class Main : ViewBase, IMain
    {
        public MainViewModel _viewModel;

        public Main(MainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
