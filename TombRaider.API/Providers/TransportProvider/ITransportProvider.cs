using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TombRaider.API.Core;

namespace TombRaider.API.Providers.TransportProvider
{
    public interface ITransportProvider
    {
        List<MapPoint> FindLocations(string type, Coordinates startPoint);      
    }
}
