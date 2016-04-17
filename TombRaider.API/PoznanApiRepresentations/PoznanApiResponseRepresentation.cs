using System.Collections.Generic;

namespace TombRaider.API.PoznanApiRepresentations
{
    public class PoznanApiResponseRepresentation
    {
        public PoznanApiResponseRepresentation()
        {
            Features = new List<Feature>();
        }

        public List<Feature> Features;
    }
}
