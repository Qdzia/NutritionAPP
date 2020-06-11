using NutritionApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutritionApp.ViewModels
{
    class MenuItemViewModel : BaseVM
    {
        #region Prywatne pola

        private List<MenuItemViewModel> _children;
        private bool _isChecked;
        private ICommand _command;

        #endregion

        #region Constructor

        public MenuItemViewModel(
            string header = null,
            ICommand command = null,
            string pathToIcon = null,
            string toolTipText = null,
            string inputGestureText = null,
            bool isCheckable = false,
            bool isChecked = false,
            List<MenuItemViewModel> children = null
            )
        {
            this.Header = header;
            this.PathToIcon = pathToIcon;
            this.ToolTipText = toolTipText;
            this.InputGestureText = inputGestureText;
            this._command = command;
            this.IsCheckable = isCheckable;
            this._isChecked = isChecked;
            if (children != null)
                this._children = children;
            else
                this._children = new List<MenuItemViewModel>();
        }

        #endregion

        #region Properties
        public string Header { get; }
        public string PathToIcon { get; }
        public string ToolTipText { get; }
        public string InputGestureText { get; }
        public bool IsCheckable { get; }
        public List<MenuItemViewModel> Children
        {
            get { return _children; }
            set { _children = value; }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        public ICommand Command
        {
            get { return _command; }
            set { SetProperty(ref _command, value); }
        }
    
        #endregion
    }
}
