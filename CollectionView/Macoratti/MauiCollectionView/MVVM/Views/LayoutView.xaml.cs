using MauiCollectionView.MVVM.Models;
using MauiCollectionView.MVVM.ViewModels;

namespace MauiCollectionView.MVVM.Views;

public partial class LayoutView : ContentPage
{
	public LayoutView()
	{
		InitializeComponent();
		BindingContext = new ProdutoViewModel();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var anterior = e.PreviousSelection;
		var atual = e.CurrentSelection;


        if (atual.FirstOrDefault() is Produto produto)
        {   
            await Application.Current.MainPage.DisplayAlert("Nome da revista", produto.Nome, "OK");
        }

    }
}