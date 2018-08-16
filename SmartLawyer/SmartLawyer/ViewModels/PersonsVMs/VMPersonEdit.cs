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
    public class VMPersonEdit
    {
        public static VMPersonEdit Create(PersonsModel person,List<CodesModel> PersonTypes)
            => ViewModelSource.Create(() => new VMPersonEdit(person,PersonTypes));
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

        public VMPersonEdit(PersonsModel person, List<CodesModel> PersonTypes)
        {
            PersonTypeSource.ReFill(PersonTypes);
            AddedPerson = person;
            PresentPerson(person);
        }

        void PresentPerson(PersonsModel person)
        {
            SelectedPersonType = new CodesModel();
            FullName = person.PeName;
            PersonalId = person.PeIdentity;
            SelectedPersonType.CId = person.PeType;
            PhoneNo = person.PhoneNo;
            MobileNo = person.MobileNo;
            EmailAdress = person.Email;
          }
        public void Edit(Window window)
        {
            var commChangeValue = DataAccess.DeletePersonCommunication(AddedPerson.PeId);
            if (PhoneNo != null && PhoneNo != "")
            {
                AddedCommunication.Add(new PersonsCommunicationModel()
                {
                    //CoName = SystemValues.Communications.Phone,
                    //CoValue = EmailAdress

                });
            }
            if (MobileNo != null && MobileNo != "")
            {
                AddedCommunication.Add(new PersonsCommunicationModel()
                {
                    //CoName = SystemValues.Communications.Mobile,
                    //CoValue = EmailAdress

                });
            }
            if (EmailAdress != null && EmailAdress != "")
            {
                AddedCommunication.Add(new PersonsCommunicationModel()
                {
                    //CoName = SystemValues.Communications.Emial,
                    //CoValue = EmailAdress
                });
            }
            var peId = AddedPerson.PeId;
            AddedPerson = new PersonsModel()
            {
                PeId = peId,
                PeName = FullName,
                PeIdentity = PersonalId,
                PeType = (int)SelectedPersonType.CId,
                PhoneNo = PhoneNo,
                MobileNo = MobileNo,
                Email = EmailAdress,
                Address = ""
            };
            var personValueChange = DataAccess.UpdatePerson(AddedPerson.PeId, AddedPerson);
            //foreach (var item in AddedCommunication)
            //{
            //    item.CoPeIdFk = AddedPerson.PeId;
            //    var commValueChange = DataAccess.InsertPersonCommunication(out var id, item);
            //}
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
