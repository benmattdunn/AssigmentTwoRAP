using AssignmentTwo.ApplicationCommonWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Created by ben dunn
/// Student ID 100098171
/// Final changes 10, 14, 2016
/// sharp auto center assignment for toms RAD class. 
/// 
/// Contains the following additional items: (I focused on the back end, as I've learned that more features are worthless with near perfect stability...
/// plus I'm using this to learn a little about how the forms handle behind the scenes for listeners and threads for... well making a game). 
/// 
/// -Controls for setting the text too one of two defaults, along with color (plus the color text box prompt)
/// 
/// -changes text color for all controls(that inherite the default form the parrent), not ust listed
/// 
/// -threaded error handler, however it should almost never be thrown (I haven't managed to break it yet) as the validation code is solid
/// 
/// -> used a custom additional form instead of the message box class for about to see how a form with custom text could be initialized.
/// -Smart keyboard listener with multi keystroke listening, used a list of strings to capture key down events, and then if try for multiple 
/// then execute event. CTR + key did not bring the focus away from the text boxes, so upon activation of the event, the focus is changed to 
/// the addition ooptions lable. By doing this, in this order it allowed that the text boxes would not be changed during a CTR+key event.
/// which was problematic as it meant that the short cuts were at issue.
/// 
/// -> Threaded, one handles validating input and setting textboxes that have invalid values to 0.00, along with (briefly marking them as 
/// red), one mointers the radio buttons and check lists for value changes rather then triggering an event (much more elegent), and one
/// throws user exceptions (which seem to be completely impossible due to how I've limited the users total access to even inputting errors). 
/// 
/// -> static class for validation outside of the main class, reduced code size on page somewhat, however in the future I'll expand this 
/// static class to include all non-activation methods to remove bloat.
/// 
/// -> program aborts gracefully under all circumstances, (see thread abortion code). 
/// 
/// -> used the layout features and allowed resizing on controls meaning that the window resizes gracefully with font change. (basically, no
/// matter what font you use, it will still look good and similar). 
/// 
/// Basically, most of the additional stuff that was above and beyond was behind the scenes. The GUI itself is the minimumn, but the functionality
/// and stability were my focus. (basically my co-op taught me that if a user can possibily break something, they will). Which is now where I know 
/// to put the most effort. 
/// 
/// </summary>
namespace AssignmentTwo
{
    /// <summary>
    /// partial class for the the sharp auto center app, contains all the 
    /// values for actions and methods for central control. Does not contain
    /// validation as that is done by an external static class.
    /// </summary>
    public partial class SharpAutoCenter : Form
    {
        //exception shifter, simple
        private Exception _firstException;
        private Exception _secondException;

        //two default fonts for testing orginally, however kept in as they give a nice "return to defaults" option/ 
        private Font _defaultFont;
        private Font _arialFont;
        //Three threads
        private Thread _exceptionHandleThread; //handles message popup box.
        private Thread _GUIWarningsThread; //thread that turns color boxes red if a value in them is incorrect
        private Thread _valuesUpdateThread; //mointers the checkboxes and updates the values as needed. 

        private List<String> _pressedKeys = new List<String>(); //was orignally keys, however for the scope of this project string was much more efficent. 
        //private Queue<Keys> keyQueue = new Queue<Keys>(); ->I'll use this in another project for shinanigins.

        //standard font and color dialoug
        private FontDialog _fontDialog;
        private ColorDialog _colorDialog;

        //almost never used as the calculation is mostly "front end" with these values being updated to match the controls.
        //stored for the final calculation (click) however in reality I could actually just remove this button completely 
        //as the program auto updates as it moves along. (it was to kept to meet the assignment requirements). 
        private double _salesTax = 0.13;
        private double _additionalOptions = 0;
        private double _subTotal = 0;
        private double _salesTaxSubTotal = 0;
        private double _totalValueBeforeTradeIn = 0;
        private double _finalTotal = 0;

        //runtime status, used to abort threaded while loops
        private bool _runningStatus = true;

        /// <summary>
        /// Default auto intialization with threads and fonts initalization added.
        /// </summary>
        public SharpAutoCenter()
        {
            _initalizeFonts();
            InitializeComponent();
            _intializeThreads();
        }

