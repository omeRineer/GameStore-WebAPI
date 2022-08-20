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
    public class GamerManager : IGamerService
    {
        private readonly IGamerDal _gamerDal;

        public GamerManager(IGamerDal gamerDal)
        {
            _gamerDal = gamerDal;
        }

        [ValidationAspect(typeof(GamerValidator))]
        public IResult Add(Gamer gamer)
        {
            _gamerDal.Add(gamer);
            return new SuccessResult();
        }

        public IResult Delete(int gamerId)
        {
            var entity=_gamerDal.Get(x=>x.Id == gamerId);
            _gamerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Gamer>> GetAll()
        {
            var result= _gamerDal.GetAll();
            return new SuccessDataResult<List<Gamer>>(result);
        }

        public IDataResult<Gamer> GetById(int id)
        {
            var result=_gamerDal.Get(x=>x.Id==id);
            return new SuccessDataResult<Gamer>(result);
        }

        [ValidationAspect(typeof(GamerValidator))]
        public IResult Update(Gamer gamer)
        {
            _gamerDal.Update(gamer);
            return new SuccessResult();
        }
    }
}
