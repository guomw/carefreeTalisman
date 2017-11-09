using service.Interface;
using service.Interface.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
    public class ServiceFactory<T>
    {
        public static T Factory()
        {            
            if (typeof(T) == typeof(IDemoService))
                return (T)DemoServiceImpl.Instance;

            throw new InvalidCastException("没有找到" + typeof(T) + "的实现");
        }
    }
}
