using Newtonsoft.Json;
using PetsAppEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetsAppEnd
{
	public partial class MainPage : ContentPage
	{

        private const string UrlRoot = "https://petsend.herokuapp.com/";
        private const string UrlValidarUser = UrlRoot + "validateUser";
        private readonly HttpClient client = new HttpClient();

        public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                ShowWindowListContacts();
            }
        }

        async private void ClickButtonSignIn(object sender, EventArgs e)
        {
            User user = new User() { Login = entryUser.Text, Password = entryPass.Text };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlValidarUser, content);
            string message = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(message);

            if (users[0].Success)
            {
                Application.Current.Properties["id_user"] = users[0].Id;
                ShowWindowListContacts();
            }
            else
            {
                await DisplayAlert("Error", "The User not Exist", "OK");
            }
        }

        async private void ClickButtonCreateUser(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateUser());
        }

        async private void ShowWindowListContacts()
        {
            await Navigation.PushModalAsync(new Home());
        }

    }
}
