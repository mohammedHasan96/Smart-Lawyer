using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SmartLawyer.Models.Classes;
using SmartLawyer.ViewModels.Main;
using System.Collections.ObjectModel;
using SmartLawyer.Models.Values;
using DevExpress.Mvvm.POCO;
using SmartLawyer.Views.Controls.Users;

namespace SmartLawyer.ViewModels
{
    public class VMCases : VMManagmentSystem<IssueModel>
    {
        public static VMCases Create()
            => ViewModelSource.Create(() => new VMCases());
        public ObservableCollection<IssueModel> DataGridSource { get; set; }
        public virtual string Title { get; set; } = "CasesTitle".GetDictionaryValue();
        public virtual ImageSource ImageTitle { get; set; } = "casestitle".ToImageSource();
        public virtual string SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; }
        public virtual IssueModel SelectedDataItem { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; }
        public virtual Brush ViewModelButtonColor { get; set; } = (Brush)(new BrushConverter().ConvertFromString(SystemValues.MyColors.Default));
        public virtual object MainContentValue { get; set; } = new UCUsersMain();

        public void Add()
        {
            
        }

        public void AdvancedSearchTogel()
        {
            
        }

        public void Archive()
        {
            
        }

        public void Delete()
        {
            
        }

        public void Edit()
        {
            
        }

        public void Export()
        {
            
        }

        public void Refresh()
        {
            
        }

        public void View()
        {
            
        }

        public void DoAdvancedSearch()
        {
        }
    }
}
