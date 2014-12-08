using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Interface.Model
{
    public interface IModel<S>
    {
        S AppSettings { get; set; }
    }
}
