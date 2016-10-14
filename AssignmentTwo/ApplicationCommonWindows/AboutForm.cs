using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Createed by ben dunn, 2016 october 10
/// student ID 100098171
/// 
/// simple about form to replace the text message box, I did this to test
/// calling another form from anther form with a constructor to see 
/// what would happen when I changed the constructor within forms.
/// 
/// ideally, would chain them in the future, but for this case it was 
/// pretty damn good at what it did as it proved that you can have
/// multiple references of the same form. (but different instances)
/// wanted to see what this could be used for.
/// </summary>
namespace AssignmentTwo.ApplicationCommonWindows
{
    public partial class AboutForm : Form
    {
        public AboutForm(String descMessage)
        {
            InitializeComponent();
            this.AboutRichTextBox.Text = descMessage;
        }




        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }
    }
}
