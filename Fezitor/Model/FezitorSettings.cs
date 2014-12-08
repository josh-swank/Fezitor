using Fezitor.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Model
{
    [ModelStructureAttribute("Settings")]
    class FezitorSettings : IModelStructure
    {
        [AppSetting("GameDirectory", "Game Directory")]
        public string GameDirectory { get; set; }
    }
}
