namespace MapsDemo.ViewModels
{
    using BruTile.Predefined;
    using Catel.MVVM;
    using Mapsui;
    using Mapsui.Geometries;
    using Mapsui.Layers;
    using Mapsui.Projection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {

        }

        public Map Map { get; set; }

        public Navigator Navigator { get; set; }

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
            layers.Add(new TileLayer(KnownTileSources.Create()));
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
