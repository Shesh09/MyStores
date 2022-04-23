using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        public IEnumerable<SupplierModel> GetAllSupplier();
        public SupplierModel AddSupplier(SupplierModel newSupplier);
    }
    public class SupplierService : ISupplierService
    {
        public IMapper mapper;
        public ISupplierRepository supplierRepository;

        public SupplierService(IMapper mapper, ISupplierRepository supplierRepository)
        {
            this.mapper = mapper;
            this.supplierRepository = supplierRepository;
        }

        public SupplierModel AddSupplier(SupplierModel newSupplier)
        {
            Supplier supplierToAdd = mapper.Map<Supplier>(newSupplier);
            var addedSupplier = supplierRepository.Add(supplierToAdd);
            newSupplier = mapper.Map<SupplierModel>(addedSupplier);
            return newSupplier;
        }

        public IEnumerable<SupplierModel> GetAllSupplier()
        {
            var allSupplier = supplierRepository.GetAll().ToList();
            var supplierModel = mapper.Map<IEnumerable<SupplierModel>>(allSupplier);
            return supplierModel;
        }


    }
}