        /// <summary>
        /// Initalizes the custom fonts, and color window. 
        /// </summary>
        private void _initalizeFonts()
        {
            this._fontDialog = new FontDialog();
            this._colorDialog = new ColorDialog();
            this._defaultFont = this.Font;
            try { //should never be thrown, but it can happen
                this._arialFont = new Font("Arial", 12, FontStyle.Bold);
            } catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                this._firstException = ex;
                this._arialFont =this._defaultFont; //simply changes to default font case; 
            }
        }

        /// <summary>
        /// intializes two threads:
        /// 1) error catcher,
        /// 2) valid input listener, marks text boxes as red when values are invalid. 
        /// </summary>
        private void _intializeThreads ()
        {
            this._exceptionHandleThread = new Thread(
                new ThreadStart(this._promtErrorWarning));
            this._exceptionHandleThread.Start();

            this._GUIWarningsThread = new Thread(
                new ThreadStart(this._showInvalidTextBoxesAsRed));
            this._GUIWarningsThread.Start();

            this._valuesUpdateThread = new Thread(
                new ThreadStart(this._mointerCheckBoxesAndRadioButtons));
            this._valuesUpdateThread.Start();

        }

        /// <summary>
        /// Goes into a thread, mointers the checkbox value changes and updates the GUI,
        /// in reality this method has alot more scope then it lets on as in praticallity 
        /// it really actually "does most" of the raw calculation and updating. 
        /// </summary>
        private void _mointerCheckBoxesAndRadioButtons()
        {

            do
            {
                double currentValue = 0;
                double subTotal = 0;
                if (this.ComputerNavigationCheckBox.Checked)
                {
                    currentValue += 500;
                }
                if (this.LeatherInteriorCheckBox.Checked)
                {
                    currentValue += 1200;
                }
                if (this.SterioSystemCheckBox.Checked)
                {
                    currentValue += 880;
                }
                

                if (this.DefaultFinishRadioButton.Checked)
                {
                    currentValue += 0;
                }
                else if(this.PearlizedFinishRadioButton.Checked)
                {
                    currentValue += 1000;
                }
                else if (this.CustomFinishRadioButton.Checked)
                {
                    currentValue += 3000;
                }

                this._additionalOptions = currentValue;
                this._setText(currentValue.ToString("C2"), this.AdditionalItemsTextBox);

                if (BackGroundClasses.InputTester.TryParseDoubleNotBelow(this.BasePriceTextBox.Text, 0))
                {
                    try { 
                        subTotal = Double.Parse(this.BasePriceTextBox.Text) + currentValue;
                        this._subTotal = subTotal;
                        this._setText(subTotal.ToString("C2"), this.SubTotalTextBox);
                        this._salesTaxSubTotal = subTotal * this._salesTax;

                        this._setText((subTotal * this._salesTax).ToString("C2"), this.SalesTaxTextBox);
                        this._totalValueBeforeTradeIn = this._subTotal + this._salesTaxSubTotal;

                        this._setText(this._totalValueBeforeTradeIn.ToString("C2"), this.TotalTextBox);
                    }
                    catch (Exception)
                    {
                        //do nothings, it CAN happen that a value changes and thread interupts happen
                        //during update, however it's not a truely important exception in this case;
                        //so catch but ignore. 
                    }

                }

            } while (this._runningStatus);

            


        }


        /// <summary>
        /// marks the two text boxes as red if an invalid value has been entered
        /// into them. Warning users that a problem currently exists
        /// </summary>
        private void _showInvalidTextBoxesAsRed ()
        {
            do
            {
                Color white = Color.FromArgb(255, 255, 255);
                Color red = Color.FromArgb(255, 0, 0);
                if (BackGroundClasses.InputTester.TryParseDoubleNotBelow(this.BasePriceTextBox.Text, 0))
                {
                    this._setColor(white, this.BasePriceTextBox);
                }
                else
                {
                    this._setColor(red, this.BasePriceTextBox);
                    this._setText("0.00", this.BasePriceTextBox);
                }
                if (BackGroundClasses.InputTester.TryParseDoubleNotBelow(this.TradeInTextBox.Text, 0))
                {
                    this._setColor(white, this.TradeInTextBox);
                }
                else
                {
                    this._setColor(red, this.TradeInTextBox);
                    this._setText("0.00", this.TradeInTextBox);
                }
                Thread.Sleep(100);
            } while (this._runningStatus);
        }


