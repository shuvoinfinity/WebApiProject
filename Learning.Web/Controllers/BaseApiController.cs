using Learning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        private ILearningRepository _repo;

        public BaseApiController(ILearningRepository repo)
        {
            _repo = repo;
        }

        protected ILearningRepository TheRepository { get
            {
                return _repo;
            }
        }
    }
}
