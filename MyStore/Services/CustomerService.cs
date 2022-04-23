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
    public interface ICustomerService
    {
        public IEnumerable<CustomerModel> GetAllCustomer();
        public CustomerModel AddCustomer(CustomerModel newCustomer);
        
    }
    public class CustomerService : ICustomerService

    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public CustomerModel AddCustomer(CustomerModel newCustomer)
        {
            Customer customerToAdd = mapper.Map<Customer>(newCustomer);
            var addedCustomer = customerRepository.Add(customerToAdd);

            newCustomer = mapper.Map<CustomerModel>(addedCustomer);

            return newCustomer;
        }

        public IEnumerable<CustomerModel> GetAllCustomer()
        {
            var allCustomer = customerRepository.GetAll().ToList();

            //var productmodel = new List<ProductModel>();
            var customerModel = mapper.Map<IEnumerable<CustomerModel>>(allCustomer);


            return customerModel;
        }
    }
}
