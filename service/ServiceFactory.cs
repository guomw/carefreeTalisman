using service.Interface;
using service.Interface.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
    public class ServiceFactory<T> where T : new()
    {

        public static T Factory()
        {
            T t = new T();
            if (typeof(T) == typeof(IDemoService))
                return (T)DemoServiceImpl.Instance;

            return t;
        }
    }
}
