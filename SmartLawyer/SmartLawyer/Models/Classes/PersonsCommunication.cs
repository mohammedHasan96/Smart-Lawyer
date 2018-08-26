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

        public static implicit operator PersonsCommunicationModel(CommModel commModel)
            => new PersonsCommunicationModel()
            {
                CoId = commModel.CoId,
                CoIsMain = commModel.CoIsMain,
                CoNameCfk = commModel.CoNameCfk.CName,
                CoPeIdFk = commModel.CoPeIdFk,
                CoValue = commModel.CoValue
            };
    }
}