using CommunityToolkit.Maui.Alerts;
using MauiAppApiConsumer.Model;
using MauiAppUTN001.ApiConsumer;

namespace MauiAppApiConsumer.ControllerPage;

public partial class Producto : ContentPage
{
	public Producto()
	{
		InitializeComponent();
	}
    private String url = "https://clase-cloud-api.azurewebsites.net";
    private CancellationTokenSource cancellation = new CancellationTokenSource();

    private async void GetByIDProduct(object sender, EventArgs e)
    {
        int id = txtIdProduct.Text != null ? int.Parse(txtIdProduct.Text) : 0;
        var result = ApiConsumer<Product>.Read(url + "/api/Products", id);

        if (result.Name == "")
        {
            var toast = Toast.Make("Product not found");
            await toast.Show(cancellation.Token);
            return;
        }

        txtNameProduct.Text = result.Name;
        txtPriceProduct.Text = result.Price.ToString();
        txtIvaProduct.Text = result.IVA.ToString();
        txtCategoryIdProduct.Text = result.CategoryId.ToString();
        var toast2 = Toast.Make("Product found");
        await toast2.Show(cancellation.Token);
    }

    private async void PostByProduct(object sender, EventArgs e)
    {
        Product product = new Product
        {
            Name = txtNameProduct.Text,
            Price = double.Parse(txtPriceProduct.Text),
            IVA = double.Parse(txtIvaProduct.Text),
            CategoryId = int.Parse(txtCategoryIdProduct.Text)
        };

        var result = ApiConsumer<Product>.Create(url + "/api/Products", product);

        if (result == null)
        {
            var toast = Toast.Make("Product not created ");
            await toast.Show(cancellation.Token);
            return;
        }

        txtIdProduct.Text = result.Id.ToString();

        var toast2 = Toast.Make("Product created");
        await toast2.Show(cancellation.Token);
    }

    private async void PutByProduct(object sender, EventArgs e)
    {
        Product product = new Product
        {
            Id = int.Parse(txtIdProduct.Text),
            Name = txtNameProduct.Text,
            Price= double.Parse(txtPriceProduct.Text),
            IVA = double.Parse(txtIvaProduct.Text),
            CategoryId = int.Parse(txtCategoryIdProduct.Text)
        };

        var result = ApiConsumer<Product>.Update(url + "/api/Products", product.Id, product);
        var toast = Toast.Make("Product updated");
        await toast.Show(cancellation.Token);

    }

    private async void DeleteByProduct(object sender, EventArgs e)
    {
        int id = txtIdProduct.Text != null ? int.Parse(txtIdProduct.Text) : 0;
        ApiConsumer<Product>.Delete(url + "/api/Products", id);

        txtIdProduct.Text = "";
        txtNameProduct.Text = "";
        txtPriceProduct.Text = "";
        txtIvaProduct.Text = "";
        txtCategoryIdProduct.Text = "";
        var toast = Toast.Make("Product deleted");
        await toast.Show(cancellation.Token);
    }

    
}