using Business.Abstract;
using Core.Utilities.ResultTool;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyService _companyService;

        public CompanyManager(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IResult Add(Company company)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int companyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Company> GetById(int companyId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
