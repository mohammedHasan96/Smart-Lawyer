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
using System.Threading.Tasks;
using System.Windows;

namespace SmartLawyer.ViewModels.PersonsVMs
{
    public class VMPersonAdd
    {
        public static VMPersonAdd Create(List<CodesModel> PersonTypes)
            => ViewModelSource.Create(() => new VMPersonAdd(PersonTypes));

        #region Properties
        public virtual String FullName { get; set; }
        public virtual int PersonalId { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual String EmailAdress { get; set; }
        public virtual String PhoneNo { get; set; }
        public virtual String MobileNo { get; set; }
        public virtual CodesModel SelectedPersonType { get; set; }
        public ObservableCollection<CodesModel> PersonTypeSource { get; } 
            = new ObservableCollection<CodesModel>();

        public PersonsModel AddedPerson { get; set; }
        public List<PersonsAddressModel> AddedAddress { get; set; } = new List<PersonsAddressModel>();
        public List<PersonsCommunicationModel> AddedCommunication { get; set; } = new List<PersonsCommunicationModel>();
        #endregion

        public VMPersonAdd(List<CodesModel> PersonTypes)
        {
            PersonTypeSource.ReFill(PersonTypes);
        }
        public void Add(Window window)
        {
            if (PhoneNo != null && PhoneNo != "")
            {
                AddedCommunication.Add(new PersonsCommunicationModel()
                {
                    CoName = SystemValues.Communications.Phone,
                    CoValue = EmailAdress

                });
            }
            if (MobileNo != null && MobileNo != "")
            {
                AddedCommunication.Add(new PersonsCommunicationModel()
                {
                    CoName = SystemValues.Communications.Mobile,
                    CoValue = EmailAdress

                });
            }
            if (EmailAdress != null && EmailAdress != "")
            {
                AddedCommunication.Add(new PersonsCommunicationModel()
                {
                    CoName = SystemValues.Communications.Emial,
                    CoValue = EmailAdress
                });
            }
            AddedPerson = new PersonsModel()
            {
                PeName = FullName,
                PeIdentity = PersonalId,
                PeType = (int)SelectedPersonType.CId,
                PhoneNo = PhoneNo,
                MobileNo = MobileNo,
                Email = EmailAdress,
                Address = ""
            };
            var personValueChange = DataAccess.InsertPerson(out var personId, AddedPerson);
            foreach (var item in AddedCommunication)
            {
                item.CoPeIdFk = personId;
                var commValueChange = DataAccess.InsertPersonCommunication(out var id, item);
            }
            AddedPerson.PeId = personId;
            window.DialogResult = true;
            window.Close();
        }

        public void Close(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }
    }
}
