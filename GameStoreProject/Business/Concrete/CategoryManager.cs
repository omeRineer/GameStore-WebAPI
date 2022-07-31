using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Authorizaton;
using Core.Aspects.Validation;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(int categoryId)
        {
            var entity=_categoryDal.Get(x=>x.Id == categoryId);
            _categoryDal.Delete(entity);
            return new SuccessResult();
        }

        [Authorize]
        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(x => x.Id == id);
            return new SuccessDataResult<Category>(result);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
