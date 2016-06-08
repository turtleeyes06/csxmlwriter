using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Xml;

namespace XmlWriterProject
{
    class Program
    {        
        static void Main(string[] args)
        {
            XmlWrite();
        }

        public static void XmlWrite()
        {
            ArrayList objectList;
            objectList = new ArrayList();

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\ncarroll\\Desktop\\LevelListTemplate.xml");
            XmlElement item, objectType, objectName, posX, posY;

            objectList.Add(new GameObject("k"));
            objectList.Add(new GameObject("qs"));
            objectList.Add(new GameObject("h"));
            objectList.Add(new GameObject("lh"));
            objectList.Add(new GameObject("sh"));
            objectList.Add(new GameObject("c2"));
            objectList.Add(new GameObject("b3"));
            objectList.Add(new GameObject("b1"));
            objectList.Add(new GameObject("k"));
            objectList.Add(new GameObject("g"));
            objectList.Add(new GameObject("k"));
            objectList.Add(new GameObject("b2"));
            objectList.Add(new GameObject("k"));
            objectList.Add(new GameObject("qs"));
            objectList.Add(new GameObject("h"));
            objectList.Add(new GameObject("lh"));
            objectList.Add(new GameObject("sh"));
            objectList.Add(new GameObject("c2"));
            objectList.Add(new GameObject("b3"));
            objectList.Add(new MoreSpecificObj("b2"));

            GameObject currentObj;
            for(int i = 0; i < objectList.Count; i++)
            {
                currentObj = (GameObject)objectList[i];
                currentObj.setXY(10 * i, 4 * i);
            }

            //make loop here to add items


            foreach(GameObject gameObj in objectList)
            {
                item = doc.CreateElement("Item");

                objectType = doc.CreateElement("ObjectType");
                objectType.InnerText = gameObj.getType();

                objectName = doc.CreateElement("ObjectName");
                objectName.InnerText = gameObj.getName();

                posX = doc.CreateElement("XPosition");
                posX.InnerText = gameObj.getX().ToString();

                posY = doc.CreateElement("YPosition");
                posY.InnerText = gameObj.getY().ToString();

                item.AppendChild(objectType);
                item.AppendChild(objectName);
                item.AppendChild(posX);
                item.AppendChild(posY);

                doc.DocumentElement.AppendChild(item);
            }            
            

            //end loop


            doc.Save("C:\\Users\\ncarroll\\Desktop\\DemoLevel.xml");
            
        }

        class GameObject
        {
            private string objName, objType;
            private int xpos = 0, ypos = 0;

            public GameObject(string type)
            {
                switch (type)
                {
                    //enemies
                    case "k":
                        objName = "Koopa";
                        objType = "Enemy";
                        break;
                    case "g":
                        objName = "Goomba";
                        objType = "Enemy";
                        break;
                        //clouds
                    case "c1":
                        objName = "Cloud1";
                        objType = "Background";
                        break;
                    case "c2":
                        objName = "Cloud2";
                        objType = "Background";
                        break;
                    case "c3":
                        objName = "Cloud3";
                        objType = "Background";
                        break;
                        //bushes
                    case "b1":
                        objName = "Bush1";
                        objType = "Background";
                        break;
                    case "b2":
                        objName = "Bush2";
                        objType = "Background";
                        break;
                    case "b3":
                        objName = "Bush3";
                        objType = "Background";
                        break;
                        //hills
                    case "lh":
                        objName = "LargeHill";
                        objType = "Background";
                        break;
                    case "sh":
                        objName = "SmallHill";
                        objType = "Background";
                        break;
                        //blocks
                    case "qc":
                        objName = "QuestionBlockCoin";
                        objType = "Block";
                        break;
                    case "qm":
                        objName = "QuestionBlockMushroom";
                        objType = "Block";
                        break;
                    case "qs":
                        objName = "QuestionBlockStar";
                        objType = "Block";
                        break;
                    case "h":
                        objName = "HiddenBlock";
                        objType = "Block";
                        break;
                }
            }
            public void setXY(int x, int y)
            {
                xpos = x;
                ypos = y;
            }
            public int getX()
            {
                return xpos;
            }
            public int getY()
            {
                return ypos;
            }
            public string getType()
            {
                return objType;
            }
            public string getName()
            {
                return objName;
            }
        }
        class MoreSpecificObj : GameObject
        {
            public MoreSpecificObj(string type) : base(type)
            {
            }
        }
    }
}