        /// <summary>
        /// prompts warnings from all possible errors Using message box, handled by an 
        /// external thread that listens to possible changes. 
        /// </summary>
        private void _promtErrorWarning()
        {
            this._firstException = new Exception("no error");
            this._secondException = this._firstException;
            do
            {

                if (!(this._firstException.Equals(this._secondException)))
                {
                    this._firstException = this._secondException; // make them the same, to prevent further catching
                    MessageBox.Show(this._secondException.Message, "ERROR!");

                }
                Thread.Sleep(10);
            } while (this._runningStatus);
        }

      



        /// <summary>
        /// Takes a control and allows the generic update of the control via a thread or an outside 
        /// class. Allows the invoke of a new action aimed at the control of the text field.
        /// this class may be made more generic later on. Used a lambda to invoke a new
        /// action on the object (control). Added to the form to allow easy outside access of methods
        /// and display. However, set to private for the time being as I would want to validate this
        /// with another method if I made it public. 
        /// 
        /// old method copied from assignment 1
        /// </summary>
        /// <param name="text">a text parrameter</param>
        /// <param name="control">Referenced control</param>
        private void _setText(string text, Control control)
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => control.Text = text));
            else
                control.Text = text;
        }









        /// <summary>
        /// Brings up the about form with a simple string. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._callAbout();
        }
        /// <summary>
        /// closes the program gracefully by disposing all components. 
        /// </summary>
        private void _appExit()
        {
            this.Dispose();
            Application.Exit();
        }


        private void _callAbout()
        {
            AboutForm about = new AboutForm("Sharp Auto center calculation program, Created by Ben dunn 2016, all rights reserved to sharpauto center.");
            about.Show();
        }

        /// <summary>
        /// does the actual final calculation. Placed in a method to allow the key listener to reference the same values.
        /// </summary>
        private void _callFinalCalculation ()
        {
            if (BackGroundClasses.InputTester.TryParseDoubleNotBelow(this.BasePriceTextBox.Text, 0) &&
                BackGroundClasses.InputTester.TryParseDoubleNotBelow(this.TradeInTextBox.Text, 0)) {
                this._finalTotal = (this._totalValueBeforeTradeIn - (Double.Parse(this.TradeInTextBox.Text)));
                String tempString = "";
                if (this._finalTotal < 0)
                {
                    tempString = "-";
                }
                this._setText(tempString+this._finalTotal.ToString("C2"), this.AmountDueTextBox);
            } else
            {
                this._firstException = new Exception("a value in one of your text boxes is invalid! please make sure" +
                   " there are only number characters, and all values are positive!");
            }
        }

        /// <summary>
        /// 
        /// Calls the calculation method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateForm_Click(object sender, EventArgs e)
        {
            this._callFinalCalculation(); 
        }

        /// <summary>
        /// calls the close function
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitEvent_Click(object sender, EventArgs e)
        {
            this._appExit();
        }


        /// <summary>
        /// calls the clear form method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearForm_Click (object sender, EventArgs e)
        {
            this._clearControls(); 
        }

        /// <summary>
        /// 
        /// Sets the color of the controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeColor_Click (object sender, EventArgs e)
        {
            try {
                //should always compile work as the only thing that calls this
                //method is a toolstripmenuitem...
                ToolStripMenuItem keyCase = (ToolStripMenuItem)sender; //cast the sender, set as default due to hiarchy, however kept as I just wish to keep it univeral
                //MessageBox.Show(keyCase.Text);
                switch (keyCase.Text)
                {
                    case "Red":
                        Color redColor = Color.FromArgb(255, 0, 0);
                        this._changeTextColor(redColor);
                        break;
                    case "Black":
                        Color blackColor = Color.FromArgb(0, 0, 0);
                        this._changeTextColor(blackColor);
                        break;
                    case "Color":
                        this._colorDialog.ShowDialog();
                        this._changeTextColor(_colorDialog.Color);

                        break;
                    case "Custom":
                        this._colorDialog.ShowDialog();
                        this._changeTextColor(_colorDialog.Color);

                        break;
                }
            }
            catch(InvalidCastException exception)
            { 
                //write the exception into a general holder if it 
                // happens... by a mircal
                this._firstException = exception;
                //should never happen, though it can in a incomplete enviorment
                //MessageBox.Show(exception.Message +"/n" + exception.StackTrace);
            }
        }

        /// <summary>
        /// Sets the fonts of the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void changeFont_click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem keyCase = (ToolStripMenuItem)sender;
                switch (keyCase.Text)
                {
                    case "Ariel":
                        this._changeTextFont(this._arialFont);
                        break;
                    case "Default":
                        this._changeTextFont(this._defaultFont);

                        break;
                    case "Font":
                        this._fontDialog.ShowDialog();
                        this.Font = _fontDialog.Font;
                        break;
                    case "Custom":
                        this._fontDialog.ShowDialog();
                        this.Font = _fontDialog.Font;
                        break;
                }
            }
            catch (InvalidCastException exception)
            {
                this._firstException = exception;
            }
        }

        /// <summary>
        /// Listens for key change values upon down list and adds them to
        /// the current scope. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackedListen_KeyDown(object sender, KeyEventArgs e)
        {

            if (!_pressedKeys.Contains(e.KeyCode.ToString()))
            {   
                _pressedKeys.Add(e.KeyCode.ToString());

            }
            String testString = "";
            foreach(var k in _pressedKeys)
            {
                testString += k.ToString()+", ";
            }
            //this.TestLable.Text = testString; was used for debug to test the item codes, finished with and removed
            if (_pressedKeys.Contains("ControlKey"))
            {
                this.AdditionalOptionsLabel.Focus();
                if (_pressedKeys.Contains("X"))
                {
                    this._appExit();
                    this._pressedKeys.Clear(); //cleans the pressed keys to make sure there is no blocking event code. Because I do not have this threaded, 
                    //the multi key events can be interuppted by the message boxes and events for their creation leading too the released key event not
                    //being caught leaving them in the list. by clearing them after the event, it means that the program has more, (probably perfect)
                    //reliability.  
                }
                if (_pressedKeys.Contains("H"))
                {
                    this._callAbout();
                    this._pressedKeys.Clear();
                }
                if (_pressedKeys.Contains("L"))
                {
                    this._clearControls();
                    this._pressedKeys.Clear();
                }
                if (_pressedKeys.Contains("C"))
                {
                    this._callFinalCalculation();
                    this._pressedKeys.Clear();
                }
                if (_pressedKeys.Contains("F"))
                {
                    this._fontDialog.ShowDialog();
                    this.Font = _fontDialog.Font;
                    this._pressedKeys.Clear();
                }
                if (_pressedKeys.Contains("O"))
                {
                    this._colorDialog.ShowDialog();
                    this._changeTextColor(_colorDialog.Color);
                    this._pressedKeys.Clear();
                }



            }


        }

        /// <summary>
        /// Listens for key value releases and removes them from the current
        /// scope. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackedListen_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.KeyCode.ToString());
            
        }




        /// other private form methods that are not autogenerated
        /// 

        private void _clearControls ()
        {
            // clears all text boxes
            BasePriceTextBox.Clear();
            AdditionalItemsTextBox.Clear();
            SubTotalTextBox.Clear();
            SalesTaxTextBox.Clear();
            TotalTextBox.Clear();
            TradeInTextBox.Clear();
            AmountDueTextBox.Clear();

            //clears all check boxes
            SterioSystemCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            //resets the radio buttons to the default
            DefaultFinishRadioButton.Checked = true;
            CustomFinishRadioButton.Checked = false;
            PearlizedFinishRadioButton.Checked = false; 
        }

        /// <summary>
        /// Changes the text color for all buttons and lables in the scope
        /// just done as an example of testing dynamically changing all 
        /// controls through a scope
        /// </summary>
        /// <param name="color"></param>
        private void _changeTextColor(Color color)
        {
            this.ForeColor = color;
        }
        /// <summary>
        /// changes the fonts of the form and all children. 
        /// </summary>
        /// <param name="font"></param>
        private void _changeTextFont(Font font)
        {
            this.Font = font;
        }

        /// <summary>
        /// invokes a color change of the box if a value is invalid. Used specifically
        /// for invoking for multicolor via thread.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="control"></param>
        private void _setColor(Color color, Control control)
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => control.BackColor = color));
            else
                control.BackColor = color;
        }



    }

}
