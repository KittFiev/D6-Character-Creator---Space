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

        List<NumericUpDown> DiceValueList;
        List<NumericUpDown> PipValueList;
        List<NumericUpDown> AttributeValueList;
        public MainFormContainer()
        {
            InitializeComponent();
            //CreateButtonDelegate();

            DiceValueList = new List<NumericUpDown>();
            PipValueList = new List<NumericUpDown>();
            AttributeValueList = new List<NumericUpDown>();

            for (int z = 0; z < Skill_Table_Columns.ColumnCount; z++)
            {

                TableLayoutPanel sk_Columns = (TableLayoutPanel)Skill_Table_Columns.GetControlFromPosition(z, 0);

                for (int i = 0; i < sk_Columns.RowCount; i++)
                {

                    TableLayoutPanel sk_Table = (TableLayoutPanel)sk_Columns.GetControlFromPosition(0, i);

                    for (int y = 0; y < sk_Table.RowCount; y++)
                    {
                        NumericUpDown sk_DiceCounter = (NumericUpDown)sk_Table.GetControlFromPosition(0, y);
                        sk_DiceCounter.ValueChanged += SkillDiceValueChange;

                        if (y == 0)
                        {

                            AttributeValueList.Add(sk_DiceCounter);

                        }else
                            DiceValueList.Add(sk_DiceCounter);

                        NumericUpDown sk_PipCounter = (NumericUpDown)sk_Table.GetControlFromPosition(1, y);
                        sk_PipCounter.ValueChanged += SkillDiceValueChange;
                        PipValueList.Add(sk_PipCounter);

                    }

                }

            }
        }

        private void SkillDiceValueChange(object sender, EventArgs e)
        {

            float totalDiceValue = 0;
            float totalPipValue = 0;

            foreach (NumericUpDown nud in AttributeValueList)
            {
                //bit dirty, but does the job. Due to unclear description in the rulebook, we're assuming the
                //first point of all attributes is given for free as each attribute requires a minimum of 1
                //Metaphysics is the exception due to starting at 0, which is why we need to subtract the min
                //and clamp the other attributes using a Max function.
                totalDiceValue += Math.Max( ((int)nud.Value - (int)nud.Minimum) * 4, 0 );

            }

            foreach (NumericUpDown nud in DiceValueList)
            {

                totalDiceValue += (int)nud.Value;

            }

            foreach (NumericUpDown nud in PipValueList)
            {

                totalPipValue += (int)nud.Value;

            }

            totalDiceValue += totalPipValue / 3;

            UsedPointsTotal.Text = totalDiceValue.ToString();

        }

        private void CreateButtonDelegate()
        {

            XMLModule xRead = new XMLModule();

            List<List<string>> t1_List = xRead.XReader();
            Console.WriteLine(t1_List[0][1]);

            int pos = 41;

            for (int i = 0; i < t1_List.Count; i++)
            {

                for (int y = 0; y < t1_List[i].Count; y++)
                {
                    
                    Label nLabel = new Label();
                    NumericUpDown skillDice = new NumericUpDown();
                    NumericUpDown pipDice = new NumericUpDown();

                    nLabel.Text = t1_List[i][y];
                    nLabel.Name = "nLabel" + pos;

                    skillDice.Name = "skillDice" + pos;
                    skillDice.Size = new Size(47,20);
                    pipDice.Size = new Size(47, 20);
                    pipDice.Name = "pipDice" + pos;

                    if (y==0)
                    {

                        nLabel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);

                    }

                    skillDice.Location = new Point(0, pos);
                    pipDice.Location = new Point(skillDice.Location.X + skillDice.Size.Width + 3, pos);
                    nLabel.Location = new Point(pipDice.Location.X + pipDice.Size.Width + 3, pos);

                    pos += skillDice.Size.Height + 3;

                    /*this.tabPage4.Controls.Add(skillDice);
                    this.tabPage4.Controls.Add(pipDice);
                    this.tabPage4.Controls.Add(nLabel);*/

                    //var test = this.Controls.Find("char_Sheet", true);

                    //test[0].Controls.Add(nLabel);

                }

                Label lineBreak = new Label();

                lineBreak.Text = "";
                lineBreak.Size = new Size(250, 2);
                lineBreak.Location = new Point(0, pos + 10);
                lineBreak.BorderStyle = BorderStyle.Fixed3D;

                pos += 25;

                //this.tabPage4.Controls.Add(lineBreak);

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
            XMLModule layoutRead = new XMLModule();

            layoutRead.LayoutBuilder();

        }

        private OpenFileDialog openFileDialog;

        private void UploadCharPFP_Click(object sender, EventArgs e)
        {

            openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "PNG Files (*.png)|*.png",
                Title = "Open text file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = new Bitmap(openFileDialog.FileName);

            }

        }
    }
}
