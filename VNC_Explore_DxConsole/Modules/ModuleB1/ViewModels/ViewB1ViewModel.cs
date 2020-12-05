using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Regions;
using System.Windows;
using VNC.Core.Mvvm;
using PersonRepository.Service.MyService;
using VNCExploreConsole.Infrastructure;

namespace ModuleB1
{
    public class ViewB1ViewModel : ViewModelBase, IViewB1ViewModel, INavigationAware, IRegionMemberLifetime, IConfirmNavigationRequest
    {
        private readonly IRegionManager _regionManager;
        private readonly IPersonService _personService;

        #region Constructors

        public ViewB1ViewModel()
        {

        }

        public ViewB1ViewModel(IRegionManager regionManager, IPersonService personService)
        {
            _regionManager = regionManager;
            _personService = personService;
            EmailCommand = new DelegateCommand<PrismDemo.Domain.Person>(Email);
            LoadPeople();
        }

        #endregion //Constructors

        #region Properties

        public DelegateCommand<PrismDemo.Domain.Person> EmailCommand { get; private set; }

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set
            {
                _pageViews = value;
                OnPropertyChanged("PageViews");
            }
        }

        private ObservableCollection<PrismDemo.Domain.Person> _People;
        public ObservableCollection<PrismDemo.Domain.Person> People
        {
            get { return _People; }
            set
            {
                _People = value;
                OnPropertyChanged("People");
            }
        }

        #endregion // Properties

        #region Commands

        private void Email(PrismDemo.Domain.Person person)
        {
            if (person != null)
            {
                //var uriQuery = new UriQuery();
                var uriQuery = new NavigationParameters();
                uriQuery.Add("To", person.Email);

                var uri = new Uri(typeof(Email).FullName + uriQuery, UriKind.Relative);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
            }
        }

        #endregion //Commands

        #region IConfirmNavigationRequest

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            if (MessageBox.Show("Do you want to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                result = false;

            continuationCallback(result);
        }

        #endregion

        #region INavigationAware

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        #endregion

        #region IRegionMemberLifetime

        public bool KeepAlive
        {
            get { return false; }   // Always get new instance
        }

        IView IViewModel.View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        #region Methods

        private void LoadPeople()
        {
            IsBusy = true;
            //_personService.GetPeopleAsync((sender, result) =>
            //{
            //    People = new ObservableCollection<Person>(result.Object);
            //    IsBusy = false;
            //});
        }

        #endregion //Methods
    }
}
