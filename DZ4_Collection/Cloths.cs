using System;
using System.Collections.Generic;
using System.Text;

namespace DZ4_Collection
{
    class Cloths
    {
        public string type;
        public int size;
        public Cloths(string type, int size)
        {
            this.size = size;
            this.type = type;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", type, size);
        }
    }
}
