using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        private SpriteBatch spriteBatch;
        private PCSTree tree;
        private GameObject currentParent;
        private ShieldType reference;
        public ShieldFactory(PCSTree tree, SpriteBatch.Name name)
        {
            this.tree = tree;
            this.spriteBatch = SpriteBatchManager.Find(name);
            this.reference = null;
            this.currentParent = null;
        }
        public void setParent(GameObject parent)
        {
            this.currentParent = parent;
        }

        public ShieldType Create(ShieldType.Type type, GameObject.Name name,  float x = 0, float y = 0, int index = 0)
        {
            this.reference = null;
            switch(type){
                case ShieldType.Type.ShieldBrick:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldBrick,x, y, index);
                    break;
                case ShieldType.Type.ShieldBottomLeftEmpty:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldBottomLeftEmpty, x, y, index);
                    break;
                case ShieldType.Type.ShieldBottomRightEmpty:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldBottomRightEmpty, x, y, index);
                    break;
                case ShieldType.Type.ShieldTopLeftEmptyLarge:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldTopLeftEmptyLarge, x, y, index);
                    break;
                case ShieldType.Type.ShieldTopLeftEmptySmall:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldTopLeftEmptySmall, x, y, index);
                    break;
                case ShieldType.Type.ShieldTopRightEmptyLarge:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldTopRightEmptyLarge, x, y, index);
                    break;
                case ShieldType.Type.ShieldTopRightEmptySmall:
                    this.reference = new ShieldBrick(type, name, Sprite.Name.ShieldTopRightEmptySmall, x, y, index);
                    break;
                case ShieldType.Type.ShieldRoot:
                    this.reference = new ShieldRoot(x, y, index);
                    break;
                case ShieldType.Type.ShieldColumn:
                    this.reference = new ShieldColumn(type, name, x, y, index);
                    break;
                default:
                    break;
            }

            Debug.Assert(this.reference != null);
            this.tree.Insert(this.reference, this.currentParent);
            this.reference.attachSprite(this.spriteBatch);
            this.reference.attachCollisionBox(SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes));
            return this.reference;
        }
    }
}
