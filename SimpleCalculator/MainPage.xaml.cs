using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    enum Operation { Add, Subtract, Multiply, Divide, Equal }

    public sealed partial class MainPage : Page
    {
        public double op1 = 0.0;
        public double op2 = 0.0;
        public string displayNumber = "";
        private Operation? currOperation;

        public MainPage()
        {
            this.InitializeComponent();
            // Set the app window preferred launch view size
            ApplicationView.PreferredLaunchViewSize = new Size(Height = 480, Width = 270);
            // Set app window preferred launch windowing mode
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
        private void SetNumberValue(String number)
        {
            displayNumber += number;
            this.SetResultText(double.Parse(displayNumber));
        }
        private void SetResultText(double number)
        {
            resultTxtBlock.Text = number.ToString();
        }
        private void SetOperation(Operation operation)
        {
            if (!string.IsNullOrEmpty(displayNumber))
            {
                if (op1 == 0.0)
                {
                    op1 = double.Parse(displayNumber);
                }
                else
                {
                    op2 = double.Parse(displayNumber);
                    op1 = this.PerformOperation(op1, op2, currOperation);
                    this.SetResultText(op1);
                }
            }
            currOperation = operation;
            displayNumber = "";
        }
        private double PerformOperation(double op1, double op2, Operation? operation)
        {
            double result = 0.0;
            switch (operation)
            {
                case Operation.Add:
                    result = op1 + op2;
                    break;
                case Operation.Subtract:
                    result = op1 - op2;
                    break;
                case Operation.Multiply:
                    result = op1 * op2;
                    break;
                case Operation.Divide:
                    result = op1 / op2;
                    break;
                case Operation.Equal:
                    result = op1;
                    break;
            }
            return result;
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("7");
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("8");
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("9");
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("4");
        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("5");
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("6");
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("1");
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("2");
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("3");
        }
        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            this.SetNumberValue("0");
        }
        private void PointBtn_Click(object sender, RoutedEventArgs e)
        {
        }
        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            this.currOperation = null;
            this.displayNumber = "";
            this.op1 = 0.0;
            this.op2 = 0.0;
            this.SetResultText(0);
        }
        private void CeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.displayNumber = "";
            this.SetResultText(0);
        }
        private void ModBtn_Click(object sender, RoutedEventArgs e)
        {
        }
        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SetOperation(Operation.Divide);
        }
        private void MultBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SetOperation(Operation.Multiply);
        }
        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SetOperation(Operation.Subtract);
        }
        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SetOperation(Operation.Add);
        }
        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SetOperation(Operation.Equal);
        }
    }
}
