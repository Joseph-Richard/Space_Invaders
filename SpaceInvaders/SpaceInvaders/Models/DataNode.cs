using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DataNode
    {
        /**
         * Fields
         * */
        private String name;
        private int x;

        /**
         * DataNode Constructor
         * */
        public DataNode(String n, int val)
        {
         //   Debug.WriteLine("DataNode Constructor Method was called.");
            this.name = n;
            this.x = val;
        }

        /**
         * DataNode Dump Method
         * */
        public void Dump(DataNode dNode)
        {
         //   Debug.WriteLine("DataNode Dump Method was called.");
            return;
        }

        /**
         * DataNode Set Method
         * */
        public void set(String name, int val)
        {
         //   Debug.WriteLine("DataNode Set Method was called.");
            this.name = name;
            this.x = val;
        }
    }
}
