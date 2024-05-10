using MauiAppApiConsumer.ControllerPage;
using MauiAppApiConsumer.Model;
using MauiAppUTN001.ApiConsumer;

namespace MauiAppApiConsumer
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private String url = "https://clase-cloud-api.azurewebsites.net";
        public MainPage()
        {
            InitializeComponent();
        }

        public void cmdNextPageCategory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Categoriesxaml());
        }

        private void cmdNextPageProduct_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Producto());
        }

        private void LoadCategories()
        {
            var categories = ApiConsumer<Category>.Read(url + "/api/Categories");
            lstItems.ItemsSource = categories;
            lblListado.Text = "Categorías";
        }

        private void LoadProducts()
        {
            var products = ApiConsumer<Product>.Read(url + "/api/Products");
            lstItems.ItemsSource = products;
            lblListado.Text = "Productos";
        }

        private void cmdVerCategorias_Clicked(object sender, EventArgs e)
        {
            LoadCategories();
            lblListado.Text = "Lista de Categorías";

        }

        private void cmdVerProdcutos_Clicked(object sender, EventArgs e)
        {
            LoadProducts();
            lblListado.Text = "Lista de Productos";

        }
    }

}
