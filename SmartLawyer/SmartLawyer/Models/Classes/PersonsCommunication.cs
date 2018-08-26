using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
                                
namespace SmartLawyer.Models.Classes
{
    public class PersonsCommunicationModel
    {
        public static PersonsCommunicationModel Create()
            => ViewModelSource.Create(() => new PersonsCommunicationModel());

        public virtual int CoId { get; set; }
        public virtual String CoNameCfk { get; set; }
        public virtual String CoValue { get; set; }
        public virtual long CoPeIdFk { get; set; }
        public virtual int CoIsMain { get; set; }
    }
}