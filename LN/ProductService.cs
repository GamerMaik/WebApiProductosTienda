using ENTIDADES;
using System.Runtime.InteropServices;
using System;
using DAL;
using Microsoft.IdentityModel.Tokens;

namespace LN
{
    public class PersonController
    {
        public ProductRepository _productRepository;

        public PersonController()
        {
            _productRepository = new ProductRepository();
        }

        public void GetProduct(int id)
        {
            //var person = _productRepository.GetPersonById(id);
        }

        public void AddPerson(EProduct product)
        {
            try
            {
                //_productRepository.Adicionar_eEProduct(eEProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }


        public bool UpdatePerson()
        {
            //return _productRepository.UpdatePerson();
            return true;
        }
    }
}
