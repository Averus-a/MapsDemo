namespace MapsDemo.Views
{
    using BruTile.Predefined;
    using Catel.Windows;
    using Mapsui.Layers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DataWindow
    {
        public MainWindow()
        {
            /* Different maps support, KnowTileSources.Create() use KnowTileSource.OpenStreetMap by default
            var mapsource = KnownTileSource.BingAerial;
            mapsource = KnownTileSource.EsriWorldPhysical;
            mapsource = KnownTileSource.OpenStreetMap;
            mapsource = KnownTileSource.StamenTerrain;
            */

            InitializeComponent();
            MainMap.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));
        }
    }
}
