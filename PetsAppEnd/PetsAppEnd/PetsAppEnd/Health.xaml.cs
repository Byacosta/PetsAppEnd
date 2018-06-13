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
            await Navigation.PushModalAsync(new Quotes());
        }

        async private void NextVaccinations()
        {
            await Navigation.PushModalAsync(new Vaccinations());
        }

        async private void NextPerfil()
        {
            await Navigation.PushModalAsync(new Profile());
        }

        async private void NextHome()
        {
            await Navigation.PushModalAsync(new Home());
        }


        async private void NextSalir()
        {
            await Navigation.PushModalAsync(new MainPage());
        }

    }
}