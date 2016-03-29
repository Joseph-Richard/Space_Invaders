using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ImageHolder:sLink
    {
        /**
         * Fields
         * */
        public Image image;

        /**
         * ImageHolder Constructor
         * */
        public ImageHolder(Image i):base()
        {
            Debug.WriteLine("ImageHolder Constructor Method was called.");
            this.image = i;
            this.pNext = null;
        }
    }
}
