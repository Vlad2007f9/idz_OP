using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idz_OP
{
    public class Slimit
    {
        private static readonly int MaxS = 3;
        private static List<Slimit> instances = new List<Slimit>();
        private static int count = 0;
        private Slimit() { }
        public static Slimit GetInstances()
        {
            if (instances.Count < MaxS)
            {
                Slimit newS = new Slimit();
                instances.Add(newS);
                return newS;
            }
            Slimit inst = instances[count % MaxS];
            count++;

            return inst;
        }
    }
}
