using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ProxySpriteManager:Manager
    {


        private static ProxySpriteManager pInstance;
        
        /**
         * ProxySpriteManager Constructor Method
         * */
        private ProxySpriteManager(int reservedSize = 3, int growthRate = 2)
            : base(reservedSize, growthRate)
        {
        //    Debug.WriteLine("ProxySpriteManager Constructor 1 was called.");

        }

        /**
         * ProxySpriteManager Create Method
         * */
        public static void Create(int reservedSize=3, int growthRate=2)
        {
        //    Debug.WriteLine("ProxySpriteManager Create Method was called.");
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new ProxySpriteManager(reservedSize, growthRate);
            }
        }

        /**
         * ProxySpriteManager Add Method
         * */
        public static ProxySprite Add(Sprite.Name name)
        {
        //    Debug.WriteLine("ProxySpriteManager Add Method was called.");
            ProxySpriteManager psm = ProxySpriteManager.getInstance();
            Debug.Assert(psm != null);
            ProxySprite proxySprite = (ProxySprite)psm.baseAdd();
            Debug.Assert(proxySprite != null);

            proxySprite.set(name);
            return proxySprite;
        }

        public static void Remove(ProxySprite sprite)
        {
            Debug.Assert(sprite != null);
            ProxySpriteManager psm = ProxySpriteManager.getInstance();
            psm.baseRemove(sprite);
        }

        /**
         * ProxySpriteManager CreateNode Method
         * */
        protected override DLink CreateNode()
        {

         //   Debug.WriteLine("ProxySpriteManager CreateNode Method was called.");
            DLink proxySprite = new ProxySprite();
            return proxySprite;
        }

        /**
         * ProxySpriteManager Compare Method
         * */
        protected override bool Compare(DLink pLinkA, DLink pLinkB)
        {
        //    Debug.WriteLine("ProxySpriteManager Compare Method was called.");
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            ProxySprite psA = (ProxySprite)pLinkA;
            ProxySprite psB = (ProxySprite)pLinkB;

            bool status = false;
            if (psA.getName() == psB.getName())
            {
                status = true;
            }
            return status;
        }

        /**
         * ProxySpriteManager getInstance Method
         * */
        public static ProxySpriteManager getInstance(){
         //   Debug.WriteLine("ProxySpriteManager getInstance Method was called.");
            Debug.Assert(pInstance != null);
            return pInstance;
        }

    }
}
