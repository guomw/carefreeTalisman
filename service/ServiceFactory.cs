using service.Interface;
using service.Interface.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using service.DAL;

namespace service
{
    public class ServiceFactory<T>
    {
        public static T Factory(DBHelperContext context)
        {            
            if (typeof(T) == typeof(IDemoService))
                return (T)DemoServiceImpl.Instance(context);

            throw new InvalidCastException("没有找到" + typeof(T) + "的实现");
        }
    }
}
