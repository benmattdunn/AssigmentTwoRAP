using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentTwo
{
    /// <summary>
    /// partial class for the the sharp auto center app, contains all the 
    /// values for actions and methods for central control. Does not contain
    /// validation as that is done by an external static class.
    /// </summary>
    public partial class SharpAutoCenter : Form
    {
        

        public SharpAutoCenter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// closes the program gracefully by disposing all components. 
        /// </summary>
        private void _appExit()
        {
            this.Dispose();
            Application.Exit();
        }


        /// <summary>
        /// calls the close function
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._appExit();   
        }
    }
}
