using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using WpfMvvm.Context;
using WpfMvvm.Models;
using WpfMvvm.ViewModel;

namespace WpfMvvm.Views;

public partial class EmployeesPage : Page
{
    private EmployeesViewModel _employeesViewModel;

    public EmployeesPage()
    {
        InitializeComponent();
        _employeesViewModel = new EmployeesViewModel(new MvvmDbContext());
        this.DataContext = _employeesViewModel;
    }

    private void EditEmployeeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var selectedEmployee = EmployeesListView.SelectedItem as Employee;
        if (selectedEmployee is null) return;

        var form = new EmployeeFormWindow(selectedEmployee)
        {
            Owner = Application.Current.MainWindow
        };

        var dialogResult = form.ShowDialog() ?? false;

        if (dialogResult)
        {
            _employeesViewModel.Save(selectedEmployee);
        }
    }

    private void AddEmployeeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var employee = new Employee();
        var form = new EmployeeFormWindow(employee)
        {
            Owner = Application.Current.MainWindow
        };

        var dialogResult = form.ShowDialog() ?? false;

        if (dialogResult)
        {
            _employeesViewModel.Save(employee);
        }
    }
}