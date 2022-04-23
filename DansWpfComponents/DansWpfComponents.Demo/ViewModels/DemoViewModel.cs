using CommunityToolkit.Mvvm.ComponentModel;

namespace DansWpfComponents.Demo.ViewModels;

[INotifyPropertyChanged]
public abstract partial class DemoViewModel
{
    [ObservableProperty]
    private string _name;
}
