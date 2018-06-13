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
	public partial class Home : ContentPage
	{
        public Home()
        {
            InitializeComponent();
        }

        async private void NextRecomendaciones()
        {
            await Navigation.PushModalAsync(new Recommendations());
        }

        async private void NextSalud()
        {
            await Navigation.PushModalAsync(new Health());
        }

        async private void NextPerfil()
        {
            await Navigation.PushModalAsync(new Profile());
        }

        async private void NextHome()
        {
            await Navigation.PushModalAsync(new Home());
        }

        async private void NextRaces()
        {
            await Navigation.PushModalAsync(new Races());
        }

        async private void NextSalir()
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}