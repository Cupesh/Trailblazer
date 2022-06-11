using Trailblazer.Services;
using Trailblazer.ViewModels;

namespace Trailblazer.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}


