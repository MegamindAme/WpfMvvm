using System.Windows.Controls;
using WpfMvvm.Context;
using WpfMvvm.ViewModel;

namespace WpfMvvm.Views;

public partial class DepartmentPage : Page
{
    public DepartmentPage()
    {
        InitializeComponent();
        this.DataContext = new DepartmentViewModel(new MvvmDbContext());
    }
}