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

    private async void Get_Clicked(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;
        var result = ApiConsumer<Category>.Read(url + "/api/Categories", id);

        if (result.Name == null)
        {
            await DisplayAlert("Get", "Category not found", "Ok");
            return;
        }

        txtName.Text = result.Name;
        await DisplayAlert("Get", "Category retrieved", "Ok");
    }

    private async void Post_Clicked(object sender, EventArgs e)
    {
        Category category = new Category
        {
            Name = txtName.Text
        };

        var result = ApiConsumer<Category>.Create(url + "/api/Categories", category);

        if (result == null)
        {
            await DisplayAlert("Create", "Category not created", "Ok");
            return;
        }

        this.txtId.Text = result.Id.ToString();

        await DisplayAlert("Create", "Category created", "Ok");
    }

    private async void Put_Clicked(object sender, EventArgs e)
    {
        Category category = new Category
        {
            Id = int.Parse(txtId.Text),
            Name = txtName.Text
        };

        var result = ApiConsumer<Category>.Update(url + "/api/Categories", category.Id, category);
        await DisplayAlert("Update", "Category updated", "Ok");
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        int id = txtId.Text != null ? int.Parse(txtId.Text) : 0;
        ApiConsumer<Category>.Delete(url + "/api/Categories", id);

        txtId.Text = "";
        txtName.Text = "";
        await DisplayAlert("Delete", "Category deleted", "Ok");
    }    
}