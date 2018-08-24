using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartLawyer.ViewModels.Main
{
    public interface VMManagmentSystem
    {
        #region Properties
        String Title { get; set; }
        ImageSource ImageTitle { get; set; }
        String SearchKey { get; set; }
        object AdvancedSearchContent { get; set; }
        bool ShowAdvancedSearch { get; set; }
        double RotateAngle { get; set; }
        bool DeletePopup { get; set; }
        Brush ViewModelButtonColor { get; set; }
        object MainContentValue { get; set; }
        bool IsInProgress { get; set; }
        #endregion

        #region Commands
        void Add();
        void Edit();
        void Delete();
        void View();
        void Export();
        void Archive();
        void Refresh();
        void AdvancedSearchTogel();
        void DoAdvancedSearch();
        void CheckAll();
        void UncheckAll();
        #endregion
    }
    public interface VMManagmentSystem<T> : VMManagmentSystem
    {
        ObservableCollection<T> DataGridSource { get; }
        T SelectedDataItem { get; set; }
    }
}
