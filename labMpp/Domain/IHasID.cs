using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public interface IHasID<ID>
    {
        ID Id { get; set; }
    }
}
