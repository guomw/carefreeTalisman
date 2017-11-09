using service.entity;
using System;
using System.Collections.Generic;
using System.Text;
using service.DAL;

namespace service.repository
{
    public class UserRepository : RepositoryBase<UserModel>
    {
        public UserRepository(DBHelperContext context) : base(context)
        {
        }
    }
}
