﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Model.Astu;
using Contingent.DialogService;
using GalaSoft.MvvmLight;

namespace Contingent.ViewModel.Workspaces.Students
{
    public class EnrollmentOrderViewModel : ViewModelBase
    {
        public EnrollmentOrderViewModel(EnrollmentOrder order)
        {
            _order = order;
        }

        EnrollmentOrder _order;

        public EnrollmentOrder Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                RaisePropertyChanged("Order");
            }
        }

        public ObservableCollection<Group> Groups
        {
            get
            {
                return new ObservableCollection<Group>(Astu.Groups.Where(g => !g.IsGraduated).OrderBy(g => g.Name));
            }
        }

        public ObservableCollection<Faculty> Faculties
        {
            get
            {
                return new ObservableCollection<Faculty>(Astu.Faculties.OrderBy(f => f.Name));
            }
        }

        public ObservableCollection<Direction> Directions
        {
            get
            {
                return new ObservableCollection<Direction>(Astu.Directions.OrderBy(d => d.Name));
            }
        }

        public ObservableCollection<FinanceSource> FinanceSources
        {
            get
            {
                return new ObservableCollection<FinanceSource>(Astu.FinanceSources.OrderBy(fs => fs.Name));
            }
        }

    }
}