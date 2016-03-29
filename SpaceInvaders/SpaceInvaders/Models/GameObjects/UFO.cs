using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class UFO:GameObject
    {

        public UFO(int index = 0):base(GameObject.Name.Mothership, index)
        {
          
            
            //Debug.WriteLine("UFO Constructor Method was called.");
        }
        public override void Accept(Visitor v)
        {
            throw new NotImplementedException();
        }
    }
}
