using TabsDataShare.ViewModels;

namespace TabsDataShare.Views;

public partial class EntryPage : ContentPage
{
	public EntryPage(SharedViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}