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
using service.DAL;

namespace web.Controllers.Api
{
    public class ApiController : ApiBaseController
    {
        //public ApiController(DBHelperContext ctx) : base(ctx)
        //{
        //}

        public IActionResult Index()
        {
            return GetContent(ApiResult.Write(ApiResultEnum.SUCCESS));
        }
    }
}