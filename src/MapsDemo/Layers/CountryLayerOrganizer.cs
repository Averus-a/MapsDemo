namespace MapsDemo.Layers
{
    using Mapsui.Geometries;
    using Mapsui.Layers;
    using Mapsui.Providers;
    using Mapsui.Styles;
    using Mapsui.Styles.Thematics;

    public class CountryLayerOrganizer : ILayerOrganizer
    {
        public ILayer CreateLayer(IProvider dataSourceProvider)
        {
            return new Layer()
            {
                Name = "Countries",
                DataSource = dataSourceProvider,
                Style = CreateLayerStyle(),
                IsMapInfoLayer = true,
                Opacity = 0.5
            };
        }

        public ThemeStyle CreateLayerStyle()
        {
            return new ThemeStyle(
                feature =>
                {
                    if (feature.Geometry is Point)
                    {
                        return null;
                    }

                    return CreateVectorStyle(feature);
                }
            );
        }

        private VectorStyle CreateVectorStyle(IFeature feature)
        {
            var style = new VectorStyle();

            switch (feature["NAME"].ToString().ToLower())
            {
                case "brazil": //If country name is Denmark, fill it with green
                    style.Fill = new Brush(Color.Green);
                    style.Outline = new Pen(Color.Black);
                    break;
                case "united states": //If country name is USA, fill it with Blue and add a red outline
                    style.Fill = new Brush(Color.Violet);
                    style.Outline = new Pen(Color.Black);
                    break;
                case "china": //If country name is China, fill it with red
                    style.Fill = new Brush(Color.Orange);
                    style.Outline = new Pen(Color.Black);
                    break;
                case "japan": //If country name is China, fill it with red
                    style.Fill = new Brush(Color.Cyan);
                    style.Outline = new Pen(Color.Black);
                    break;
                default:
                    style.Fill = new Brush(Color.Gray);
                    style.Outline = new Pen(Color.FromArgb(0, 64, 64, 64));
                    break;
            }

            return style;
        }
    }
}
