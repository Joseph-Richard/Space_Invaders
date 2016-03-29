using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class BackwardIterator:Iterator
    {
        public GameObject root;
        public GameObject current;
        public GameObject previous;

        public BackwardIterator(GameObject root)
        {
            this.root = root;
            this.current = this.root;

            TreeIterator.Calculate(root);
        }

        public override PCSNode First()
        {
            this.current = (GameObject)this.root.Reverse;
            this.previous = this.current;
            return this.current;
        }

        public override PCSNode Next()
        {
            this.previous = this.current;
            this.current = (GameObject)this.current.Reverse;
            return this.current;
        }

        public override bool isDone()
        {
            return ((this.current == this.root.Reverse) && (this.previous == this.root));
        }
        public override PCSNode CurrentItem()
        {
            return this.current;
        }

    }
}
