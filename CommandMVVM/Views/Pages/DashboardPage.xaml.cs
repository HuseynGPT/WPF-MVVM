using CommandMVVM.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace CommandMVVM.Views.Pages;

public partial class DashboardPage : Page
{
    public DashboardPage()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
