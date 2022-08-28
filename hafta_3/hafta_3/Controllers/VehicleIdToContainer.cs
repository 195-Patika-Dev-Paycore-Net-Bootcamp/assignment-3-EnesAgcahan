using EnesAgcahan_Hafta3.Context;
using EnesAgcahan_Hafta3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnesAgcahan_Hafta3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class VehicleIdToContainer : ControllerBase
    {

        private readonly IMapperSession session;
        public VehicleIdToContainer(IMapperSession session)
        {
            this.session = session;
        }

        //id bazlı container listeleme işlemi
        [HttpGet("{id}")]

        public List<container> Get(long id)
        {

            List<container> result = session.Containers.Where(x => x.vehicleid == id).ToList();
            

            return result;
            
        }
    }
}
