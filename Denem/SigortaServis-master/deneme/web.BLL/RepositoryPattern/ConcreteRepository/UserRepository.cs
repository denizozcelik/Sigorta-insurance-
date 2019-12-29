using System;
using web.BLL.RepositoryPattern.RepositoryBase;
using web.MODEL.Entities;

namespace web.BLL.RepositoryPattern.ConcreteRepository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository()
        {

        }
    }
}
