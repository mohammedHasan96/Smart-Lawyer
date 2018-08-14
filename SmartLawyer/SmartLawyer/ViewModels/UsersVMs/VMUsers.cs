using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
using SmartLawyer.Views;
using SmartLawyer.Views.Controls.Users;
using SmartLawyer.Views.Person;
using SmartLawyer.Views.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Values = SmartLawyer.Models.Values;
using Classes = SmartLawyer.Models.Classes;
using System.Collections.ObjectModel;
using SmartLawyer.ViewModels.Main;
using DevExpress.Mvvm.POCO;
using SmartLawyer.Models.Values;
using System.Windows.Markup;

namespace SmartLawyer.ViewModels
{
    public class VMUsers : MarkupExtension, VMManagmentSystem<UsersModel>
    {

        //public override string Title { get; set; } = "UsersTitle".GetDictionaryValue();
        //public override ImageSource ImageTitle { get; set; } = "userstitle".ToImageSource();
        //public override double RotateAngle { get; set; }
        //public override  ObservableCollection<UsersModel> DataGridSource { get; set; } //= DataAccess.UsersData();
        //public override object AdvancedSearchContent { get; set; } = new UCUserAdvancedSearch();

        public static VMUsers Create()
            => ViewModelSource.Create(() => new VMUsers());

        public virtual string Title { get; set; } = "UsersTitle".GetDictionaryValue();
        public virtual ImageSource ImageTitle { get; set; } = "userstitle".ToImageSource();
        public virtual string SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; } = new UCUserAdvancedSearch();
        public ObservableCollection<UsersModel> DataGridSource { get; set; } 
            = new ObservableCollection<UsersModel>();//= DataAccess.UsersData();
        public virtual UsersModel SelectedDataItem { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; }
        public virtual Brush ViewModelButtonColor { get; set; } = (Brush)(new BrushConverter().ConvertFromString(SystemValues.MyColors.Default));
        public virtual object MainContentValue { get; set; } = new UCUsersMain();

        public void Add()
        {
            VUserAdd add = new VUserAdd();
            if (add.ShowDialog() == true)
                Refresh();
        }
        public void Archive()
        {

        }
        public void Delete()
        {
            DeletePopup = !DeletePopup;
        }
        public void Edit()
        {
            if (SelectedDataItem != null)
            {
                var item = SelectedDataItem;
                UsersModel user = item;
                VUserEdit edit = new VUserEdit(user);
                if (edit.ShowDialog() == true)
                    Refresh();
            }
        }
        public void Export()
        {

        }
        Thread refrechThread;
        public void Refresh()
        {
            refrechThread = new Thread(() =>
            {
                List<UsersModel> dataSource = null;
                Thread inProgress = new Thread(() =>
                {
                    dataSource = DataAccess.UsersData();
                });


                inProgress.Start();
                while (inProgress.IsAlive)
                {
                    if (RotateAngle > 360)
                        RotateAngle = 0;
                    RotateAngle += 18.25;
                    Thread.Sleep(50);
                }
                while (RotateAngle > 0 && RotateAngle < 365)
                {
                    RotateAngle += 18.25;
                    Thread.Sleep(50);
                }
                RotateAngle = 0;
                DataGridSource.ReFill(dataSource);
            });
            refrechThread.Start();
        }
        public void View()
        {
            VUserView view = new VUserView();
            view.ShowDialog();
        }
        public void AdvancedSearchTogel()
        {
            ShowAdvancedSearch = !ShowAdvancedSearch;
        }
        public void Dispos()
        {
            if (refrechThread != null && refrechThread.IsAlive)
                refrechThread.Abort();
        }

        public void DoAdvancedSearch()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
