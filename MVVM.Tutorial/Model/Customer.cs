using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM.Tutorial.Annotations;

namespace MVVM.Tutorial.Model
{
    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Customer(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(propertyName == null) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region IDataErrorInfo Members
        public string this[string columnName] {
            get {
                if (columnName == nameof(Name))
                    Error = string.IsNullOrEmpty(Name) ? "Name cannot be null or empty" : null;
                return Error;
            }
        }

        public string Error { get; private set; }
        #endregion

    }
}
