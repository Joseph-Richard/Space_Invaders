using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class Visitor:PCSNode
    {
        public virtual void visitAlien(Alien v){
           Console.WriteLine("Visitor.visitAlien() not implemented.");
        }

        public virtual void visitBomb(Bomb b)
        {
            Console.WriteLine("Visitor.visitBomb() not implemented.");
        }

        public virtual void visitBombRoot(BombRoot b)
        {
            Console.WriteLine("Visitor.visitBombRoot() not implemented.");
        }

        public virtual void visitColumn(Column c)
        {
            Console.WriteLine("Visitor.visitColumn() not implemented.");
        }

        public virtual void visitDagger(Dagger d)
        {
            Console.WriteLine("Visitor.visitDagger() not implemented.");
        }

        public virtual void visitGrid(Grid g)
        {
            Console.WriteLine("Visitor.visitGrid() not implemented");
        }

        public virtual void visitMothership(Mothership m)
        {
            Console.WriteLine("Visitor.visitMothership() not implemented.");
        }

        public virtual void visitMothershipRoot(MothershipRoot m)
        {
            Console.WriteLine("Visitor.visitMothershipRoot() not implemented.");
        }

        public virtual void visitMissile(Missile m)
        {
            Console.WriteLine("Visitor.visitMissile() not implemented.");
        }

        public virtual void visitMissileRoot(MissileRoot m)
        {
            Console.WriteLine("Visitor.visitMissileRoot() not implemented.");
        }


        public virtual void visitShieldBrick(ShieldBrick s)
        {
            Console.WriteLine("Visitor.visitShieldBrick() not implemented.");
        }

        public virtual void visitShieldColumn(ShieldColumn s)
        {
            Console.WriteLine("Visitor.visitShieldColumn() not implemented.");
        }
        public virtual void visitShieldRoot(ShieldRoot s)
        {
            Console.WriteLine("Visitor.visitShieldRoot() not implemented.");
        }

        public virtual void visitShip(Ship s)
        {
            Console.WriteLine("Visitor.visitShip() not implmented.");
        }

        public virtual void visitShipRoot(ShipRoot sr)
        {
            Console.WriteLine("Visitor.visitShipRoot() not implemented.");
        }

        public virtual void visitUFO(UFO u)
        {
            Console.WriteLine("Visitor.visitUFO() not implemented.");
        }

        public virtual void visitBottomWall(BottomWall w)
        {
            Console.WriteLine("Visitor.visitBottomWall() not implemented.");
        }

        public virtual void visitLeftWall(LeftWall w)
        {
            Console.WriteLine("Visitor.visitLeftWall() not implemented.");
        }

        public virtual void visitRightWall(RightWall w)
        {
            Console.WriteLine("Visitor.visitRightWall() not implemented.");
        }

        public virtual void visitTopWall(TopWall w)
        {
            Console.WriteLine("Visitor.visitTopWall() not implemented.");
        }

        public virtual void visitWallRoot(WallRoot wr)
        {
            Console.WriteLine("Visitor.visitWallRoot() not implemented.");
        }

        public virtual void visitZigZag(ZigZag z)
        {
            Console.WriteLine("Visitor.visitZigZag() not implemented.");
        }

        abstract public void Accept(Visitor v);
    }
}
