﻿using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF1.Presentation.Views
{
    public partial class CombinedMain : ViewBase, ICombinedMain, IInstanceCountV
    {

        public CombinedMain(ViewModels.ICombinedMainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            Loaded += OnLoaded;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(CombinedMain) Enter", Common.LOG_CATEGORY);

            await ((ViewModels.ICombinedMainViewModel)ViewModel).LoadAsync();

            Log.EVENT_HANDLER("(CombinedMain) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }

        #endregion

    }
}
