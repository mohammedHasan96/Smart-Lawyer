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
        public ObservableCollection<CommModel> CommunicationSource { get; }
           = new ObservableCollection<CommModel>();
        public ObservableCollection<CodesModel> CommunicationCodeSource { get; }
            = new ObservableCollection<CodesModel>();
        public virtual CommModel SelectedCommItem { get; set; }
        public virtual bool IsInProgress { get; set; }
        public PersonsModel EditedPerson { get; set; }
        public List<PersonsAddressModel> AddedAddress { get; set; } = new List<PersonsAddressModel>();
        public List<PersonsCommunicationModel> AddedCommunication { get; set; } = new List<PersonsCommunicationModel>();

        public VMPersonEdit(PersonsModel person, List<CodesModel> PersonTypes, List<CodesModel> CommTypes, List<PersonsCommunicationModel> PersonCommunications)
        {
            //SystemValues.CommTypes = CommTypes;
            PersonTypeSource.ReFill(PersonTypes);
            EditedPerson = person;
            PresentPerson(person);
            CommunicationCodeSource.ReFill(CommTypes);
            foreach (var item in PersonCommunications)
            {
                CommunicationSource.Add((item, CommTypes));
            }
            //CommunicationSource.ReFill(PersonCommunications);
        }

        void PresentPerson(PersonsModel person)
        {
            var adress = person.PeAddress.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            SelectedPersonType = PersonTypeSource.Where(x => x.CId == person.PeType).FirstOrDefault();
            FullName = person.PeName;
            PersonalId = person.PeIdentity;
            if (adress != null && adress.Length == 2)
            {
                City = adress[0];
                Adress = adress[1];
            }
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
                    var addressChangeValue = DataAccess.DeletePersonAddress(peId);
                    var address = new PersonsAddressModel()
                    {
                        PeAdCity = City,
                        PeAdStreetName = Adress,
                        PeAdPerIdFk = EditedPerson.PeId
                    };
                    DataAccess.InsertPersonAddress(out var adressId, address);
                    AddedAddress.Add(address);
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
            CommunicationSource.Add(CommModel.Create());
        }
        public void DeleteComm()
        {
            if (SelectedCommItem != null)
                CommunicationSource.Remove(SelectedCommItem);
        }
    }
}
