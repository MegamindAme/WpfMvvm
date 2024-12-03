using Timers = System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WpfMvvm.Models;

namespace WpfMvvm.Views;

public abstract partial class FormWindow : Window
{
    private Timers.Timer _timer;
    private ToolTip _formToolTip { get; set; }
    
    public FormWindow()
    {
        InitializeComponent();
        
        _formToolTip = new()
        {
            Placement = PlacementMode.Top,
            Visibility = Visibility.Collapsed,
            IsOpen = false
        };

        _timer = new Timers.Timer(3000);
        _timer.Elapsed += async (sender, args) =>
        {
            Dispatcher.Invoke(() =>
            {
                _formToolTip.Visibility = Visibility.Collapsed;
                _formToolTip.IsOpen = false;
            });
        };
    }
    
    protected virtual (UIElement?, string) ValidateForm()
    {
        return (null, string.Empty);
    }

    protected void SubmitForm()
    {
        (UIElement ? element, string message) = ValidateForm();

        if (element is not null)
        {
            _formToolTip.Content = message;
            _formToolTip.Visibility = Visibility.Visible;
            _formToolTip.PlacementTarget = element;
            _formToolTip.IsOpen = true;

            _timer.Stop();
            _timer.Start();
        }
    }
}