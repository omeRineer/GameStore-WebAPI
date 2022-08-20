using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Authorizaton;
using Core.Aspects.Validation;
using Core.Utilities.Identities.Claims;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
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
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult();
        }

        public IResult Delete(int companyId)
        {
            var entity= _companyDal.Get(x=>x.Id==companyId);
            _companyDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Company>> GetAll()
        {
            var result= _companyDal.GetAll();
            return new SuccessDataResult<List<Company>>(result);
        }

        public IDataResult<Company> GetById(int companyId)
        {
            var result=_companyDal.Get(x=>x.Id ==companyId);
            return new SuccessDataResult<Company>(result);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult();
        }
    }
}
