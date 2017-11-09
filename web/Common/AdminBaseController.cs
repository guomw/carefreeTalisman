using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using service.DAL;
using web.Filters;

/// <summary>
/// 
/// </summary>
namespace web.Controllers
{
    [AdminException]
    [AdminAuthorize]
    public class AdminBaseController : BaseController
    {
        public AdminBaseController(DBHelperContext ctx) : base(ctx)
        {
        }
    }
}