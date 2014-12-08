using Fezitor.Interface.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Model
{
    public class FezitorModel<S> : IModel<S>
    {
        public S AppSettings { get; set; }
    }
}
