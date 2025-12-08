using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6_Character_Creator___Space
{
    public class TemplateToFields
    {

        public void CheckDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            Console.WriteLine(Directory.GetParent(workingDirectory).Parent.FullName);

        }

    }
}
