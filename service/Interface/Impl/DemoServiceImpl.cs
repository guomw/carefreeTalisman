using System;
using System.Collections.Generic;
using System.Text;

namespace service.Interface.Impl
{
    public class DemoServiceImpl : IDemoService
    {
        private static DemoServiceImpl instance = new DemoServiceImpl();
        public static IDemoService Instance
        {
            get
            {
                return instance;
            }
        }

        public string Hello()
        {
            return "hello world";
        }
    }
}
