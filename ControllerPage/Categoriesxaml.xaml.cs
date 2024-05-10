using CommunityToolkit.Maui.Alerts;
using MauiAppApiConsumer.Model;
using MauiAppUTN001.ApiConsumer;
using Newtonsoft.Json;

namespace MauiAppApiConsumer.ControllerPage;

public partial class Categoriesxaml : ContentPage
{
	public Categoriesxaml()
	{
		InitializeComponent();
	}

    private String url = "https://clase-cloud-api.azurewebsites.net";
    private CancellationTokenSource cancellation = new CancellationTokenSource();


    private async void GetByIdProduct(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;
        var result = ApiConsumer<Category>.Read(url + "/api/Categories", id);

        if (result.Name == null)
        {
            var toast = Toast.Make("Category not found");
            await toast.Show(cancellation.Token);
            return;
        }

        txtName.Text = result.Name;
        var toast2 = Toast.Make("Category found");
        await toast2.Show(cancellation.Token);
    }

    private async void PostByProduct(object sender, EventArgs e)
    {        
        Category category = new Category
        {
            Name = txtName.Text
        };

        var result = ApiConsumer<Category>.Create(url + "/api/Categories", category);

        if (result.Name == null)
        {
            
            var toast = Toast.Make("Category not created");
            await toast.Show(cancellation.Token);
            return;
        }

        this.txtId.Text = result.Id.ToString();

        var toast2 = Toast.Make("Category created");
        await toast2.Show(cancellation.Token);
    }

    private async void PutByProduct(object sender, EventArgs e)
    {
        Category category = new Category
        {
            Id = int.Parse(txtId.Text),
            Name = txtName.Text
        };

        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;

        if (id == 0)
        {
            var toast2 = Toast.Make("Category not found");
            await toast2.Show(cancellation.Token);
            return;
        }

        var result = ApiConsumer<Category>.Update(url + "/api/Categories", category.Id, category);
        var toast = Toast.Make("Category updated");
        await toast.Show(cancellation.Token);
    }

    private async void DeleteByProduct(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;
        ApiConsumer<Category>.Delete(url + "/api/Categories", id);

        if (id == 0)
        {
            var toast2 = Toast.Make("Category not found");
            await toast2.Show(cancellation.Token);
            return;
        }

        txtId.Text = "";
        txtName.Text = "";
        var toast = Toast.Make("Category deleted");
        await toast.Show(cancellation.Token);
    }    
}