using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D6_Character_Creator___Space
{
    public partial class MainFormContainer : Form
    {
        public MainFormContainer()
        {
            InitializeComponent();
            //this.Shown += CreateButtonDelegate;
            CreateButtonDelegate();

        }

        private void CreateButtonDelegate()
        {

            for (int i = 0; i < 5; i++)
            {

                Button newButton = new Button();
                
                newButton.Text = "fuck you buttons" + (i+1);
                newButton.Name = "nButton" + i;
                
                newButton.Size = new Size(50, 80);

                newButton.Location = new Point(0, newButton.Size.Height*i);

                this.tabPage6.Controls.Add(newButton);

            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckDirectoryBttn_Click(object sender, EventArgs e)
        {
            TemplateToFields TTF = new TemplateToFields();
            TTF.WriteTemplateXML();

            ButtonConstruct newButton = new ButtonConstruct();
            newButton.CreateDynamicButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XMLModule xRead = new XMLModule();

            xRead.XReader();
        }
    }
}
