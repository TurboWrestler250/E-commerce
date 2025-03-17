namespace FUST.ECommerce.Pages.Admin.Categories;

using FUST.ECommerce.Models;
using FUST.ECommerce.Services;

public partial class Categories(ICategoriesDataAccess categoriesDataAccess)
{
    private IEnumerable<Category>? _categories;
    
    private bool showPopup = false;
    private string popupMessage = "";

    private Category _input = new();

    //public string Name { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        _categories = categoriesDataAccess.GetCategories();
    }

    private void RefreshCategories()
    {
        _categories = categoriesDataAccess.GetCategories();
        StateHasChanged(); // Forza l'aggiornamento dell'interfaccia utente
        _input = new();
    }

    private void SaveCategory()
    {
        int last_insert_id = categoriesDataAccess.AddCategory(_input);

        // Simulazione salvataggio nel database
        popupMessage = $"La categoria '{_input.Name}' è stata salvata con successo!";
        showPopup = true;

        // Aggiorna la tabella
        RefreshCategories();
    }

    private void ClosePopup()
    {
        showPopup = false;
    }
}
