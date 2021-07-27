using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadPasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int len = Convert.ToInt32(txtNumOfChars.Text);

            StringBuilder sbPass = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                sbPass.Append(SeedRandom());
            }

            txtPassword.Text = sbPass.ToString();
        }

        private string SeedRandom()
        {
            int asciiLow = 33;
            int asciiHigh = 126;

            int guidhash = (Guid.NewGuid().GetHashCode());

            DateTime dt = DateTime.Now;

            string dtticks = dt.Ticks.ToString();

            int smallticksLength = dtticks.Length;

            char[] ticksArray = new char[smallticksLength];

            ticksArray = dtticks.ToCharArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < smallticksLength; i++)
            {

                if (i >= (smallticksLength / 2))
                    sb.Append(ticksArray[i].ToString());

            }


            int smallticks = Convert.ToInt32(sb.ToString());
            int seed =  guidhash + smallticks;

            Random randObj = new Random(seed);

            int randout = randObj.Next(asciiLow, asciiHigh);
            char c = Convert.ToChar(randout);

            string passChar = c.ToString();
            return passChar;

        }

        private void txtNumOfChars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
