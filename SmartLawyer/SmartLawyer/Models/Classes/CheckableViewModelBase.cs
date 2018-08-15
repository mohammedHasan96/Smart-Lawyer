using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLawyer.Models.Classes
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Update<T>(string name, T value, ref T field)
        {
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class CheckableViewModelBase : ViewModelBase
    {
        bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set => Update(nameof(IsChecked), value, ref isChecked);
        }
    }
}
