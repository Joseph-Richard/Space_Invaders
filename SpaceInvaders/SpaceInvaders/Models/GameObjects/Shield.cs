using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Shield:GameObject
    {
        public Shield(int index = 0)
            : base(GameObject.Name.Shield, index)
        {
        //    Debug.WriteLine("Shield Constructor Method was called.");
        }
        public override void Accept(Visitor v)
        {
            throw new NotImplementedException();
        }
    }
}
