using DevExpress.Mvvm.POCO;
using SmartLawyer.ViewModels.PersonVMs;
using SmartLawyer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Values = SmartLawyer.Models.Values;
using Classes = SmartLawyer.Models.Classes;
using DevExpress.Mvvm;
using SmartLawyer.ViewModels.Main;
using SmartLawyer.ViewModels.GroupsVMs;
using SmartLawyer.ViewModels.SystemConstantsVMs;
using SmartLawyer.ViewModels.UsersVMs;

namespace SmartLawyer.ViewModels
{
    public class VMMainWindow
    {
        public static VMMainWindow Create()
            => ViewModelSource.Create(() => new VMMainWindow());

        public virtual string Title { get; set; } = "MainWindow";
        public static ResourceManager rm = new ResourceManager("SmartLawyer.Resources.Lang.En", Assembly.GetExecutingAssembly());
        public virtual String FlowDirection { get; set; } = "LeftToRight";
        public ObservableCollection<VMManagmentSystem> ViewModels { get; } = new ObservableCollection<VMManagmentSystem>();
        public virtual VMManagmentSystem SelectedViewModel { get; set; }


        public VMMainWindow()
        {
            ViewModels.Add(ViewModelSource.Create(() => new VMUsers()));
            ViewModels.Add(ViewModelSource.Create(() => new VMPersons()));
            ViewModels.Add(ViewModelSource.Create(() => new VMGroups()));
            ViewModels.Add(ViewModelSource.Create(() => new VMSystemConstants()));

            SelectedViewModel = ViewModels.FirstOrDefault();
            SelectedViewModel.ViewModelButtonColor = new BrushConverter().ConvertFromString(Values.SystemValues.MyColors.Selected) as Brush;
        }

        public void En()
        {
            rm = new ResourceManager("SmartLawyer.Resources.Lang.En", Assembly.GetExecutingAssembly());
            FlowDirection = "LeftToRight";
        }
        public void Ar()
        {
            rm = new ResourceManager("SmartLawyer.Resources.Lang.Ar", Assembly.GetExecutingAssembly());
            FlowDirection = "RightToLeft";
        }
        public void ShowViewModel(object parameter)
        {
            if (parameter != SelectedViewModel)
            {
                SelectedViewModel.ViewModelButtonColor = new BrushConverter().ConvertFromString(Values.SystemValues.MyColors.Default) as Brush;
                SelectedViewModel = parameter as VMManagmentSystem;
                SelectedViewModel.ViewModelButtonColor = new BrushConverter().ConvertFromString(Values.SystemValues.MyColors.Selected) as Brush;
                Title = SelectedViewModel.Title;
            }
        }
        public void MouseEnter(VMManagmentSystem obj)
        {
            if (obj != SelectedViewModel)
                obj.ViewModelButtonColor = new BrushConverter().ConvertFromString(Values.SystemValues.MyColors.MouseOver) as Brush;
        }
        public void MouseLeave(VMManagmentSystem obj)
        {
            if (obj != SelectedViewModel)
                obj.ViewModelButtonColor = (Brush)(new BrushConverter().ConvertFromString(Values.SystemValues.MyColors.Default));
        }

    }
}
