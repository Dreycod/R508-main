using BlazorApp.Models;
using BlazorApp.Service;
using BlazorBootstrap;
using System.Threading.Tasks;

public class ProduitsTableViewModel
{
    private readonly WebService service;
    private readonly ToastNotifications toastNotifications;

    public List<Produit> Produits { get; set; } = new();

    public ProduitsTableViewModel()
    {
        service = new WebService();
        toastNotifications = new ToastNotifications();
    }

    public async Task<ToastMessage> LoadData()
    {
        IEnumerable<Produit> produits = await service.GetAllAsync();

        if (produits != null)
        {
            Produits = produits.ToList();
            return toastNotifications.Create("Products loaded succesfully", ToastType.Success, "Success!");
        }

        return toastNotifications.Create("Products not found", ToastType.Success, "Failed!");
    }
}
