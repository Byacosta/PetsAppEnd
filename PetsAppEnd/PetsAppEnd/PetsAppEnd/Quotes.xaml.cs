using Newtonsoft.Json;
using PetsAppEnd.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetsAppEnd
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Quotes : ContentPage
	{
        private const string UrlRoot = "https://petsend.herokuapp.com/";
        private const string UrlListQuotes = UrlRoot + "quotess";
        private const string UrlDeleteQuotes = UrlRoot + "quotess";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Quote> _quotes;

        public Quotes ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                ListDataQuotes();
            }
            else
            {
                showWindowHome();
            }
        }

        // Metodo para listar todos los contactos
        async public void ListDataQuotes()
        {
            string content = await client.GetStringAsync(UrlListQuotes);
            List<Quote> contacts = JsonConvert.DeserializeObject<List<Quote>>(content);
            _quotes = new ObservableCollection<Quote>(contacts);
            listViewQuotes.ItemsSource = _quotes;
        }

        public void ClickUpdateQuotes(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.BindingContext as Quote;

            Quote quote = new Quote()
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                Phone = item.Phone,
                Image = item.Image

            };

            ShowWindowUpdateQuotes(quote);
        }

        async public void ShowWindowUpdateQuotes(Quote quote)
        {
            await Navigation.PushModalAsync(new UpdateQuotes(quote));
        }

        public void ClickDeleteQuotes(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DeleteQuotes(mi.CommandParameter.ToString());
        }

        // Metodo para eliminar un contacto
        async public void DeleteQuotes(string position)
        {
            HttpResponseMessage response = null;
            response = await client.DeleteAsync(UrlDeleteQuotes + "/" + position);

            ListDataQuotes();
        }

        async public void ClickButtonShowWindowNewQuotes(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateQuotes());
        }

        public void ClickButtonSignOff(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            showWindowHome();
        }

        async public void showWindowHome()
        {
            await Navigation.PushModalAsync(new Home());
        }

    }
}