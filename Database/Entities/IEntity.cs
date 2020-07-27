using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    interface IEntity
    {
        Dictionary<string, string> getTrasformationMap();
    }
}
