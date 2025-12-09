using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace D6_Character_Creator___Space
{
    internal class XMLModule
    {

        public void XReader()
        {
            XmlTextReader reader = null;

            string workingDirectory = Environment.CurrentDirectory;
            string templatesDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/Templates";
            //Console.WriteLine(Directory.GetParent(templatesDirectory));

            try
            {

                reader = new XmlTextReader(templatesDirectory + "/D6-Skills.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(reader);

                XmlNodeList xnList = xDoc.SelectNodes("/module/skills/group");

                for (int i = 0; i < xnList.Count; i++)
                {
                    var attr = xnList[i].Attributes["name"];
                    if (attr != null)
                    {

                        Console.WriteLine("Skill Group: " + attr.Value);
                        XmlNodeList znList = xnList[i].SelectNodes("skill");
                        for (int y = 0; y < znList.Count; y++)
                        {

                            Console.WriteLine(znList[y].InnerText);

                        }

                    }

                }

                while ( reader.MoveToNextAttribute() || reader.Read())
                {
                    

                    /*switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.Write("<{0}>", reader.Name);
                            //Console.Write(reader.GetAttribute("group"));
                            break;
                        case XmlNodeType.Attribute:
                            Console.WriteLine("<{0}={1}>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Text:
                            Console.Write(reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            Console.WriteLine("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            Console.WriteLine("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.WriteLine("<!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            Console.WriteLine("<?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            break;
                        case XmlNodeType.DocumentType:
                            Console.WriteLine("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            Console.WriteLine(reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            Console.WriteLine("</{0}>", reader.Name);
                            break;
                    }*/
                }
            }

            finally
            {

                if (reader!=null)
                {

                    reader.Close();

                }

            }

        }

    }
}
