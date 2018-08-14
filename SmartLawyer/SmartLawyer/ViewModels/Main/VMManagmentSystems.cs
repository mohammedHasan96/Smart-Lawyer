using DevExpress.Mvvm.POCO;
using SmartLawyer.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;
using Values = SmartLawyer.Models.Values;

namespace SmartLawyer.ViewModels
{
    public abstract class VMManagmentSystems<T>:MarkupExtension/*, VMManagmentSystem*/
    {
        protected VMManagmentSystems()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #region Properties
        public virtual String Title { get; set; }
        public virtual ImageSource ImageTitle { get; set; }
        public virtual String SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; } = null;
        public virtual ObservableCollection<T> DataGridSource { get; set; }
        public virtual object SelectedDataItem { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; } = false;
        public virtual Brush ViewModelButtonColor { get; set; } = (Brush)(new BrushConverter().ConvertFromString(Values.SystemValues.MyColors.Default));
        #endregion
        #region Commands
        public abstract void Add();
        public abstract void Edit();
        public abstract void Delete();
        public abstract void View();
        public abstract void Export();
        public abstract void Archive();
        public abstract void Refresh();
        public abstract void AdvancedSearchTogel();
        #endregion
    }
}
