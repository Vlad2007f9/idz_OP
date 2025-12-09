using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idz_OP
{
    public sealed class Slazy
    {
        private static readonly Lazy<Slazy> lazy = new Lazy<Slazy>(() => new Slazy());
        public static Slazy GetInstance
        {
            get { return lazy.Value; }
        }
        private Slazy() { }

    }
}
