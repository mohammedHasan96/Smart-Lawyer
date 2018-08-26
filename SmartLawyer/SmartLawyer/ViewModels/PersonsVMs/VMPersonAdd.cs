using DevExpress.Mvvm.POCO;
using SmartLawyer.Models;
using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SmartLawyer.ViewModels.PersonsVMs
{
    public class VMPersonAdd
    {
        public static VMPersonAdd Create(List<CodesModel> PersonTypes, List<CodesModel> CommTypes)
            => ViewModelSource.Create(() => new VMPersonAdd(PersonTypes, CommTypes));

        #region Properties
        public virtual String FullName { get; set; }
        public virtual int PersonalId { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual String City { get; set; }
        public virtual String Adress { get; set; }
        public virtual CodesModel SelectedPersonType { get; set; }
        public ObservableCollection<CodesModel> PersonTypeSource { get; }
            = new ObservableCollection<CodesModel>();
        public ObservableCollection<PersonsCommunicationModel> CommunicationSource { get; }
            = new ObservableCollection<PersonsCommunicationModel>();
        public ObservableCollection<CodesModel> CommunicationCodeSource { get; }
            = new ObservableCollection<CodesModel>();
        public virtual PersonsCommunicationModel SelectedCommItem { get; set; }
        public virtual bool IsInProgress { get; set; }
        public PersonsModel AddedPerson { get; set; }
        public List<PersonsAddressModel> AddedAddress { get; set; } = new List<PersonsAddressModel>();
        public List<PersonsCommunicationModel> AddedCommunication { get; set; } = new List<PersonsCommunicationModel>();
        #endregion

        public VMPersonAdd(List<CodesModel> PersonTypes, List<CodesModel> CommTypes)
        {
            PersonTypeSource.ReFill(PersonTypes);
            CommunicationCodeSource.ReFill(CommTypes);
        }
        public void Add(Window window)
        {
            IsInProgress = true;
            new Thread(() =>
            {
                AddedPerson = new PersonsModel()
                {
                    PeName = FullName,
                    PeIdentity = PersonalId,
                    PeType = (int)SelectedPersonType.CId,
                    PeAddress = ""
                    //PhoneNo = PhoneNo,
                    //MobileNo = MobileNo,
                    //Email = EmailAdress,
                    //Address = ""
                };
                var personValueChange = DataAccess.InsertPerson(out var personId, AddedPerson);
                AddedPerson.PeId = personId;
                foreach (var item in CommunicationSource)
                {
                    item.CoPeIdFk = personId;
                    var commValueChange = DataAccess.InsertPersonCommunication(out var id, item);
                    AddedCommunication.Add(item);
                }
                var address = new PersonsAddressModel()
                {
                    PeAdCity = City,
                    PeAdStreetName = Adress,
                    PeAdPerIdFk = AddedPerson.PeId
                };
                DataAccess.InsertPersonAddress(out var adressId, address);
                AddedAddress.Add(address);
                IsInProgress = false;
                App.Current.Dispatcher.Invoke(() =>
                {
                    window.DialogResult = true;
                    window.Close();
                });

            })
            { IsBackground = true }.Start();


        }

        public void Close(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }

        public void AddComm()
        {
            CommunicationSource.Add(PersonsCommunicationModel.Create());
        }
        public void DeleteComm()
        {
            if (SelectedCommItem != null)
                CommunicationSource.Remove(SelectedCommItem);
        }
    }
}
