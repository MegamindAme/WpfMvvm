using System.Windows;
using WpfMvvm.Models;

namespace WpfMvvm.Views;

public partial class EmployeeFormWindow : FormWindow
{
    private Employee _employee;

    public EmployeeFormWindow()
    {
        InitializeComponent();
        InitializeForm(new ());
    }

    public EmployeeFormWindow(Employee employee)
    {
        InitializeComponent();
        InitializeForm(employee);
    }
    
    private void Submit_OnClick(object sender, RoutedEventArgs e)
    {
        SubmitForm();
    }

    protected override (UIElement?, string) ValidateForm()
    {
        if (string.IsNullOrEmpty(FirstName.Text.Trim()))
        {
            return (FirstName, "Fill the first name");
        }

        if (string.IsNullOrEmpty(LastName.Text.Trim()))
        {
            return (LastName, "Fill the last name");
        }

        if (string.IsNullOrEmpty(Gender.Text.Trim()))
        {
            return (Gender, "Fill the gender");
        }

        if (string.IsNullOrEmpty(BirthDate.Text.Trim()) || BirthDate.Text == "01/01/0001")
        {
            return (BirthDate, "Fill the birth date");
        }

        if (string.IsNullOrEmpty(HireDate.Text.Trim()) || HireDate.Text == "01/01/0001")
        {
            return (HireDate, "Fill the hire date");
        }

        this.DialogResult = true;
        this.Close();
        
        return (null, string.Empty);
    }
    
    private void InitializeForm(Employee employee)
    {
        _employee = employee;
        DataContext = _employee;
    }

}