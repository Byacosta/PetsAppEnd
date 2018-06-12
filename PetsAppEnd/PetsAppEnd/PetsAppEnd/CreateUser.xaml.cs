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
	public partial class CreateUser : ContentPage
	{
        private const string UrlRoot = "https://petsend.herokuapp.com/";
        private const string UrlCreateUser = UrlRoot + "createUser";
        private readonly HttpClient client = new HttpClient();


        public CreateUser()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                ShowWindowHome();
            }
        }

        public void CreateUsers(object sender, EventArgs e)
        {
            CreateAccount();
        }

        async public void CreateAccount()
        {
            if (String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(lastname.Text) ||
                String.IsNullOrEmpty(noid.Text) ||
                String.IsNullOrEmpty(login.Text) || String.IsNullOrEmpty(password.Text) ||
                String.IsNullOrEmpty(address.Text) ||
                String.IsNullOrEmpty(email.Text) || String.IsNullOrEmpty(sex.SelectedItem.ToString()))
            {

                await DisplayAlert("Error", "Complet Of Formlation", "OK");
            }
            else
            {

                //   crear objeto del modelo tarea
                User user = new User()
                {
                    Name = name.Text,
                    LastName = lastname.Text,
                    NoId = noid.Text,
                    Login = login.Text,
                    Password = password.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Sex = sex.SelectedItem.ToString()
                };

                var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlCreateUser, content);
            string message = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(message);

            Application.Current.Properties["id_user"] = users[0].Id;

            await Navigation.PushModalAsync(new Home());
            }
        }

        async private void ShowWindowHome()
        {
            await Navigation.PushModalAsync(new Home());
        }

    }
}