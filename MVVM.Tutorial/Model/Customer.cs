using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM.Tutorial.Annotations;

namespace MVVM.Tutorial.Model
{
    public class Customer : INotifyPropertyChanged
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
    }
}
