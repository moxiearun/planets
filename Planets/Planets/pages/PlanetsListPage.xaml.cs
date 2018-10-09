using Planets.Api;
using Planets.cells;
using Planets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Planets.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlanetsListPage : ContentPage
	{
        ObservableCollection<Planet> PlanetsList;
        PlanetResponse PlanetResponse;

		public PlanetsListPage ()
		{
			InitializeComponent ();
            Setup();
		}

        private async void Setup()
        {
            PlanetResponse = await PlanetsApi.GetPlanestList(PlanetsApi.BASE_URL);
            PlanetsList = new ObservableCollection<Planet>(PlanetResponse.results);
            LoadingView.IsVisible = false;
            if (PlanetsList != null)
            {
                EmptyView.IsVisible = false;
                PlanetListView.IsVisible = true;
                PlanetListView.ItemTemplate = new DataTemplate(() => new PlanetItemCell());
                PlanetListView.ItemsSource = PlanetsList;
                PlanetListView.ItemSelected += OnPlanetSelected;
                PlanetListView.ItemAppearing += PlanetList_ItemAppearing;
            }
            else
            {
                EmptyView.IsVisible = true;
            }
        }

        private void OnPlanetSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PlanetListView.SelectedItem = null;
        }

        private async void PlanetList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (PlanetsList.Count == PlanetResponse.count)
            {
                PlanetListView.ItemAppearing += null;
                return;
            }
            var planet = e.Item as Planet;
            if (PlanetsList != null && PlanetsList.LastOrDefault() == planet)
            {
                PlanetListView.Footer = new ActivityIndicator() { IsVisible = true, IsRunning = true, Color = Color.Black };
                PlanetResponse = await PlanetsApi.GetPlanestList(PlanetResponse.next);
                PlanetListView.Footer = null;
                if (PlanetResponse.results != null && PlanetsList != null && PlanetsList.Count > 0)
                {
                    var list = PlanetResponse.results;
                    list.ForEach(product => PlanetsList.Add(product));
                }
            }
        }
    }
}