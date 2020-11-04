using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCalculator
{
    enum Operation { Add, Subtract, Multiply, Divide, Equal }
    class MainViewModel : MainViewModelBase
    {
        private readonly string POINT_CHARACTER = ".";
        private double op1 = 0.0;
        private double op2 = 0.0;
        private string displayNumber = "0";
        private string currentResult = "";
        private Operation? currOperation;

        public string DisplayNumber
        {
            get
            {
                return displayNumber;
            }
            set
            {
                displayNumber = value;
                OnPropertyChanged("DisplayNumber");
            }
        }

        public ICommand SelectButton
        {
            get
            {
                return new DelegateCommand(param => CheckButtonSelection(param), true);
            }
        }

        private void CheckButtonSelection(object param)
        {
            string selectedBtn = param.ToString();
            switch (selectedBtn)
            {
                case "Number0":
                    SetNumberValue("0");
                    break;
                case "Number1":
                    SetNumberValue("1");
                    break;
                case "Number2":
                    SetNumberValue("2");
                    break;
                case "Number3":
                    SetNumberValue("3");
                    break;
                case "Number4":
                    SetNumberValue("4");
                    break;
                case "Number5":
                    SetNumberValue("5");
                    break;
                case "Number6":
                    SetNumberValue("6");
                    break;
                case "Number7":
                    SetNumberValue("7");
                    break;
                case "Number8":
                    SetNumberValue("8");
                    break;
                case "Number9":
                    SetNumberValue("9");
                    break;
                case "CBtn":
                    ClearAll();
                    break;
                case "CeBtn":
                    ClearPartial();
                    break;
                case "modBtn":
                    CalculateMod();
                    break;
                case "divideBtn":
                    SetOperation(Operation.Divide);
                    break;
                case "multBtn":
                    SetOperation(Operation.Multiply);
                    break;
                case "minusBtn":
                    SetOperation(Operation.Subtract);
                    break;
                case "plusBtn":
                    SetOperation(Operation.Add);
                    break;
                case "pointBtn":
                    AddPoint();
                    break;
                case "equalBtn":
                    SetOperation(Operation.Equal);
                    break;
            }
        }
        private void SetNumberValue(String number)
        {
            currentResult += number;
            DisplayNumber = currentResult;
        }
        private void SetOperation(Operation operation)
        {
            if (!string.IsNullOrEmpty(currentResult))
            {
                if (op1 == 0.0)
                {
                    op1 = double.Parse(currentResult);
                }
                else
                {
                    op2 = double.Parse(currentResult);
                    op1 = PerformOperation(op1, op2, currOperation);
                    DisplayNumber = op1.ToString();
                }
            }
            currOperation = operation;
            currentResult = "";
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
        private void CalculateMod()
        {
            if (op1 == 0.0 && !string.IsNullOrEmpty(currentResult))
            {
                op1 = double.Parse(currentResult);
            }
            double altOpResult = op1 / 100;
            DisplayNumber = altOpResult.ToString();
            op1 = altOpResult;
            currOperation = null;
            currentResult = "";
        }
        private void AddPoint()
        {
            if (!string.IsNullOrEmpty(currentResult) && !currentResult.Contains(POINT_CHARACTER))
            {
                currentResult += POINT_CHARACTER;
                DisplayNumber = currentResult;
            }
        }
        private void ClearAll()
        {
            currOperation = null;
            currentResult = "";
            op1 = 0.0;
            op2 = 0.0;
            DisplayNumber = "0";
        }
        private void ClearPartial()
        {
            currentResult = "";
            DisplayNumber = "0";
        }
    }
}
