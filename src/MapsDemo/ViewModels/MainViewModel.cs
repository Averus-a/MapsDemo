namespace MapsDemo.ViewModels
{
    using BruTile.Predefined;
    using Catel.MVVM;
    using MapsDemo.Helpers;
    using MapsDemo.Layers;
    using Mapsui;
    using Mapsui.Desktop.Shapefile;
    using Mapsui.Geometries;
    using Mapsui.Layers;
    using Mapsui.Projection;
    using Mapsui.Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MainViewModel : ViewModelBase
    {
        private readonly ILayerOrganizer _countryLayerOrganizer = new CountryLayerOrganizer();

        private IProvider _countryShape;

        public MainViewModel()
        {

        }

        public Map Map { get; set; }

        public Navigator Navigator { get; set; }

        protected async override Task InitializeAsync()
        {
            _countryShape = new ShapeFile(PathHelper.GetAppDir() + "\\GeoData\\World\\countries.shp", true) 
            { 
                CRS = "EPSG:3785" 
            };
        }

        private void OnMapChanged()
        {
            var map = Map;
            InitializeMap(map);
        }

        private void OnNavigatorChanged()
        {
            var navigator = Navigator;
            var map = Map;
            FocusOnLocation(map, navigator);
        }

        private void InitializeMap(Map map)
        {
            var layers = map.Layers;
            //layers.Add(_countryLayerOrganizer.CreateLayer(_countryShape));
            var osmLayer = new TileLayer(KnownTileSources.Create());
            layers.Add(osmLayer);
        }

        private void FocusOnLocation(Map map, Navigator navigator)
        {
            var center = NotableCoordinates.Volgograd;
            //convert to spherical mercator coordinates
            var osmCoordinates = SphericalMercator.FromLonLat(center.X, center.Y);
            var mapResolutions = map.Resolutions;

            navigator.NavigateTo(osmCoordinates, mapResolutions[12]);
        }
    }
}
