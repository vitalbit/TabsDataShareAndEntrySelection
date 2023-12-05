using TabsDataShare.ViewModels;

namespace TabsDataShare.Views;

public partial class Page1 : ContentPage
{
	public Page1(Page1ViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}