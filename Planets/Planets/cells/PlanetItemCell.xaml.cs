using Planets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Planets.cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanetItemCell : ViewCell
    {
        public Planet PlanetItem { set; get; }

        public PlanetItemCell()
        {
            InitializeComponent();
            BindingContext = PlanetItem;
        }
    }
}