using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal) {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer) {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer) {
            _customerDal.Delete(customer);
            return new SuccessResult("Müşteri silindi");
        }

        public IDataResult<List<Customer>> GetAll() {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),"Müşteriler getirildi");
        }

        public IDataResult<Customer> GetById(int customerId) {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == customerId), "Müşteriler getirildi");
        }

        public IResult Update(Customer customer) {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomersDetailById(int customerId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(c => c.CustomerId == customerId),"Müşteri getirildi");
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomersDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.Listed);
        }

        public IDataResult<Customer> GetCustomerByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == userId));
        }
    }
}
