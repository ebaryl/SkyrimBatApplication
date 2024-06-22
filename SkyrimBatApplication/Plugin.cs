using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyrimBatApplication
{
    public class Plugin
    {
        public string Name { get; set; } = string.Empty;
        public int LoadOrder { get; set; }
        public bool IsLight { get; set; }
        public string Index { get; set; } = string.Empty;// => IsLight ? LoadOrder.ToString("X3") : LoadOrder.ToString("X2");
    }
}
