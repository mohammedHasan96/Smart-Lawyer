using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SmartLawyer.Models.Classes
{

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
      protected  void Update<T>(string name, T value, ref T field)
        {
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class ChecableViewModelBase : ViewModelBase
    {
        bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set => Update(nameof(IsChecked), value, ref isChecked);
        }
    }
    public class RolesModel: ChecableViewModelBase
    {
        public int RoleId { get; set; }
        public String RoleName { get; set; }
        public String Description { get; set; }

      

    }
}