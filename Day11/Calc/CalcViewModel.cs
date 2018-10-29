using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        string inputString = "";
        string displayText = "";
        public event PropertyChangedEventHandler PropertyChanged;
        public CalcViewModel()
        {
            this.AddCharCommand = new AddCharCommand(this);
            this.DeleteCharCommand = new DeleteCharCommand(this);
            this.ClearCommand = new ClearCommand(this);
            this.OperationCommand = new OperationCommand(this);
            this.CalcCommand = new CalcCommand(this);
        }

        public string InputString
        {
            internal set
            {
                if(inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    this.DisplayText = inputString;
                }
            }
            get { return inputString; }
        }

        public string DisplayText
        {
            protected set
            {
                if(displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }

        public string Op { get; set; }
        public double Op1 { get; set; }
        public double Op2 { get; set; }

        public ICommand AddCharCommand { protected set; get; }
        public ICommand DeleteCharCommand { protected set; get; }
        public ICommand ClearCommand { protected set; get; }
        public ICommand OperationCommand { protected set; get; }
        public ICommand CalcCommand { protected set; get; }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class AddCharCommand : ICommand
    {
        private CalcViewModel viewModel;
        public event EventHandler CanExecuteChanged;

        public AddCharCommand(CalcViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.InputString += parameter;
        }
    }

    class DeleteCharCommand : ICommand
    {
        private CalcViewModel viewModel;

        public DeleteCharCommand(CalcViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            viewModel.InputString = viewModel.InputString.Substring(0, viewModel.InputString.Length - 1);
        }
    }

    class ClearCommand : ICommand
    {
        private CalcViewModel viewModel;

        public ClearCommand(CalcViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.InputString.Length > 0; ;
        }

        public void Execute(object parameter)
        {
            viewModel.InputString = "";
        }
    }

    class OperationCommand : ICommand
    {
        private CalcViewModel viewModel;

        public OperationCommand(CalcViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.InputString.Length > 0;
        }

        public void Execute(object parameter)
        {
            viewModel.Op = parameter.ToString();
            viewModel.Op1 = Convert.ToDouble(viewModel.InputString);
            viewModel.InputString = "";
        }
    }

    class CalcCommand : ICommand
    {
        private CalcViewModel viewModel;

        public CalcCommand(CalcViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return (viewModel.Op1.ToString() != string.Empty && viewModel.Op2.ToString() != string.Empty);
        }

        public void Execute(object parameter)
        {
            viewModel.Op2 = Convert.ToDouble(viewModel.InputString);
            switch (viewModel.Op)
            {
                case "+": viewModel.InputString = (viewModel.Op1 + viewModel.Op2).ToString(); break;
                case "-": viewModel.InputString = (viewModel.Op1 - viewModel.Op2).ToString(); break;
                case "*": viewModel.InputString = (viewModel.Op1 * viewModel.Op2).ToString(); break;
                case "/": viewModel.InputString = (viewModel.Op1 / viewModel.Op2).ToString(); break;
            }
            viewModel.Op1 = Convert.ToDouble(viewModel.InputString);
        }
    }
}
