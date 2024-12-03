using System.Collections.ObjectModel;
using WpfMvvm.Context;
using WpfMvvm.Models;

namespace WpfMvvm.ViewModel;

public class DepartmentViewModel
{
    public ObservableCollection<Department> Departments { get; set; }
    private MvvmDbContext _context;


    public DepartmentViewModel(MvvmDbContext context)
    {
     _context = context;   
        Departments = new(_context.Departments.Take(30));
    }
}