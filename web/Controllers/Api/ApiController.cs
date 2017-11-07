using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using utils;
using utils.ApiResultModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;

namespace web.Controllers.Api
{
    public class ApiController : BaseController
    {
        [Authorize]
        public IActionResult Index()
        {
            string userName = this.GetAuthClainValue("userName");
            
            return GetContent(ApiResult.Write(ApiResultEnum.����ɹ�, userName));
        }
    }
}