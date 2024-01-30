using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class FindByLocation : ContentPage
{
	public FindByLocation()
	{
		InitializeComponent();
		//הקשר בין הויאו מודל לבין העמוד הראשי
		//אומר בעצם שזה מחובר לויאו מודל של המצא לפי לוקיישן
		this.BindingContext = new FindByLocationViewModel();
	}
}