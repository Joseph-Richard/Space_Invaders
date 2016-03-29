using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AlienFactory
    {
        /**
         * Fields
         * */
        private SpriteBatch spriteBatch;
        private PCSTree tree;
        private GameObject currentParent;
        private Alien reference;

        /**
         * AlienFactory Constructor
         * */
        public AlienFactory(PCSTree tree,SpriteBatch.Name name)
        {
         //   Debug.WriteLine("AlienFactory Constructor was called.");
            this.spriteBatch = (SpriteBatch)SpriteBatchManager.Find(name);
            this.tree = tree;
            this.reference = null;
        }

        /**
         * AlienFactory Create Method
         * */
        public Alien Create(Alien.Type type, float x=0, float y=0, int index=0)
        {
            this.reference = null;
        //    Debug.WriteLine("AlienFactory Create Method was called.");
            switch(type){
                case Alien.Type.Column:
                    this.reference = new Column(x, y, index);
                    break;
                case Alien.Type.Squid:
                    this.reference = new Squid(x, y, index);
                    
                    break;
                case Alien.Type.Crab:
                    this.reference = new Crab(x, y, index);
                    
                    break;
                case Alien.Type.Octo:
                    this.reference = new Octo(x, y, index);
                    
                    break;
                case Alien.Type.Grid:
                    this.reference = new Grid(x, y, index);
                    GameObjectManager.Attach(this.reference, this.tree);

                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(this.reference != null);
            //this.reference.Update();
            
            this.tree.Insert(this.reference, this.currentParent);

            this.reference.attachSprite(this.spriteBatch);
            //if(this.reference.name != GameObject.Name.Grid)
            SpriteBatch box = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
            if (this.reference.name != GameObject.Name.Column)
            {
                this.reference.attachCollisionBox(box);
            }
            else
            {
                
                this.reference.attachCollisionBox(this.spriteBatch);
            }
            return this.reference;
        }

        /**
         * AlienFactory setParentNode Method
         * */
        public void setParentNode(GameObject parent)
        {
        //    Debug.WriteLine("AlienFactory setParentNode Method was called.");
            this.currentParent = parent;
        }
    }
}
