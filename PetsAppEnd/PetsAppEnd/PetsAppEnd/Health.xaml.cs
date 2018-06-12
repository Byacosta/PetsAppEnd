using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetsAppEnd
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Health : ContentPage
	{
		public Health ()
		{
			InitializeComponent ();
		}

        async private void nextQuote()
        {
            await Navigation.PushAsync(new Quotes());
        }

        async private void NextVaccinations()
        {
            await Navigation.PushAsync(new Vaccinations());
        }

        async private void NextPerfil()
        {
            await Navigation.PushAsync(new Profile());
        }

        async private void NextHome()
        {
            await Navigation.PushAsync(new Home());
        }


        async private void NextSalir()
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}