﻿using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExam
{
    class RelayCommand : ICommand
    {
        #region Variables
        Func<object, bool> canExecute;
        Action<object> executeAction;
        #endregion

        #region Construction/Initialization
        public RelayCommand(Action<object> executeAction) : this(executeAction, null) { }
        public RelayCommand(Action<object> executeAction, Func<object,bool> canExecute)
        {
            this.executeAction = executeAction ?? throw new ArgumentException("Execute Action was null for ICommanding Operation.");
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Member
        // 메서드
        public bool CanExecute(object param)
        {
            if (param?.ToString().Length == 0) return false;
            bool result = this.canExecute == null ? true : this.canExecute.Invoke(param);
            return result;
        }

        // 메서드
        public void Execute(object param)
        {
            this.executeAction.Invoke(param);
        }

        // 이벤트 (CanExecute의 상태가 바뀔때 호출됨) - 상태가 바뀔때마다 버튼이 활성화/비활성화 되도록 도와줌
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
    }
}
