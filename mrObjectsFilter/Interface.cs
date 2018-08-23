using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModPlusAPI.Interfaces;

namespace mrObjectsFilter
{
    public class Interface : IModPlusFunctionForRenga
    {
        public SupportedProduct SupportedProduct => SupportedProduct.Renga;

        public string Name => "";

        public RengaProduct RengaProduct => RengaProduct.Any;

        public string LName { get; }

        public string Description { get; }

        public string Author { get; }

        public string Price { get; }

        public string FullDescription { get; }

        public string ToolTipHelpImage { get; }
    }
}
