using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace LabelPrinter
{
    public partial class Form1 : Form
    {
        ConfigINI config;
        PrintDocument print;
        String Key;
        String CompanyName = "Company Name";

        private const int WM_GETTEXTLENGTH = 0x000E;
        private const int WM_GETTEXT = 0x000D;

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
            static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint= "FindWindow")]
            private static extern IntPtr FindWindow(string sClass, string sWindow);
        [DllImport("User32.Dll")]
            public static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = false)]
            static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);


        public Form1()
        {
            InitializeComponent();
        }
        private bool IsFontInstalled(string fontName)
        {
            using (var testFont = new Font(fontName, 8))
            {
                return 0 == string.Compare(
                  fontName,
                  testFont.Name,
                  StringComparison.InvariantCultureIgnoreCase);
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            print = new PrintDocument();

            config = new ConfigINI(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\labelprinter.ini");
            config.Load();
            Populate_Printers();
            print.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            if (!IsFontInstalled("CCode39"))
            {
                MessageBox.Show("Please Install CCode39 Font");
                this.Close();
            }

        }
        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            textBox_Resolution.Text = Math.Round(e.PageSettings.PrintableArea.Width).ToString() + "x" + Math.Round(e.PageSettings.PrintableArea.Height).ToString();
            if (tabControl1.SelectedIndex == 0)
            {
                printDoc_PrintPage_CustomerLabel(e);
            }
            if (tabControl1.SelectedIndex == 1)
            {
                printDoc_PrintPage_ProductLabel(e);
            }
            if (tabControl1.SelectedIndex == 2)
            {
                printDoc_PrintPage_Label(e);
            }
                    }

        private void printDoc_PrintPage_Label(PrintPageEventArgs e)
        {
            Font printFont;
            float fsize;
            SizeF size = new Size(0,0);
            //float X_Margin = e.MarginBounds.
            float X_Resolution = 225; // e.PageSettings.PrintableArea.Width;
            float Y_Resolution = 125; // e.PageSettings.PrintableArea.Height;
            float Y_Bottom = Y_Resolution;
            

            String s = textBox_Label.Text;

            for (fsize = 50; fsize > 0; fsize--)
            {
                printFont = new Font("Courier New", fsize, FontStyle.Bold);
                size = e.Graphics.MeasureString(s, printFont);
                if (size.Width < X_Resolution && size.Height < Y_Resolution)
                    break;
            }
            if (fsize == 0)
            {
                MessageBox.Show("Can't fit the text on the label");
                return;
            }
            printFont = new Font("Courier New", fsize, FontStyle.Bold);
            e.Graphics.DrawString(s, printFont, Brushes.Black, (X_Resolution/2) - (size.Width/2), (Y_Resolution/2) - (size.Height/2));



        }



        private void printDoc_PrintPage_ProductLabel(PrintPageEventArgs e)
        {
            SizeF size_BarCode;
            String BarCode;

            //float X_Margin = e.MarginBounds.
            float X_Resolution = 225; // e.PageSettings.PrintableArea.Width;
            float Y_Resolution = 125; // e.PageSettings.PrintableArea.Height;
            float Y_Margin = 4;
            float Y_Bottom = Y_Resolution - Y_Margin;
            float Y_Top = Y_Margin;
            float X_Margin = 4;
            X_Resolution = X_Resolution - X_Margin - X_Margin;


            // Draw company name at the bottom

            Font printFont = new Font("Courier New", 8, FontStyle.Bold);
            SizeF size_CompanyName = e.Graphics.MeasureString(CompanyName, printFont);
            Y_Bottom -= size_CompanyName.Height;
            e.Graphics.DrawString(CompanyName, printFont, Brushes.Black, X_Margin + (X_Resolution / 2) - (size_CompanyName.Width / 2), Y_Bottom);


            /* Old barcode section 
            printFont = new Font("CCode39", 8);
            do
            {
                BarCode = "*" + textBox_BarCode.Text.ToUpper() + "*";
                size_BarCode = e.Graphics.MeasureString(BarCode, printFont);
                if (size_BarCode.Width > X_Resolution)
                    textBox_BarCode.Text = textBox_BarCode.Text.Remove(textBox_BarCode.Text.Length - 1);
                BarCode = "*" + textBox_BarCode.Text.ToUpper() + "*";
                size_BarCode = e.Graphics.MeasureString(BarCode, printFont);

            } while (size_BarCode.Width > X_Resolution);

             printFont = new Font("Courier New", 10, FontStyle.Bold);
            String BarCodeText = textBox_BarCode.Text.ToUpper();
            SizeF size_BarCodeText = e.Graphics.MeasureString(BarCodeText, printFont);
            Y_Bottom -= size_BarCodeText.Height;
            e.Graphics.DrawString(BarCodeText, printFont, Brushes.Black, X_Left_Margin + (X_Resolution / 2) - (size_BarCodeText.Width / 2), Y_Bottom);

                        printFont = new Font("CCode39", 8);
            BarCode = "*" + textBox_BarCode.Text.ToUpper() + "*";
            size_BarCode = e.Graphics.MeasureString(BarCode, printFont);
            Y_Bottom -= size_BarCode.Height;
            e.Graphics.DrawString(BarCode, printFont, Brushes.Black, X_Left_Margin +(X_Resolution / 2) - (size_BarCode.Width/2) , Y_Bottom);


 * */

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image image = b.Encode(BarcodeLib.TYPE.CODE128, textBox_BarCode.Text.ToUpper(), Color.Black, Color.White, (int)X_Resolution,20);
//            image.Save("test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);


            e.Graphics.DrawImage(image, X_Margin, Y_Bottom - image.Height);
            Y_Bottom -= image.Height;



            printFont = new Font("Courier New", 10, FontStyle.Bold);
            String BarCodeText = textBox_BarCode.Text.ToUpper();
            SizeF size_BarCodeText = e.Graphics.MeasureString(BarCodeText, printFont);
            Y_Bottom -= size_BarCodeText.Height;
            e.Graphics.DrawString(BarCodeText, printFont, Brushes.Black, X_Margin + (X_Resolution / 2) - (size_BarCodeText.Width / 2), Y_Bottom);




            printFont = new Font("Courier New", 12, FontStyle.Bold);
            String ProductName = textBox_ProductName.Text;
            SizeF size_ProductName = e.Graphics.MeasureString(ProductName, printFont);
            e.Graphics.DrawString(ProductName, printFont, Brushes.Black, X_Margin + 0, Y_Top);
            Y_Top += size_ProductName.Height;

            printFont = new Font("Courier New", 10,FontStyle.Bold);
            String ShortDesc = textBox_ShortDescription.Text;
            SizeF size_ShortDesc = e.Graphics.MeasureString(ShortDesc, printFont);
            e.Graphics.DrawString(ShortDesc, printFont, Brushes.Black, X_Margin + 0, Y_Top);
            Y_Top += size_ShortDesc.Height;


            //float PriceMaxHeight = Y_Bottom - Y_Top;

            printFont = new Font("Courier New", 14,FontStyle.Bold);
            String Price = textBox_Price.Text;
            SizeF size_Price = e.Graphics.MeasureString(Price, printFont);
            e.Graphics.DrawString(Price, printFont, Brushes.Black, X_Margin + X_Resolution - size_Price.Width, Y_Top);
            Y_Top += size_Price.Height;
            
        }


        private void printDoc_PrintPage_CustomerLabel(PrintPageEventArgs e)
        {
            //float X_Margin = e.MarginBounds.
            float Y_Margin = e.MarginBounds.Top;

            float X_Resolution = 225; // e.PageSettings.PrintableArea.Width;
            float Y_Resolution = 125; // e.PageSettings.PrintableArea.Height;

            Font printFont = new Font("Courier New", 8, FontStyle.Bold);
            SizeF size_CompanyName = e.Graphics.MeasureString(CompanyName, printFont);



            printFont = new Font("Courier New", 8, FontStyle.Bold);
            String Commitment = "Commitment to Excellence";
            SizeF size_Commitment = e.Graphics.MeasureString(Commitment, printFont);

            String CustomerPhoneNumber = textBox_Phone.Text;
            SizeF size_CustomerPhoneNumber = e.Graphics.MeasureString(CustomerPhoneNumber, printFont);

            float TextTotalHeight = size_CompanyName.Height + size_Commitment.Height + size_CustomerPhoneNumber.Height;

            //e.Graphics.FillRectangle(Brushes.Black, e.PageBounds);
            printFont = new Font("Courier New", 12, FontStyle.Bold);
            e.Graphics.DrawString(CustomerPhoneNumber, printFont, Brushes.Black, 0 , Y_Resolution - TextTotalHeight-10);

            printFont = new Font("Courier New", 8, FontStyle.Bold);
            e.Graphics.DrawString(CompanyName, printFont, Brushes.Black, (X_Resolution / 2) - (size_CompanyName.Width/2) , Y_Resolution - TextTotalHeight + size_CustomerPhoneNumber.Height);

            printFont = new Font("Courier New", 8, FontStyle.Bold);
            e.Graphics.DrawString(Commitment, printFont, Brushes.Black, (X_Resolution / 2) - (size_Commitment.Width / 2), Y_Resolution - TextTotalHeight + size_CustomerPhoneNumber.Height + size_CompanyName.Height);

            printFont = new Font("Courier New", 12, FontStyle.Bold);
            e.Graphics.DrawLine(Pens.Black, 
                    0, 
                    Y_Resolution - TextTotalHeight + size_CustomerPhoneNumber.Height - 1,
                    X_Resolution, 
                    Y_Resolution - TextTotalHeight + size_CustomerPhoneNumber.Height - 1);


            // Try to fit the name in and make it as big as possible
            float AvailableHeight = Y_Resolution - TextTotalHeight;
            String Name = textBox_CustomerName.Text.ToUpper();
            SizeF size_Name;
            int FontSize = 2;
            for (int t = 2; t < 100; t++)
            {
                printFont = new Font("Courier New", t, FontStyle.Bold);
                size_Name = e.Graphics.MeasureString(Name,printFont);
                if(size_Name.Width > X_Resolution || size_Name.Height > AvailableHeight) {
                    FontSize=t-1;
                    break;
                }
            }
            printFont = new Font("Courier New", FontSize, FontStyle.Bold);
            size_Name = e.Graphics.MeasureString(Name, printFont);
            //e.Graphics.FillRectangle(Brushes.Black, 0, 0, size_Name.Width, size_Name.Height);
            e.Graphics.DrawString(Name, printFont, Brushes.Black, 0, 0);
        }

        

        private void Populate_Printers()
        {

            ArrayList prnList = new ArrayList(PrinterSettings.InstalledPrinters);
            prnList.Sort();
            comboBox_Printer.Items.Clear();
            for (int t = 0; t < prnList.Count; t++)
            {
                comboBox_Printer.Items.Add(prnList[t]);
            }
            //comboBox_Printer.SelectedIndex = 0;

            if (config.ReadString("Printer").Length > 0)
            {
                comboBox_Printer.SelectedItem = config.ReadString("Printer");
            }

        }
        private void comboBox_Printer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSelectedPrinter();
        }

        private void comboBox_Printer_SelectedValueChanged(object sender, EventArgs e)
        {
            SaveSelectedPrinter();
        }
        private void SaveSelectedPrinter()
        {
            if (config != null)
            {
                if (comboBox_Printer.SelectedItem != null)
                {
                    config.WriteValue("Printer", (String)comboBox_Printer.SelectedItem);
                }
            }
        }

        private void button_Print_Click_1(object sender, EventArgs e)
        {
            print.PrinterSettings.Copies = Convert.ToInt16(numericUpDown1.Value);
            print.PrinterSettings.PrinterName = (String)comboBox_Printer.SelectedItem;
            
            print.Print();
            

            
            



        }
        public static string GetCaptionOfWindow(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
        public IntPtr FindWindow(IntPtr Parent, String s)
        {

            List<IntPtr> AllWindows = GetAllChildrenWindowHandles(Parent);
            for(int counter = 0;counter < AllWindows.Count;counter ++)
            {
                String caption = GetCaptionOfWindow(AllWindows[counter]);
                if (caption.Contains(s ))
                    return AllWindows[counter];

            }
            return IntPtr.Zero;
        }

        List<IntPtr> GetAllChildrenWindowHandles(IntPtr ParentHWND)
        {
            List<IntPtr> result = new List<IntPtr>();


            IntPtr prevChild = IntPtr.Zero;
            IntPtr currChild = IntPtr.Zero;
            while (true)
            {
                currChild = FindWindowEx(ParentHWND, prevChild, null, null);
                if (currChild == IntPtr.Zero)
                {

                    break;
                }
                result.Add(currChild);
                prevChild = currChild;
            }
            return result;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.Save();
        }

        private void button_GetEstimate_Click(object sender, EventArgs e)
        {
            IntPtr QBhwnd = FindWindow(GetDesktopWindow(), "Intuit QuickBooks Enterprise");

            if (QBhwnd == IntPtr.Zero)
            {
                MessageBox.Show("QB Not Found");
            } else {
                List<IntPtr> QBchildren = GetAllChildrenWindowHandles(QBhwnd);
                IntPtr MDIhwnd = QBchildren[1];

                if (MDIhwnd != IntPtr.Zero)
                {
                    IntPtr EstimateHWND = FindWindow(MDIhwnd, "Create Estimates");

                    if (EstimateHWND != IntPtr.Zero)
                    {
                        List<IntPtr> MDIchildren = GetAllChildrenWindowHandles(EstimateHWND);

                        int length = SendMessage(MDIchildren[3], WM_GETTEXTLENGTH, 0, 0);
                        StringBuilder PhoneNumber = new StringBuilder(length);
                        int hr = SendMessage(MDIchildren[3], WM_GETTEXT, length+1, PhoneNumber);
                        textBox_Phone.Text = PhoneNumber.ToString();

                        length = SendMessage(MDIchildren.Last(), WM_GETTEXTLENGTH, 0, 0);
                        StringBuilder CustomerName = new StringBuilder(length);
                        SendMessage(MDIchildren.Last(), WM_GETTEXT, length + 1, CustomerName);

                        
                        textBox_CustomerName.Text = CustomerName.ToString().Split('\n')[0];




                    }
                    else
                    {
                        MessageBox.Show("Estimate Window not found");
                    }
                } else
                {
                    MessageBox.Show("MDI Window not found");
                }
                
            }
        }
    }
}
