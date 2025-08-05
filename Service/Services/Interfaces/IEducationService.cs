using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        void Create();
        void Delete();
        void Edit(int id);
        void GetById();
        void GetAll();
        void GetAllWithExpression(Func<object, bool> predicate);




    }
}
