using Newtonsoft.Json;
using PetsAppEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetsAppEnd
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateQuotes : ContentPage
	{
        private const string UrlRoot = "https://petsend.herokuapp.com/";
        private const string UrlCreateQuotes = UrlRoot + "quotess";
        private readonly HttpClient client = new HttpClient();

        public CreateQuotes ()
		{
			InitializeComponent ();
		}

        public void ClickButtonCreateQuotes(object sender, EventArgs e)
        {
            CreateNewQuotes();
        }

        async public void CreateNewQuotes()
        {
            Quote quote = new Quote()
            {
                Name = entryNameCc.Text,
                Address = entryAddressCc.Text,
                Phone = entryPhoneCc.Text
                                
            };

            var json = JsonConvert.SerializeObject(quote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlCreateQuotes, content);
            string message = await response.Content.ReadAsStringAsync();

            await Navigation.PushModalAsync(new Quotes());
        }

    }
}