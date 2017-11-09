using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Filters;

namespace web.Controllers.Api
{
    [ApiException]
    [ApiAuthorize]
    public class ApiBaseController : BaseController
    {

    }
}