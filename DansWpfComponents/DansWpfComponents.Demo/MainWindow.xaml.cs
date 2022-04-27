using DansWpfComponents.Demo.ViewModels;

namespace DansWpfComponents.Demo;

public partial class MainWindow
{
    public MainWindow(MainViewModel mainViewModel)
    {
        DataContext = mainViewModel;
        InitializeComponent();
    }
}
