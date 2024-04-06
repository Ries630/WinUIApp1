using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp1;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class BlankPage1 : Page
{
    /// <summary>
    /// ViewModel
    /// </summary>
    public BlankPage1ViewModel ViewModel { get; } = new();

    public BlankPage1()
    {
        InitializeComponent();
        DataContext = ViewModel;

        ViewModel.Items.Add(new() { Id = 1, Name = "Name 1" });
        ViewModel.Items.Add(new() { Id = 2, Name = "Name 2" });
        ViewModel.Items.Add(new() { Id = 3, Name = "Name 3" });
    }
}

/// <summary>
/// ViewModel
/// </summary>
public partial class BlankPage1ViewModel : ObservableObject
{
    /// <summary>
    /// Item Collection
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<Items> items = [];

    [ObservableProperty]
    private string textBlock1;

    [ObservableProperty]
    private string textBox1;

    [RelayCommand]
    private void Confirm()
    {
    }


}

/// <summary>
/// Item Model
/// </summary>
public class Items : BindableBase
{
    private int id;
    private string name;
    private string editable;

    public int Id
    {
        get => id;
        set => SetProperty(ref id, value);
    }

    public string Name
    {
        get => name;
        set => SetProperty(ref name, value);
    }

    public string Editable
    {
        get => editable;
        set => SetEditingProperty(ref editable, value);
    }

    public string IsEditingLabel => IsEditing ? "Åõ" : "Å~";
}
