using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GlyphManager:Manager
    {
        private static GlyphManager instance;
        private Glyph refNode; 
        private GlyphManager(int reserveNum, int growthRate)
            : base(reserveNum, growthRate)
        {
            this.refNode = (Glyph)this.CreateNode();
        }

        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new GlyphManager(reserveNum, growthRate);
            }
        }

        public static Glyph Add(int key, Glyph.FontStyle fstyle, Texture.Name tName, float x, float y, float width, float height)
        {
            GlyphManager gm = GlyphManager.GetInstance();
            Glyph glyph = (Glyph)gm.baseAdd();
            Debug.Assert(glyph != null);

            glyph.Set(key, fstyle, tName, x, y, width, height);
            return glyph;
            
        }

        public static void createGlyphsFromXML(Glyph.FontStyle fstyle, String fileName, Texture.Name tName)
        {
            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            XmlTextReader reader = new XmlTextReader(fileName);
            while (reader.Read())
            {

                switch (reader.NodeType){
                    case XmlNodeType.Element:
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "character")
                        {
                            GlyphManager.Add(key, fstyle, tName, x, y, width, height);
                        }
                        break;
                }

            }
        }

        /**
            * GlyphManager Compare Function
        * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
            //  Debug.WriteLine("SpriteManager Compare Method was called.");
            Debug.Assert(pNodeA != null && pNodeB != null);
            Glyph pGlyphA = (Glyph)pNodeA;
            Glyph pGlyphB = (Glyph)pNodeB;
            Boolean status = false;
            if ((pGlyphA.key == pGlyphB.key)&&(pGlyphA.fontStyle == pGlyphB.fontStyle))
            {
                status = true;
            }
            return status;
        }
        public static Glyph Find(int key, Glyph.FontStyle fstyle)
        {
            GlyphManager gm = GlyphManager.GetInstance();
            gm.refNode.key = key;
            gm.refNode.fontStyle = fstyle;
            Glyph result = (Glyph)gm.baseFind(gm.refNode);
            Debug.Assert(result != null);
            return result;
        }

        protected override DLink CreateNode()
        {
            DLink link = new Glyph();
            return link;
        }

        public static GlyphManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
