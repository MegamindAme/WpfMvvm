using System;
using System.Collections.Generic;

namespace WpfMvvm.Models;

public partial class Employee
{
    public int EmpNo { get; set; }

    public DateOnly BirthDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public virtual ICollection<DeptEmp> DeptEmps { get; set; } = new List<DeptEmp>();

    public virtual ICollection<DeptManager> DeptManagers { get; set; } = new List<DeptManager>();

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual ICollection<Title> Titles { get; set; } = new List<Title>();
}
