using TabsDataShare.ViewModels;

namespace TabsDataShare.Views;

public partial class Page2 : ContentPage
{
	public Page2(SharedViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}