using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Repositories.UomRepositories
{
    public class InMemUomRepository : IUomRepository
    {
        private Uom _model = new Uom();
        private int _uomId;
        private string _description;
        private List<Uom> uomList = new()
        {

            new Uom { Id = 1, UomCode = "Pk", Description = "Package" },
            new Uom { Id = 2, UomCode = "Pc", Description = "Piece" },
            new Uom { Id = 3, UomCode = "Box", Description = "Box" },
            new Uom { Id = 4, UomCode = "Ctn", Description = "Carton" }

        };



        public void CreateUom(Uom newUom)
        {
            _model = newUom;

            if (_model == null)
                throw new InvalidOperationException("No data entered!");

            var uom = uomList.SingleOrDefault(u => u.Id == _model.Id);

            if (uom is not null)
                throw new InvalidOperationException("You already have this uomCode in your list!");

            uom = _model;
            uomList.Add(uom);
        }



        public void DeleteUom(int uomId)
        {
            _uomId = uomId;

            var ourRecord = uomList.SingleOrDefault(b => b.Id == _uomId); //is it exist?
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            uomList.Remove(ourRecord);
        }



        public Uom GetUomDetail(int uomId)
        {
            _uomId = uomId;

            var uom = uomList.Where(u => u.Id == _uomId).SingleOrDefault();
            if (uom is null)
                throw new InvalidOperationException("The uom is not exist!");


            return uom;
        }



        public List<Uom> GetUoms()
        {
            var uoms = uomList.OrderBy(u => u.Id).ToList<Uom>();
            return uoms;
        }

        public void UpdateUom(int uomId, Uom newUom)
        {
            _model=newUom;
            _uomId=uomId;

            if (_model is null)
                throw new InvalidOperationException("No data entered!");


            var uom = uomList.SingleOrDefault(u => u.Id == _uomId);
            if (uom is null)
                throw new InvalidOperationException("Uom is not found!");


            uom.Id = _model.Id != default ? _model.Id : uom.Id;
            uom.UomCode = _model.UomCode != default ? _model.UomCode : uom.UomCode;
            uom.Description = _model.Description != default ? _model.Description : uom.Description;

        }

        public void UpdateUomDescription(int uomId, string uomDescription)
        {
            _uomId = uomId;
            _description = uomDescription;

            var uom = uomList.SingleOrDefault(u => u.Id == _uomId);
            if (uom is null)
                throw new InvalidOperationException("Uom is not found!");


            uom.Description = _description != default ? _description : uom.Description;
        }
    }
}
