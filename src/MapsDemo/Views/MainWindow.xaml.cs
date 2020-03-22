namespace MapsDemo.Views
{
    using BruTile.Predefined;
    using Catel.MVVM.Views;
    using Catel.Windows;
    using Mapsui;
    using Mapsui.Layers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
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
        private static readonly Timer _updateTimer = new Timer(5000);

        static MainWindow()
        {
            typeof(MainWindow).AutoDetectViewPropertiesToSubscribe();
        }

        public MainWindow()
        {
            /* Different maps support, KnowTileSources.Create() use KnowTileSource.OpenStreetMap by default
            var mapsource = KnownTileSource.BingAerial;
            mapsource = KnownTileSource.EsriWorldPhysical;
            mapsource = KnownTileSource.OpenStreetMap;
            mapsource = KnownTileSource.StamenTerrain;
            */
            _updateTimer.Elapsed += _updateTimer_Elapsed;
            InitializeComponent();
        }

        protected override void Initialize()
        {
            SetValue(MapProperty, MainMap.Map);
            SetValue(NavigatorProperty, MainMap.Navigator);
            base.Initialize();
        }

        [ViewToViewModel(nameof(Map), MappingType = ViewToViewModelMappingType.ViewToViewModel)]
        public Map Map
        {
            get { return (Map)GetValue(MapProperty); }
            set { SetValue(MapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Map.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapProperty =
            DependencyProperty.Register("Map", typeof(Map), typeof(MainWindow), new PropertyMetadata(default(Map), (s,e) => (s as MainWindow).OnMapPropertyChanged(s, e)));

        private void OnMapPropertyChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            _updateTimer.Start();
        }

        [ViewToViewModel(nameof(Navigator), MappingType = ViewToViewModelMappingType.ViewToViewModel)]
        public Navigator Navigator
        {
            get { return (Navigator)GetValue(NavigatorProperty); }
            set { SetValue(NavigatorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Navigator.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigatorProperty =
            DependencyProperty.Register("Navigator", typeof(Navigator), typeof(MainWindow), new PropertyMetadata(default(Navigator)));


        private void _updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _updateTimer.Stop();
        }
    }
}
