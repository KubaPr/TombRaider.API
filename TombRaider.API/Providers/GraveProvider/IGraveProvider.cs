using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TombRaider.API.Core;

namespace TombRaider.API.Providers.GraveProvider
{
    public interface IGraveProvider
    {
        List<Grave> FindGraves(Grave template);
        Grave GetGraveById(int id);
    }
}
