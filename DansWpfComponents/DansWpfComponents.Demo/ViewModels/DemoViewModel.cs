using CommunityToolkit.Mvvm.ComponentModel;

namespace DansWpfComponents.Demo.ViewModels;

[INotifyPropertyChanged]
public abstract partial class DemoViewModel
{
    public DemoViewModel(string name)
    {
        Name = name;
    }

    [ObservableProperty]
    private string _name;
}
