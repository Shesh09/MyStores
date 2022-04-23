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
   public interface IProductService
    {
        public IEnumerable<ProductModel> GetAllProducts();
        public ProductModel AddProduct(ProductModel newProduct);
        void UpdateProduct(ProductModel model);
        bool Delete(int id);
        bool Exists(int id);
    }


    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var allProducts = productRepository.GetAll().ToList();

            //var productmodel = new List<ProductModel>();
            var productModel = mapper.Map<IEnumerable<ProductModel>>(allProducts);


            return productModel;
        }


        public ProductModel AddProduct(ProductModel newProduct)
        {
            //--.ProductModel -> Product
            //assuming is valid= 

            Product productToAdd = mapper.Map<Product>(newProduct);
            var addedProduct = productRepository.Add(productToAdd);

            newProduct = mapper.Map<ProductModel>(addedProduct);

            return newProduct;

        }

        public void UpdateProduct(ProductModel model)
        {
            Product productToUpdate = mapper.Map<Product>(model);
            productRepository.Update(productToUpdate);
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public bool Exists(int id)
        {
            return productRepository.Exists(id);
        }


       public bool Delete(int id)
        {
            //get item by id
            //delete item
            var itemToDelete = productRepository.GetById(id);
            return productRepository.Delete(itemToDelete);
        }

       
    }
    
}
