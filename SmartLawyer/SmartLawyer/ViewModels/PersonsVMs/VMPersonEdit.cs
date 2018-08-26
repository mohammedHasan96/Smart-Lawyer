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
    public class VMPersonEdit
    {
        public static VMPersonEdit Create(PersonsModel person, List<CodesModel> PersonTypes, List<CodesModel> CommTypes, List<PersonsCommunicationModel> PersonCommunications)
            => ViewModelSource.Create(() => new VMPersonEdit(person, PersonTypes, CommTypes, PersonCommunications));
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
        public PersonsModel EditedPerson { get; set; }
        public List<PersonsAddressModel> AddedAddress { get; set; } = new List<PersonsAddressModel>();
        public List<PersonsCommunicationModel> AddedCommunication { get; set; } = new List<PersonsCommunicationModel>();

        public VMPersonEdit(PersonsModel person, List<CodesModel> PersonTypes, List<CodesModel> CommTypes, List<PersonsCommunicationModel> PersonCommunications)
        {
            PersonTypeSource.ReFill(PersonTypes);
            EditedPerson = person;
            PresentPerson(person);
            CommunicationCodeSource.ReFill(CommTypes);
            CommunicationSource.ReFill(PersonCommunications);
        }

        void PresentPerson(PersonsModel person)
        {
            SelectedPersonType = new CodesModel();
            FullName = person.PeName;
            PersonalId = person.PeIdentity;
            SelectedPersonType.CId = person.PeType;

            //PhoneNo = person.PhoneNo;
            //MobileNo = person.MobileNo;
            //EmailAdress = person.Email;
        }
        public void Edit(Window window)
        {
            IsInProgress = true;
            new Thread(() =>
            {
                var peId = EditedPerson.PeId;
                EditedPerson = new PersonsModel()
                {
                    PeId = peId,
                    PeName = FullName,
                    PeIdentity = PersonalId,
                    PeType = (int)SelectedPersonType.CId,
                    PeAddress = ""
                    //PhoneNo = PhoneNo,
                    //MobileNo = MobileNo,
                    //Email = EmailAdress,
                    //Address = ""
                };
                var personValueChange = DataAccess.UpdatePerson(EditedPerson.PeId, EditedPerson);
                if (personValueChange == 1)
                {
                    var commChangeValue = DataAccess.DeletePersonCommunication(peId);
                    foreach (var item in CommunicationSource)
                    {
                        item.CoPeIdFk = peId;
                        var commValueChange = DataAccess.InsertPersonCommunication(out var id, item);
                        AddedCommunication.Add(item);
                    }
                }
                IsInProgress = false;
                App.Current.Dispatcher.Invoke((Action)delegate
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
