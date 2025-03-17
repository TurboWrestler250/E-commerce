namespace FUST.ECommerce.Pages.Admin.Products;

using FUST.ECommerce.Models;
using FUST.ECommerce.Services;

public partial class Products(IProductsDataAccess productsDataAccess)
{
    private IEnumerable<Product>? _products;

    private bool showPopup = false;
    private string popupMessage = "";

    private Product _input = new();

    protected override void OnInitialized()
    {
        _products = productsDataAccess.GetProducts();
    }

    private void RefreshProducts()
    {
        _products = productsDataAccess.GetProducts();
        StateHasChanged(); // Forza l'aggiornamento dell'interfaccia utente
        _input = new();
    }

    private void SaveProduct()
    {

        int last_insert_id = productsDataAccess.AddProduct(_input);

        // Simulazione salvataggio nel database
        popupMessage = $"La categoria '{_input.Title}' è stata salvato con successo!";
        showPopup = true;

        // Aggiorna la tabella
        RefreshProducts();
    }

    private void ClosePopup()
    {
        showPopup = false;
    }
}
