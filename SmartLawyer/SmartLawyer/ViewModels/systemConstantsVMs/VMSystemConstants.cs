using DevExpress.Mvvm.DataAnnotations;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Utils;
using SmartLawyer.ViewModels.Main;
using SmartLawyer.Views.Controls.SystemConstants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SmartLawyer.ViewModels.SystemConstantsVMs
{
    public class VMSystemConstants : VMManagmentSystem<CodesModel>
    {
        public ObservableCollection<CodesModel> DataGridSource { get; } = new ObservableCollection<CodesModel>();
        public virtual ObservableCollection<CodesModel> ConstantsCollection { get; } = new ObservableCollection<CodesModel>();
        public virtual string Title { get; set; } = "SystemConstantsTitle".GetDictionaryValue();
        public virtual ImageSource ImageTitle { get; set; } = "systemconstantstitle".ToImageSource();
        public virtual string SearchKey { get; set; }
        public virtual object AdvancedSearchContent { get; set; }
        public virtual CodesModel SelectedDataItem { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = nameof(SelectedConstantChanged), OnPropertyChangingMethodName = nameof(SelectedConstantChanging))]
        public virtual CodesModel SelectedConstant { get; set; }
        public virtual bool ShowAdvancedSearch { get; set; }
        public virtual double RotateAngle { get; set; }
        public virtual bool DeletePopup { get; set; }
        public virtual Brush ViewModelButtonColor { get; set; }
        public virtual object MainContentValue { get; set; } = new UCSystemConstantsMain();
        public virtual String ConstantValue { get; set; }
        public virtual String ConstantDesc { get; set; }
        public virtual List<CodesModel> SystemConstants { get; set; } = new List<CodesModel>();

        public void SelectIndexChanged()
        {
            ConstantValue = SelectedDataItem.CName;
            ConstantDesc = SelectedDataItem.CDesc;
        }

        protected void SelectedConstantChanged(CodesModel oldValue)
        {

        }
        protected void SelectedConstantChanging(CodesModel newValue)
        {
            if (newValue != null)
                DataGridSource.ReFill(SystemConstants.Where(x => x.CMasterId == newValue.CId));
        }

        public void Add()
        {
            var code = new CodesModel()
            {
                CMasterId = (int)SelectedConstant.CId,
                CName = ConstantValue,
                CDesc = ConstantDesc
            };
            DataAccess.InsertCode(out var id, code);
            code.CId = id;
            DataGridSource.Add(code);
        }

        public void AdvancedSearchTogel()
        {

        }

        public void Archive()
        {

        }

        public void Delete()
        {
            if (SelectedDataItem != null)
            {
                if (MessageBox.Show("Are you sure you want to delete all selected Values??",
                "Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var deleteList = DataGridSource.Where(x => x.IsChecked).ToList();
                    foreach (var item in deleteList)
                    {
                        DataAccess.DeleteCode(item.CId);
                        DataGridSource.Remove(item);
                    }


                }
            }
        }


        public void DoAdvancedSearch()
        {

        }

        public void Edit()
        {
            var id = SelectedDataItem.CId;
            var code = new CodesModel()
            {
                CMasterId = (int)SelectedConstant.CId,
                CName = ConstantValue,
                CDesc = ConstantDesc
            };
            DataGridSource.Remove(SelectedDataItem);
            DataAccess.UpdateCode(id, code);
            DataGridSource.Add(code);
        }

        public void Export()
        {

        }

        public void Refresh()
        {
            new Thread(() =>
            {
                Thread inProgress = new Thread(() =>
                {
                    SystemConstants = DataAccess.CodesData();
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
                ConstantsCollection.ReFill(SystemConstants.Where(x => x.CMasterId == 0));
            })
            { IsBackground = true }.Start();
        }

        public void View()
        {

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
    }
}
