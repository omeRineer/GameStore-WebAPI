using Core.Utilities.ResultTool;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGamerService
    {
        IDataResult<List<Gamer>> GetAll();
        IDataResult<Gamer> GetById(int id);
        IResult Add(Gamer gamer);
        IResult Update(Gamer gamer);
        IResult Delete(int gamerId);
    }
}
