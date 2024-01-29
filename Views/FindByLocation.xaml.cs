using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class FindByLocation : ContentPage
{
	public FindByLocation()
	{
		InitializeComponent();
		this.BindingContext = FindByLocationViewModel();
	}
}