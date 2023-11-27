using MauiCollectionView.MVVM.ViewModels;

namespace MauiCollectionView.MVVM.Views;

public partial class ContatosView : ContentPage
{
	public ContatosView()
	{
		InitializeComponent();
		BindingContext = new ContatoViewModel();		
	}
}