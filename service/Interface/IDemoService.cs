using service.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace service.Interface
{
    public interface IDemoService
    {
        IQueryable<UserModel> Hello();

        void Insert(UserModel user);
    }
}
