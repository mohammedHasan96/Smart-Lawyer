using DevExpress.Mvvm.DataAnnotations;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using SmartLawyer.ViewModels.Main;
using SmartLawyer.Views.Controls.Persons;
using SmartLawyer.Views.Controls.Users;
using SmartLawyer.Views.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartLawyer.ViewModels.PersonVMs
{
    public class VMPersons : MarkupExtension, VMManagmentSystem<PersonsModel>
    {


        public virtual string Title { get; set; } = "PersonsTitle".GetDictionaryValue();
        public virtual ImageSource ImageTitle { get; set; } = "personstitle".ToImageSource();
        public virtual string SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; } = new UCPersonAdvancedSearch();
        public ObservableCollection<PersonsModel> DataGridSource { get; set; }
            = new ObservableCollection<PersonsModel>();// = DataAccess.PersonsData();
        [BindableProperty(OnPropertyChangedMethodName = nameof(SelectedConstantChanged), OnPropertyChangingMethodName = nameof(SelectedConstantChanging))]
        public virtual PersonsModel SelectedDataItem { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; }
        public virtual Brush ViewModelButtonColor { get; set; } = (Brush)(new BrushConverter().ConvertFromString(SystemValues.MyColors.Default));
        public virtual object MainContentValue { get; set; } = new UCPersonsMain();

        public void Add()
        {
            VPersonAdd add = new VPersonAdd();
            if (add.ShowDialog() == true)
                Refresh();
        }
        public void AdvancedSearchTogel()
        {
            ShowAdvancedSearch = !ShowAdvancedSearch;
        }
        public void Archive()
        {

        }

        protected void SelectedConstantChanged(PersonsModel oldValue)
        {

        }
        protected void SelectedConstantChanging(PersonsModel newValue)
        {

        }

        public void Delete()
        {

        }

        public void DoAdvancedSearch()
        {

        }

        public void Edit()
        {
            VPersonEdit edit = new VPersonEdit();
            if (edit.ShowDialog() == true)
                //Refresh();
                return;
        }
        public void Export()
        {

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
        public void Refresh()
        {
            new Thread(() =>
            {
                List<PersonsModel> dataSource = null;
                Thread inProgress = new Thread(() =>
                {
                    dataSource = DataAccess.PersonsData();
                })
                { IsBackground = true };
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
            })
            { IsBackground = true }.Start();
        }
        public void CheckAll()
        {
            foreach (var item in DataGridSource)
            {
                item.IsChecked = true;
            }
        }
        public void UncheckAll()
        {
            foreach (var item in DataGridSource)
            {
                item.IsChecked = false;
            }
        }

        public void View()
        {
            VPersonView view = new VPersonView();
            view.ShowDialog();
        }
    }
}
