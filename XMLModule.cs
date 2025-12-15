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
        List<List<string>> t_Items;
        List<List<string>> layout_Nodes;

        //this is my first time returning anything from a method in a separate class
        //don't judge me ;3;
        public List<List<string>> XReader()
        {
            XmlTextReader reader = null;

            string workingDirectory = Environment.CurrentDirectory;
            string templatesDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/Templates";
            //Console.WriteLine(Directory.GetParent(templatesDirectory));

            t_Items = new List<List<string>>();

            try
            {

                reader = new XmlTextReader(templatesDirectory + "/D6-Skills.xml"); //replace this with a document selector
                reader.WhitespaceHandling = WhitespaceHandling.None;

                
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(reader);

                XmlNodeList xnList = xDoc.SelectNodes("/module/skills/group");

                for (int i = 0; i < xnList.Count; i++)
                {
                    var attr = xnList[i].Attributes["name"];
                    List<string> tempList = new List<string>();

                    if (attr != null)
                    {
                        
                        tempList.Add(attr.Value);

                        //Console.WriteLine("Skill Group: " + attr.Value);
                        XmlNodeList znList = xnList[i].SelectNodes("skill");
                        for (int y = 0; y < znList.Count; y++)
                        {

                            tempList.Add(znList[y].InnerText);

                        }

                        t_Items.Add(tempList);

                    }
                }
            }

            finally
            {

                if (reader!=null)
                {

                    reader.Close();

                }

            }

            return t_Items;
        }

        public void LayoutBuilder()
        {

            XmlTextReader layoutReader = null;

            string workingDirectory = Environment.CurrentDirectory;
            string templatesDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/Layout";

            layout_Nodes = new List<List<string>>();



            //looks like I'll need to use this Read() to actually get the list of all elements
            //then I'll need to use a loaded version of the xml to search for elements by name???
            //because for whatever reason, loading the document BEFORE getting the list
            //prevents the reader from actually writing anywhere other than to the Load()

            //initialize like this
            //nodeLayout[] test = new nodeLayout[5];
            //test[0].NodeName = "5";

            try 
            {

                layoutReader = new XmlTextReader(templatesDirectory + "/D6Space-LayoutPrototype.xml"); //replace this with a document selector
                layoutReader.WhitespaceHandling = WhitespaceHandling.None;

                while (layoutReader.Read())
                {
                    XmlNodeType nType = layoutReader.NodeType;
                    if (nType == XmlNodeType.Element)
                    {
                        //send this data to a list of custom class of NodeName, Parent, and List<string>. These go in NodeName
                        Console.WriteLine(layoutReader.Name.ToString());

                    }

                }

                layoutReader = new XmlTextReader(templatesDirectory + "/D6Space-LayoutPrototype.xml"); //reinitialize the reader because you can't read and load at the same time. Thanks microsoft.

                XmlDocument yDoc = new XmlDocument();
                yDoc.Load(layoutReader);
                //Iterate through the list and get each node. Fill in Parent for each one, then fill in List<string> with the settings info
                XmlNodeList selectedNode = yDoc.SelectNodes("//char_Sheet_Tabs");

                Console.WriteLine(selectedNode.Count);
                if (selectedNode.Count > 0)
                {

                    Console.WriteLine(selectedNode[0].Name.ToString());

                }

                //List<string> nodeAttrList = new List<string>();
                for (int i = 0; i < selectedNode[0].Attributes.Count; i++)
                {

                    Console.WriteLine(selectedNode[0].Attributes[i].Value);

                }
                


            }
            finally
            {

                if (layoutReader!=null)
                {

                    layoutReader.Close();

                }

            }

            //return layout_Nodes;

        }
    }

    internal class nodeLayout
    {

        internal string NodeName;
        internal string ParentNode;
        //internal string[] NodeSettings = new string[3];
        internal List<string> NodeSettings = new List<string>();

    }
}
