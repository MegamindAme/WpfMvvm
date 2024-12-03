using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using WpfMvvm.Context;
using WpfMvvm.Models;

namespace WpfMvvm.ViewModel;

public class EmployeesViewModel
{
    public ObservableCollection<Employee> Employees { get; set; }
    private MvvmDbContext _context;


    public EmployeesViewModel(MvvmDbContext context)
    {
        _context = context;
        Employees = new(_context.Employees.Include(e => e.DeptEmps).Take(30));
    }

    public void Save(Employee employee)
    {
        if (employee.EmpNo <= 0)
        {
            _context.Employees.Add(employee);
        }
        else
        {
            _context.Employees.Update(employee);
        }

        _context.SaveChanges();
    }
}