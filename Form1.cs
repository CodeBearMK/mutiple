using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mutiple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCheck.Enabled = false;
            btnClear.Enabled = false;
            lblMsg.Text = "請按<出題>鈕開始";
            clstTest.CheckOnClick = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clstTest.Items.Clear();
            int num;
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                num = rnd.Next(1, 100);
                while (clstTest.Items.Contains(num))
                {
                    num = rnd.Next(1, 5);
                }
                clstTest.Items.Add(num);

            }
            lblMsg.Text = "請開始做答";
            btnNew.Enabled = false;
            btnCheck.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int right = 0;
            for (int i = 0; i < clstTest.Items.Count; i++)
            {
                if (int.Parse(clstTest.Items[i].ToString()) % 3 == 0)
                {
                    if (clstTest.GetItemChecked(i))
                    {
                        right++;
                    }
                }
                else
                {
                    if (!clstTest.GetItemChecked(i))
                    {
                        right++;
                    }
                }
            }
            lblMsg.Text = "答對 " + right.ToString() + " 題";
            btnNew.Enabled = true;
            btnCheck.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnCheck.Enabled = true;
            for (int i = 0; i < clstTest.Items.Count; i++)
            {
                clstTest.SetItemChecked(i, false);
            }
            lblMsg.Text = "請重新作答";
        }
    }
}
