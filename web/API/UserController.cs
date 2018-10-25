using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

using MyQuiver.Services;
namespace MyQuiver.Web.Api
{
    [ApiController]
    public class UserController : MyController
    {
        public UserController(IUserService service)
        {

        }
    }
}
