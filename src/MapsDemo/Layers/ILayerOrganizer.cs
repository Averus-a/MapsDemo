using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Styles.Thematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsDemo.Layers
{
    public interface ILayerOrganizer
    {
        ILayer CreateLayer(IProvider dataSourceProvider);
        ThemeStyle CreateLayerStyle();
    }
}
