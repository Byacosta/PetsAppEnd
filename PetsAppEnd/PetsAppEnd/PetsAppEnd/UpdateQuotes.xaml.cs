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
	public partial class UpdateQuotes : ContentPage
	{

        private const string UrlRoot = "https://petsend.herokuapp.com/";
        private const string UrlUpdateQuotes = UrlRoot + "quotess";
        private readonly HttpClient client = new HttpClient();
        private Quote quote;

        public UpdateQuotes(Quote quote)
        {
			InitializeComponent ();
            this.quote = quote;
            BindingContext = quote;
        }

        async public void ClickButtonUpdateQuotes(object sender, EventArgs e)
        {
            quote.Name = entryNameUc.Text;
            quote.Address = entryAddressUc.Text;
            quote.Phone = entryPhoneUc.Text;


            var json = JsonConvert.SerializeObject(quote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(UrlUpdateQuotes + "/" + quote.Id, content);

            await Navigation.PushModalAsync(new Quotes());
        }



    }
}