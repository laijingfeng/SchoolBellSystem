using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolBellSystem
{
    public partial class AddBell : Form
    {
        /// <summary>
        /// 要修改的ID
        /// </summary>
        public int modifyID = -1;

        public AddBell()
        {
            InitializeComponent();
        }

        private void AddBell_Load(object sender, EventArgs e)
        {
            if (modifyID == -1)
            {
                this.Text = "增加铃声";
            }
            else
            {
                this.Text = "修改铃声";
            }
        }
    }
}
