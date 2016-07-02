using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Utils
{
    public class Position
    {
        private int debthCoo;
        private int widthCoo;

        public Position(int widthCoo, int debthCoo)
        {
            this.widthCoo = widthCoo;
            this.debthCoo = debthCoo;
        }

        public int getDebthCoo()
        {
            return this.debthCoo;
        }

        public void setDebthCoo(int newDebthCoo)
        {
            this.debthCoo = newDebthCoo;
        }

        public int getWidthCoo()
        {
            return this.widthCoo;
        }

        public void setWidthCoo(int newWidthCoo)
        {
            this.widthCoo = newWidthCoo;
        }
    }
}
