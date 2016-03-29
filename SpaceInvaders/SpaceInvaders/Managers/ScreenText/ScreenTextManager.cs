using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ScreenTextManager:Manager
    {
        private static ScreenTextManager instance;
        private ScreenText refNode;

        private ScreenTextManager(int reserveNum, int growthRate)
            : base(reserveNum, growthRate)
        {
            refNode = (ScreenText)this.CreateNode();
        }

        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new ScreenTextManager(reserveNum, growthRate);
            }
        }

        public static ScreenText Add(ScreenText.Name name, SpriteBatch.Name sbName, String newText, Glyph.FontStyle fstyle, float x, float y)
        {
            Debug.Assert(newText != null);
            Debug.Assert(newText.Length > 0);

            ScreenTextManager stm = ScreenTextManager.GetInstance();
            ScreenText stext = (ScreenText)stm.baseAdd();

            stext.Set(name, newText, fstyle, x, y);
            SpriteBatch sb = SpriteBatchManager.Find(sbName);
            sb.Attach(stext.spriteFont);

            return stext;
        }

        public static ScreenText AddToSelectScreen(ScreenText.Name name, String newText, Glyph.FontStyle fstyle, float x, float y)
        {
            Debug.Assert(newText != null);
            Debug.Assert(newText.Length > 0);

            ScreenTextManager stm = ScreenTextManager.GetInstance();
            ScreenText stext = (ScreenText)stm.baseAdd();

            stext.Set(name, newText, fstyle, x, y);
            SpriteBatch sb = SpriteBatchManager.Find(SpriteBatch.Name.SelectScreenText);
            sb.Attach(stext.spriteFont);

            return stext;
        }

        public static ScreenText AddToGameScreen(ScreenText.Name name, String newText, Glyph.FontStyle fstyle, float x, float y)
        {
            Debug.Assert(newText != null);
            Debug.Assert(newText.Length > 0);

            ScreenTextManager stm = ScreenTextManager.GetInstance();
            ScreenText stext = (ScreenText)stm.baseAdd();

            stext.Set(name, newText, fstyle, x, y);
            SpriteBatch sb = SpriteBatchManager.Find(SpriteBatch.Name.GameScreenText);
            sb.Attach(stext.spriteFont);

            return stext;
        }

        public static ScreenText AddToGameOverScreen(ScreenText.Name name, String newText, Glyph.FontStyle fstyle, float x, float y)
        {
            Debug.Assert(newText != null);
            Debug.Assert(newText.Length > 0);

            ScreenTextManager stm = ScreenTextManager.GetInstance();
            ScreenText stext = (ScreenText)stm.baseAdd();

            stext.Set(name, newText, fstyle, x, y);
            SpriteBatch sb = SpriteBatchManager.Find(SpriteBatch.Name.GameOverScreenText);
            sb.Attach(stext.spriteFont);

            return stext;
        }


        public static ScreenText Find(ScreenText.Name name)
        {
            ScreenTextManager stm = ScreenTextManager.GetInstance();
            stm.refNode.name = name;
            ScreenText sText = (ScreenText)stm.baseFind(stm.refNode);
            Debug.Assert(sText != null);
            return sText;
        }

        protected override bool Compare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);
            ScreenText sTextA = (ScreenText)pLinkA;
            ScreenText sTextB = (ScreenText)pLinkB;
            Boolean status = false;
            if (sTextA.name == sTextB.name)
            {
                status = true;
            }
            return status;

        }

        public static void createGlyphsFromXml(Glyph.FontStyle fstyle, String fileName, Texture.Name tName)
        {
            GlyphManager.createGlyphsFromXML(fstyle, fileName, tName);
        }




        protected override DLink CreateNode()
        {
            DLink link = new ScreenText();
            return link;
        }



        public static ScreenTextManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

    }
}
