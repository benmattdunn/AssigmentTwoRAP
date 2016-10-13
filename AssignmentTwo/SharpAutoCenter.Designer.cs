namespace AssignmentTwo
{
    using System.Threading;
    using System.Threading.Tasks;
    partial class SharpAutoCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this._runningStatus = false; //kill loops;
            //kill the threads and close all compoinentes
            this._smartAbortThread(this._GUIWarningsThread);
            this._smartAbortThread(this._exceptionHandleThread);
            this._smartAbortThread(this._valuesUpdateThread);

            //commit infanticide
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Saftly aborts a thread by making sure it's finished it's scope, then killing
        /// it to prevent multithreading handups do to access on use of the abort method.
        /// because of the blocking of code. Copied from previous assignment for ease
        /// of use. 
        /// </summary>
        /// <param name="abortThisThread">Thread to safely abort</param>
        private void _smartAbortThread(Thread abortThisThread)
        {
            bool threadNotAborted = true;
            do
            {
                try
                {
                    abortThisThread.Abort();
                    threadNotAborted = false; // will be blocked if failed.
                }
                catch (System.Exception)
                {
                    //do nothing, try again, because of the blocking nature of 
                    // code execution of try/catch I can be sure that it will
                    // keep attempting until the thread is successfully aborted.
                }

            } while (threadNotAborted);
        }




        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arielStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainItemsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.basePriceLabel = new System.Windows.Forms.Label();
            this.AdditionalOptionsLabel = new System.Windows.Forms.Label();
            this.SubTotalLabel = new System.Windows.Forms.Label();
            this.SalesTaxLabel = new System.Windows.Forms.Label();
            this.TradeInAllowenceLabel = new System.Windows.Forms.Label();
            this.AmountDueLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.BasePriceTextBox = new System.Windows.Forms.TextBox();
            this.AdditionalItemsTextBox = new System.Windows.Forms.TextBox();
            this.SubTotalTextBox = new System.Windows.Forms.TextBox();
            this.SalesTaxTextBox = new System.Windows.Forms.TextBox();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.TradeInTextBox = new System.Windows.Forms.TextBox();
            this.AmountDueTextBox = new System.Windows.Forms.TextBox();
            this.ControlTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.GroupBoxesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AdditionalOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.AdditionalOptionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SterioSystemCheckBox = new System.Windows.Forms.CheckBox();
            this.LeatherInteriorCheckBox = new System.Windows.Forms.CheckBox();
            this.ComputerNavigationCheckBox = new System.Windows.Forms.CheckBox();
            this.ExteriorFinishGroupBox = new System.Windows.Forms.GroupBox();
            this.ExteriorFinishTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DefaultFinishRadioButton = new System.Windows.Forms.RadioButton();
            this.PearlizedFinishRadioButton = new System.Windows.Forms.RadioButton();
            this.CustomFinishRadioButton = new System.Windows.Forms.RadioButton();
            this.mainMenuStrip.SuspendLayout();
            this.MainItemsTableLayoutPanel.SuspendLayout();
            this.ControlTableLayoutPanel.SuspendLayout();
            this.GroupBoxesLayoutPanel.SuspendLayout();
            this.AdditionalOptionsGroupBox.SuspendLayout();
            this.AdditionalOptionsLayoutPanel.SuspendLayout();
            this.ExteriorFinishGroupBox.SuspendLayout();
            this.ExteriorFinishTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(524, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitEvent_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // calculateToolStripMenuItem
            // 
            this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
            this.calculateToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.calculateToolStripMenuItem.Text = "Calculate";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.arielStripMenuItem});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.changeFont_click);
            // 
            // arielStripMenuItem
            // 
            this.arielStripMenuItem.Name = "arielStripMenuItem";
            this.arielStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.arielStripMenuItem.Text = "Ariel";
            this.arielStripMenuItem.Click += new System.EventHandler(this.changeFont_click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.blackToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.changeColor_Click);
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.changeColor_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainItemsTableLayoutPanel
            // 
            this.MainItemsTableLayoutPanel.ColumnCount = 2;
            this.MainItemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainItemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainItemsTableLayoutPanel.Controls.Add(this.basePriceLabel, 0, 0);
            this.MainItemsTableLayoutPanel.Controls.Add(this.AdditionalOptionsLabel, 0, 1);
            this.MainItemsTableLayoutPanel.Controls.Add(this.SubTotalLabel, 0, 2);
            this.MainItemsTableLayoutPanel.Controls.Add(this.SalesTaxLabel, 0, 3);
            this.MainItemsTableLayoutPanel.Controls.Add(this.TradeInAllowenceLabel, 0, 5);
            this.MainItemsTableLayoutPanel.Controls.Add(this.AmountDueLabel, 0, 6);
            this.MainItemsTableLayoutPanel.Controls.Add(this.TotalLabel, 0, 4);
            this.MainItemsTableLayoutPanel.Controls.Add(this.BasePriceTextBox, 1, 0);
            this.MainItemsTableLayoutPanel.Controls.Add(this.AdditionalItemsTextBox, 1, 1);
            this.MainItemsTableLayoutPanel.Controls.Add(this.SubTotalTextBox, 1, 2);
            this.MainItemsTableLayoutPanel.Controls.Add(this.SalesTaxTextBox, 1, 3);
            this.MainItemsTableLayoutPanel.Controls.Add(this.TotalTextBox, 1, 4);
            this.MainItemsTableLayoutPanel.Controls.Add(this.TradeInTextBox, 1, 5);
            this.MainItemsTableLayoutPanel.Controls.Add(this.AmountDueTextBox, 1, 6);
            this.MainItemsTableLayoutPanel.Location = new System.Drawing.Point(10, 35);
            this.MainItemsTableLayoutPanel.Name = "MainItemsTableLayoutPanel";
            this.MainItemsTableLayoutPanel.RowCount = 7;
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainItemsTableLayoutPanel.Size = new System.Drawing.Size(300, 210);
            this.MainItemsTableLayoutPanel.TabIndex = 1;
            // 
            // basePriceLabel
            // 
            this.basePriceLabel.AutoSize = true;
            this.basePriceLabel.Location = new System.Drawing.Point(3, 0);
            this.basePriceLabel.Name = "basePriceLabel";
            this.basePriceLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.basePriceLabel.Size = new System.Drawing.Size(64, 23);
            this.basePriceLabel.TabIndex = 0;
            this.basePriceLabel.Text = "Base Price :";
            // 
            // AdditionalOptionsLabel
            // 
            this.AdditionalOptionsLabel.AutoSize = true;
            this.AdditionalOptionsLabel.Location = new System.Drawing.Point(3, 30);
            this.AdditionalOptionsLabel.Name = "AdditionalOptionsLabel";
            this.AdditionalOptionsLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.AdditionalOptionsLabel.Size = new System.Drawing.Size(98, 23);
            this.AdditionalOptionsLabel.TabIndex = 0;
            this.AdditionalOptionsLabel.Text = "Additional Options :";
            // 
            // SubTotalLabel
            // 
            this.SubTotalLabel.AutoSize = true;
            this.SubTotalLabel.Location = new System.Drawing.Point(3, 60);
            this.SubTotalLabel.Name = "SubTotalLabel";
            this.SubTotalLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.SubTotalLabel.Size = new System.Drawing.Size(59, 23);
            this.SubTotalLabel.TabIndex = 0;
            this.SubTotalLabel.Text = "Sub Total :";
            // 
            // SalesTaxLabel
            // 
            this.SalesTaxLabel.AutoSize = true;
            this.SalesTaxLabel.Location = new System.Drawing.Point(3, 90);
            this.SalesTaxLabel.Name = "SalesTaxLabel";
            this.SalesTaxLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.SalesTaxLabel.Size = new System.Drawing.Size(83, 23);
            this.SalesTaxLabel.TabIndex = 0;
            this.SalesTaxLabel.Text = "Sales Tax (13%)";
            // 
            // TradeInAllowenceLabel
            // 
            this.TradeInAllowenceLabel.AutoSize = true;
            this.TradeInAllowenceLabel.Location = new System.Drawing.Point(3, 150);
            this.TradeInAllowenceLabel.Name = "TradeInAllowenceLabel";
            this.TradeInAllowenceLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.TradeInAllowenceLabel.Size = new System.Drawing.Size(108, 23);
            this.TradeInAllowenceLabel.TabIndex = 0;
            this.TradeInAllowenceLabel.Text = "Trade-In Allowence : ";
            // 
            // AmountDueLabel
            // 
            this.AmountDueLabel.AutoSize = true;
            this.AmountDueLabel.Location = new System.Drawing.Point(3, 180);
            this.AmountDueLabel.Name = "AmountDueLabel";
            this.AmountDueLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.AmountDueLabel.Size = new System.Drawing.Size(72, 23);
            this.AmountDueLabel.TabIndex = 0;
            this.AmountDueLabel.Text = "Amount Due :";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(3, 120);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.TotalLabel.Size = new System.Drawing.Size(37, 23);
            this.TotalLabel.TabIndex = 0;
            this.TotalLabel.Text = "Total :";
            // 
            // BasePriceTextBox
            // 
            this.BasePriceTextBox.Location = new System.Drawing.Point(153, 3);
            this.BasePriceTextBox.Name = "BasePriceTextBox";
            this.BasePriceTextBox.Size = new System.Drawing.Size(144, 20);
            this.BasePriceTextBox.TabIndex = 1;
            this.BasePriceTextBox.Text = "0.00";
            // 
            // AdditionalItemsTextBox
            // 
            this.AdditionalItemsTextBox.Location = new System.Drawing.Point(153, 33);
            this.AdditionalItemsTextBox.Name = "AdditionalItemsTextBox";
            this.AdditionalItemsTextBox.ReadOnly = true;
            this.AdditionalItemsTextBox.Size = new System.Drawing.Size(144, 20);
            this.AdditionalItemsTextBox.TabIndex = 1;
            // 
            // SubTotalTextBox
            // 
            this.SubTotalTextBox.Location = new System.Drawing.Point(153, 63);
            this.SubTotalTextBox.Name = "SubTotalTextBox";
            this.SubTotalTextBox.ReadOnly = true;
            this.SubTotalTextBox.Size = new System.Drawing.Size(144, 20);
            this.SubTotalTextBox.TabIndex = 1;
            // 
            // SalesTaxTextBox
            // 
            this.SalesTaxTextBox.Location = new System.Drawing.Point(153, 93);
            this.SalesTaxTextBox.Name = "SalesTaxTextBox";
            this.SalesTaxTextBox.ReadOnly = true;
            this.SalesTaxTextBox.Size = new System.Drawing.Size(144, 20);
            this.SalesTaxTextBox.TabIndex = 1;
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Location = new System.Drawing.Point(153, 123);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.Size = new System.Drawing.Size(144, 20);
            this.TotalTextBox.TabIndex = 1;
            // 
            // TradeInTextBox
            // 
            this.TradeInTextBox.Location = new System.Drawing.Point(153, 153);
            this.TradeInTextBox.Name = "TradeInTextBox";
            this.TradeInTextBox.Size = new System.Drawing.Size(144, 20);
            this.TradeInTextBox.TabIndex = 1;
            this.TradeInTextBox.Text = "0.00";
            // 
            // AmountDueTextBox
            // 
            this.AmountDueTextBox.Location = new System.Drawing.Point(153, 183);
            this.AmountDueTextBox.Name = "AmountDueTextBox";
            this.AmountDueTextBox.ReadOnly = true;
            this.AmountDueTextBox.Size = new System.Drawing.Size(144, 20);
            this.AmountDueTextBox.TabIndex = 1;
            // 
            // ControlTableLayoutPanel
            // 
            this.ControlTableLayoutPanel.ColumnCount = 3;
            this.ControlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlTableLayoutPanel.Controls.Add(this.ClearButton, 1, 0);
            this.ControlTableLayoutPanel.Controls.Add(this.CalculateButton, 0, 0);
            this.ControlTableLayoutPanel.Controls.Add(this.ExitButton, 2, 0);
            this.ControlTableLayoutPanel.Location = new System.Drawing.Point(9, 256);
            this.ControlTableLayoutPanel.Name = "ControlTableLayoutPanel";
            this.ControlTableLayoutPanel.RowCount = 1;
            this.ControlTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ControlTableLayoutPanel.Size = new System.Drawing.Size(507, 40);
            this.ControlTableLayoutPanel.TabIndex = 2;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(172, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(163, 34);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(3, 3);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(163, 34);
            this.CalculateButton.TabIndex = 0;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.calculateForm_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(341, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(163, 34);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.exitEvent_Click);
            // 
            // GroupBoxesLayoutPanel
            // 
            this.GroupBoxesLayoutPanel.ColumnCount = 1;
            this.GroupBoxesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GroupBoxesLayoutPanel.Controls.Add(this.AdditionalOptionsGroupBox, 0, 0);
            this.GroupBoxesLayoutPanel.Controls.Add(this.ExteriorFinishGroupBox, 0, 1);
            this.GroupBoxesLayoutPanel.Location = new System.Drawing.Point(316, 35);
            this.GroupBoxesLayoutPanel.Name = "GroupBoxesLayoutPanel";
            this.GroupBoxesLayoutPanel.RowCount = 2;
            this.GroupBoxesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GroupBoxesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.GroupBoxesLayoutPanel.Size = new System.Drawing.Size(200, 207);
            this.GroupBoxesLayoutPanel.TabIndex = 3;
            // 
            // AdditionalOptionsGroupBox
            // 
            this.AdditionalOptionsGroupBox.Controls.Add(this.AdditionalOptionsLayoutPanel);
            this.AdditionalOptionsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.AdditionalOptionsGroupBox.Name = "AdditionalOptionsGroupBox";
            this.AdditionalOptionsGroupBox.Size = new System.Drawing.Size(194, 97);
            this.AdditionalOptionsGroupBox.TabIndex = 0;
            this.AdditionalOptionsGroupBox.TabStop = false;
            this.AdditionalOptionsGroupBox.Text = "Additional Options";
            // 
            // AdditionalOptionsLayoutPanel
            // 
            this.AdditionalOptionsLayoutPanel.ColumnCount = 1;
            this.AdditionalOptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AdditionalOptionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AdditionalOptionsLayoutPanel.Controls.Add(this.SterioSystemCheckBox, 0, 0);
            this.AdditionalOptionsLayoutPanel.Controls.Add(this.LeatherInteriorCheckBox, 0, 1);
            this.AdditionalOptionsLayoutPanel.Controls.Add(this.ComputerNavigationCheckBox, 0, 2);
            this.AdditionalOptionsLayoutPanel.Location = new System.Drawing.Point(7, 20);
            this.AdditionalOptionsLayoutPanel.Name = "AdditionalOptionsLayoutPanel";
            this.AdditionalOptionsLayoutPanel.RowCount = 3;
            this.AdditionalOptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AdditionalOptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AdditionalOptionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AdditionalOptionsLayoutPanel.Size = new System.Drawing.Size(181, 77);
            this.AdditionalOptionsLayoutPanel.TabIndex = 0;
            // 
            // SterioSystemCheckBox
            // 
            this.SterioSystemCheckBox.AutoSize = true;
            this.SterioSystemCheckBox.Location = new System.Drawing.Point(3, 3);
            this.SterioSystemCheckBox.Name = "SterioSystemCheckBox";
            this.SterioSystemCheckBox.Size = new System.Drawing.Size(90, 17);
            this.SterioSystemCheckBox.TabIndex = 0;
            this.SterioSystemCheckBox.Text = "Sterio System";
            this.SterioSystemCheckBox.UseVisualStyleBackColor = true;
            // 
            // LeatherInteriorCheckBox
            // 
            this.LeatherInteriorCheckBox.AutoSize = true;
            this.LeatherInteriorCheckBox.Location = new System.Drawing.Point(3, 28);
            this.LeatherInteriorCheckBox.Name = "LeatherInteriorCheckBox";
            this.LeatherInteriorCheckBox.Size = new System.Drawing.Size(97, 17);
            this.LeatherInteriorCheckBox.TabIndex = 1;
            this.LeatherInteriorCheckBox.Text = "Leather Interior";
            this.LeatherInteriorCheckBox.UseVisualStyleBackColor = true;
            // 
            // ComputerNavigationCheckBox
            // 
            this.ComputerNavigationCheckBox.AutoSize = true;
            this.ComputerNavigationCheckBox.Location = new System.Drawing.Point(3, 53);
            this.ComputerNavigationCheckBox.Name = "ComputerNavigationCheckBox";
            this.ComputerNavigationCheckBox.Size = new System.Drawing.Size(125, 17);
            this.ComputerNavigationCheckBox.TabIndex = 2;
            this.ComputerNavigationCheckBox.Text = "Computer Navigation";
            this.ComputerNavigationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExteriorFinishGroupBox
            // 
            this.ExteriorFinishGroupBox.Controls.Add(this.ExteriorFinishTableLayout);
            this.ExteriorFinishGroupBox.Location = new System.Drawing.Point(3, 106);
            this.ExteriorFinishGroupBox.Name = "ExteriorFinishGroupBox";
            this.ExteriorFinishGroupBox.Size = new System.Drawing.Size(194, 98);
            this.ExteriorFinishGroupBox.TabIndex = 1;
            this.ExteriorFinishGroupBox.TabStop = false;
            this.ExteriorFinishGroupBox.Text = "Exterior Finish";
            // 
            // ExteriorFinishTableLayout
            // 
            this.ExteriorFinishTableLayout.ColumnCount = 1;
            this.ExteriorFinishTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExteriorFinishTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ExteriorFinishTableLayout.Controls.Add(this.DefaultFinishRadioButton, 0, 0);
            this.ExteriorFinishTableLayout.Controls.Add(this.PearlizedFinishRadioButton, 0, 1);
            this.ExteriorFinishTableLayout.Controls.Add(this.CustomFinishRadioButton, 0, 2);
            this.ExteriorFinishTableLayout.Location = new System.Drawing.Point(10, 19);
            this.ExteriorFinishTableLayout.Name = "ExteriorFinishTableLayout";
            this.ExteriorFinishTableLayout.RowCount = 3;
            this.ExteriorFinishTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ExteriorFinishTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ExteriorFinishTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ExteriorFinishTableLayout.Size = new System.Drawing.Size(178, 73);
            this.ExteriorFinishTableLayout.TabIndex = 0;
            // 
            // DefaultFinishRadioButton
            // 
            this.DefaultFinishRadioButton.AutoSize = true;
            this.DefaultFinishRadioButton.Checked = true;
            this.DefaultFinishRadioButton.Location = new System.Drawing.Point(3, 3);
            this.DefaultFinishRadioButton.Name = "DefaultFinishRadioButton";
            this.DefaultFinishRadioButton.Size = new System.Drawing.Size(89, 17);
            this.DefaultFinishRadioButton.TabIndex = 0;
            this.DefaultFinishRadioButton.TabStop = true;
            this.DefaultFinishRadioButton.Text = "Default Finish";
            this.DefaultFinishRadioButton.UseVisualStyleBackColor = true;
            // 
            // PearlizedFinishRadioButton
            // 
            this.PearlizedFinishRadioButton.AutoSize = true;
            this.PearlizedFinishRadioButton.Location = new System.Drawing.Point(3, 27);
            this.PearlizedFinishRadioButton.Name = "PearlizedFinishRadioButton";
            this.PearlizedFinishRadioButton.Size = new System.Drawing.Size(98, 17);
            this.PearlizedFinishRadioButton.TabIndex = 1;
            this.PearlizedFinishRadioButton.TabStop = true;
            this.PearlizedFinishRadioButton.Text = "Pearlized Finish";
            this.PearlizedFinishRadioButton.UseVisualStyleBackColor = true;
            // 
            // CustomFinishRadioButton
            // 
            this.CustomFinishRadioButton.AutoSize = true;
            this.CustomFinishRadioButton.Location = new System.Drawing.Point(3, 51);
            this.CustomFinishRadioButton.Name = "CustomFinishRadioButton";
            this.CustomFinishRadioButton.Size = new System.Drawing.Size(90, 17);
            this.CustomFinishRadioButton.TabIndex = 2;
            this.CustomFinishRadioButton.TabStop = true;
            this.CustomFinishRadioButton.Text = "Custom Finish";
            this.CustomFinishRadioButton.UseVisualStyleBackColor = true;
            // 
            // SharpAutoCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 312);
            this.Controls.Add(this.GroupBoxesLayoutPanel);
            this.Controls.Add(this.ControlTableLayoutPanel);
            this.Controls.Add(this.MainItemsTableLayoutPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "SharpAutoCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharp AutoCenter";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SharpAutoCenter_KeyPress);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.MainItemsTableLayoutPanel.ResumeLayout(false);
            this.MainItemsTableLayoutPanel.PerformLayout();
            this.ControlTableLayoutPanel.ResumeLayout(false);
            this.GroupBoxesLayoutPanel.ResumeLayout(false);
            this.AdditionalOptionsGroupBox.ResumeLayout(false);
            this.AdditionalOptionsLayoutPanel.ResumeLayout(false);
            this.AdditionalOptionsLayoutPanel.PerformLayout();
            this.ExteriorFinishGroupBox.ResumeLayout(false);
            this.ExteriorFinishTableLayout.ResumeLayout(false);
            this.ExteriorFinishTableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        #region systemSetup
        /// <summary>
        /// generated code for object construction.
        /// </summary>

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel MainItemsTableLayoutPanel;
        private System.Windows.Forms.Label basePriceLabel;
        private System.Windows.Forms.Label AdditionalOptionsLabel;
        private System.Windows.Forms.Label SubTotalLabel;
        private System.Windows.Forms.Label SalesTaxLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label TradeInAllowenceLabel;
        private System.Windows.Forms.Label AmountDueLabel;
        private System.Windows.Forms.TextBox BasePriceTextBox;
        private System.Windows.Forms.TextBox AdditionalItemsTextBox;
        private System.Windows.Forms.TextBox SubTotalTextBox;
        private System.Windows.Forms.TextBox SalesTaxTextBox;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.TextBox TradeInTextBox;
        private System.Windows.Forms.TextBox AmountDueTextBox;
        private System.Windows.Forms.TableLayoutPanel ControlTableLayoutPanel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TableLayoutPanel GroupBoxesLayoutPanel;
        private System.Windows.Forms.GroupBox ExteriorFinishGroupBox;
        private System.Windows.Forms.GroupBox AdditionalOptionsGroupBox;
        private System.Windows.Forms.TableLayoutPanel AdditionalOptionsLayoutPanel;
        private System.Windows.Forms.CheckBox SterioSystemCheckBox;
        private System.Windows.Forms.CheckBox LeatherInteriorCheckBox;
        private System.Windows.Forms.CheckBox ComputerNavigationCheckBox;
        private System.Windows.Forms.TableLayoutPanel ExteriorFinishTableLayout;
        private System.Windows.Forms.RadioButton DefaultFinishRadioButton;
        private System.Windows.Forms.RadioButton PearlizedFinishRadioButton;
        private System.Windows.Forms.RadioButton CustomFinishRadioButton;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arielStripMenuItem;
        #endregion
    }



}

