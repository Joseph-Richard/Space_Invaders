using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ForwardIterator: Iterator
    {
        private GameObject root;
        private GameObject current;

        public ForwardIterator(GameObject root)
        {
            this.root = root;
            this.current = this.root;

            TreeIterator.Calculate(root);
        }

        public override PCSNode First()
        {
            this.current = this.root;
            return this.current;
        }

        public override PCSNode Next()
        {
            this.current = (GameObject)this.current.Forward;
            return this.current;
        }

        public override bool isDone()
        {
            return (this.current == null);
        }

        public override PCSNode CurrentItem()
        {
            return this.current;
        }
    }
}
