﻿using System.Windows;
using System.Windows.Controls;


namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllDepartmentsView;
        public static ListView AllPositionsView;
        public static ListView AllUsersView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.DataManageVM();

            AllDepartmentsView = ViewAllDepartments;
            AllPositionsView = ViewAllPositions;
            AllUsersView = ViewAllUsers;
        }
    }
}