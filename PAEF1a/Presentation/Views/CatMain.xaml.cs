﻿using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

namespace PAEF1a.Presentation.Views
{
    public partial class CatMain : ViewBase, ICatMain, IInstanceCountV
    {

        public CatMain(ViewModels.ICatMainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            Loaded += UserControl_Loaded;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Int64 startTicks = Log.EVENT_HANDLER("(CatMain) Enter", Common.LOG_CATEGORY);

            await ((ViewModels.ICatMainViewModel)ViewModel).LoadAsync();

            Log.EVENT_HANDLER("(CatMain) Exit", Common.LOG_CATEGORY, startTicks);
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
