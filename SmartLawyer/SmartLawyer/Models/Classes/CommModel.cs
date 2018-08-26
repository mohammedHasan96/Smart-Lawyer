using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLawyer.Models.Classes
{
    public class CommModel
    {
        public static CommModel Create()
            => ViewModelSource.Create(() => new CommModel());

        public virtual int CoId { get; set; }
        public virtual CodesModel CoNameCfk { get; set; }
        public virtual String CoValue { get; set; }
        public virtual long CoPeIdFk { get; set; }
        public virtual int CoIsMain { get; set; }

        public static implicit operator CommModel((PersonsCommunicationModel model, List<CodesModel> list) v)
        {
            var Code = v.list.Where(x => x.CName == v.model.CoNameCfk).FirstOrDefault();
            return new CommModel()
            {
                CoId = v.model.CoId,
                CoNameCfk = Code,
                CoIsMain = v.model.CoIsMain,
                CoPeIdFk = v.model.CoPeIdFk,
                CoValue = v.model.CoValue
            };
        }
    }
}
