using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    /**
     * I need this as a placeHolder since I cannot create a GameObject since it is an abstract class. 
     * */
    class FakeGameObject:GameObject
    {
        /**
         * FakeGameObject Constructor
         * */
        public FakeGameObject()
            : base(GameObject.Name.FakeObject)
        {
         //   Debug.WriteLine("FakeGameObject Constructor Method was called.");
        }

        /**
         * FakeGameObject GetName Method
         * */
        override public Enum getName()
        {
       //     Debug.WriteLine("FakeGameObject GetName Method was called.");

            return null;
        }

        /**
         * FakeGameObject Accept Method
         * */
        public override void Accept(Visitor v)
        {
        //    Debug.WriteLine("FakeGameObject Accept Method was called.");

            return;
        }


        public override void Update()
        {
            
        }
    }
}
