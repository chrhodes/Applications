﻿using PeopleViewer.SharedObjects;
using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ModulePeopleViewerLooseCoupling
{
    public class PeopleViewerViewModel : INotifyPropertyChanged
    {
        // Problem.  Repository is of concrete type, ServiceRepository.
        // Must have a direct reference to a ServiceRepository.

        //protected ServiceRepository Repository;

        protected IPersonRepository Repository;

        private IEnumerable<Person> _people;
        public IEnumerable<Person> People
        {
            get { return _people; }
            set
            {
                if (_people == value)
                    return;
                _people = value;
                RaisePropertyChanged("People");
            }
        }

        // Problem.  PeopleViewerViewModel is tightly coupled to ServiceRepository
        // It has a direct reference to the PersonRepository.Service class,
        // which must exist and be compiled for PeopleViewerViewModel to work.
        // PeopleViewerViewModel must also manage the lifetime of PersonRepository.Service

        //public PeopleViewerViewModel()
        //{
        //    Repository = new ServiceRepository();
        //}

        // Use Constructor Injection to pass in repository

        public PeopleViewerViewModel(IPersonRepository repository)
        {
            Repository = repository;
        }

        #region Commands

        #region RefreshCommand Standard Stuff

        private RefreshCommand _refreshPeopleCommand = new RefreshCommand();
        public RefreshCommand RefreshPeopleCommand
        {
            get
            {
                if (_refreshPeopleCommand.ViewModel == null)
                    _refreshPeopleCommand.ViewModel = this;
                return _refreshPeopleCommand;
            }
        }

        public class RefreshCommand : ICommand
        {
            public PeopleViewerViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            #endregion RefreshCommand Standard Stuff

            public void Execute(object parameter)
            {
                ViewModel.People = ViewModel.Repository.GetPeople();
            }
        }

        #region ClearCommand Standard Stuff

        private ClearCommand _clearPeopleCommand = new ClearCommand();
        public ClearCommand ClearPeopleCommand
        {
            get
            {
                if (_clearPeopleCommand.ViewModel == null)
                    _clearPeopleCommand.ViewModel = this;
                return _clearPeopleCommand;
            }
        }

        public class ClearCommand : ICommand
        {
            public PeopleViewerViewModel ViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            #endregion

            public void Execute(object parameter)
            {
                ViewModel.People = new List<Person>();
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
