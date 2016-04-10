using System.Collections.Generic;

namespace TombRaider.API.PoznanApiRepresentations
{
    public class PoznanApiGravesRepresentation
    {
        public PoznanApiGravesRepresentation()
        {
            Features = new List<Feature>();
        }

        public List<Feature> Features;
    }
}