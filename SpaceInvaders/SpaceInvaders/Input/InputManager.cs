using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class InputManager
    {
        public static InputManager instance;
        private InKey leftArrow;
        private InKey rightArrow;
        private InKey SpaceBar;
        private InKey EnterKey;
        private InKey toggleKey;
        private Boolean handled;
        private Boolean EnterButtonPressedBefore;
        private Boolean EnterPressed;
        private Boolean TogglePressed;
        private Boolean ToggleButtonPressedBefore;
        /**
         * InputManager Constructor (private)
         * */
        private InputManager()
        {
            leftArrow = new InKey();
            rightArrow = new InKey();
            SpaceBar = new InKey();
            EnterKey = new InKey();
            toggleKey = new InKey();
            handled = false;
            EnterButtonPressedBefore = false;
            EnterPressed = false;

            ToggleButtonPressedBefore = false;
            TogglePressed = false;
        }

        /**
         * InputManager Create Method
         * */
        public static void Create()
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new InputManager();
            }
        }

        //Get Keys
        //--------------------------------------------------------
        public static InKey getSpace()
        {
            InputManager im = InputManager.getInstance();
            return im.SpaceBar;
        }
        public static InKey getLeftA()
        {
            InputManager im = InputManager.getInstance();
            return im.leftArrow;
        }
        public static InKey getRightA()
        {
            InputManager im = InputManager.getInstance();
            return im.rightArrow;
        }
        public static InKey getEnterKey()
        {
            InputManager im = InputManager.getInstance();
            return im.EnterKey;
        }

        public static InKey getToggleKey()
        {
            InputManager im = InputManager.getInstance();
            return im.toggleKey;
        }
        //-------------------------------------------------------------


        public static void Update()
        {
            InputManager im = InputManager.getInstance();
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                im.leftArrow.Notify();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                im.rightArrow.Notify();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE) == true)
            {
                im.SpaceBar.Notify();
            }
            im.EnterPressed = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_F5);
            if (im.EnterPressed == true && im.EnterButtonPressedBefore == false)
            {
                    im.EnterKey.Notify();
            }
            im.EnterButtonPressedBefore = im.EnterPressed;

            im.TogglePressed = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T);
            if (im.TogglePressed == true && im.ToggleButtonPressedBefore == false)
            {
                im.toggleKey.Notify();
            }
            im.ToggleButtonPressedBefore = im.TogglePressed;
        }

        /**
         * InputManager getInstance Mehtod
         * */
        public static InputManager getInstance()
        {
            return instance;
        }

        public static void HandleEnter()
        {
            InputManager im = InputManager.getInstance();
            im.handled = true;
        }

        public static void ResetHandled()
        {
            InputManager im = InputManager.getInstance();
            im.handled = false;
        }

        public static Boolean isHandled()
        {
            InputManager im = InputManager.getInstance();
            return im.handled;
        }
    }
}
