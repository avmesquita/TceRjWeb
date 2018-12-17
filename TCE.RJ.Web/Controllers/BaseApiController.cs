using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCE.RJ.Web.Context;

namespace TCE.RJ.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        protected TCERJContexto db = new TCERJContexto();

    }
}
