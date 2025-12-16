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
    public partial class SRD_Advantage_Format : UserControl
    {
        public SRD_Advantage_Format()
        {
            InitializeComponent();
        }

        public string AdvName(string skl_Name)
        {

            return Adv_Name_Label.Text = skl_Name;
            
        }

        public string AdvDescription(string skl_Description)
        {

            return Adv_Description_Label.Text = skl_Description;

        }

        public string AdvCost(string skl_Cost)
        {

            return Adv_Cost_Label.Text = skl_Cost;

        }
        public string AdvSource(string skl_Source)
        {

            return Module_Source_Label.Text = skl_Source;

        }

        public string AdvRestrictions(string adv_Restrict)
        {


            return Adv_Restrictions_Field.Text = adv_Restrict;
        }

    }
}
