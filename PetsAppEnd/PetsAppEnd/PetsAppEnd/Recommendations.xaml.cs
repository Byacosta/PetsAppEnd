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
	public partial class Recommendations : ContentPage
	{
		public Recommendations ()
		{
			InitializeComponent ();
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