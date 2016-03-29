using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class TimerEvent:DLink
    {
        /**
         * Fields
         * */
        public TimerEvent.Name name;
        public float triggerTime;
        public float deltaTime;
        public Command command;
        public enum Name { Uninitialized, 
                            SpriteAnimation, 
                            GridAnimation, 
                            BombDrop, 
                            CreateMothership,
                            DeleteMothershipScore,  
                            DeleteAlienExplosion, 
                            DeleteUserExplosion,
                            UpdateEnter, 
                            Other }
        /**
         * TimerEvent Constructor
         * */
        public TimerEvent():base()
        {
         //   Debug.WriteLine("TimerEvent Constructor Method was called.");
            this.name = TimerEvent.Name.Uninitialized;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
            this.command = null;
        }

        /**
         * TimerEvent Process Method
         * */
        public void process()
        {
        //    Debug.WriteLine("TimerEvent Process Method was called.");
            Debug.Assert(this.command != null);
            this.command.Execute(this.deltaTime);
        }

        /**
         * TimerEvent Set Method
         * */
        public void Set(TimerEvent.Name name, float dTime, Command command)
        {
        //    Debug.WriteLine("TimerEvent Set Method was called.");
            Debug.Assert(dTime >= 0);
            this.name = name;
            this.deltaTime = dTime;
            this.triggerTime = TimerManager.getTime()+this.deltaTime;
            this.command = command;
        //    Console.WriteLine(name + "is being added to the timerManager with a trigger time =" + this.triggerTime);
        }
    }
}
