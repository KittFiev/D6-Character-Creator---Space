using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6_Character_Creator___Space
{
    internal class TemplateToFields
    {

        public async Task CheckDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string templatesDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Templates";
            Console.WriteLine(Directory.GetParent(templatesDirectory));

        }

        public async Task WriteTemplateXML()
        {
            
            string workingDirectory = Environment.CurrentDirectory;
            string templatesDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/Templates";
            Console.WriteLine(Directory.GetParent(templatesDirectory));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Async = true;
            settings.Indent = true;
            //settings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(templatesDirectory + "/ExampleTemplate.xml", settings))
            {

                await writer.WriteStartElementAsync(null, "module", null);
                await writer.WriteAttributeStringAsync(null, "name", null, "Example Template");
                await writer.WriteAttributeStringAsync(null, "secondthing", null, "looks like this");
                    await writer.WriteStartElementAsync(null, "skills", null);
                    await writer.WriteAttributeStringAsync(null, "group", null, "strength");

                        await writer.WriteStartElementAsync(null, "skill", null);
                            await writer.WriteStringAsync("Punchy");
                        await writer.WriteEndElementAsync();

                    await writer.WriteEndElementAsync();

                await writer.WriteEndElementAsync();
                await writer.FlushAsync();
            }

        }

    }
}
