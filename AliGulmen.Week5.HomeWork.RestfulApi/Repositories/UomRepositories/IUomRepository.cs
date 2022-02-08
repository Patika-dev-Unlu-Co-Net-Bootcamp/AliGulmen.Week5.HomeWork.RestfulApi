using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System.Collections.Generic;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories
{
    public interface IUomRepository
    {
        void CreateUom(Uom newUom);
        void DeleteUom(int uomId);
        Uom GetUomDetail(int uomId);
        List<Uom> GetUoms();
        void UpdateUom(int uomId, Uom newUom);
        void UpdateUomDescription(int uomId, string uomDescription);
    }
}
