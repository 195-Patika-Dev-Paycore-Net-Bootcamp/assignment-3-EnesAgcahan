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
    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession session;
        public ContainerController(IMapperSession session)
        {
            this.session = session;
        }
        //Container listesi 
        [HttpGet]
        public List<container> Get()
        {
            List<container> result = session.Containers.ToList();
            return result;
        }
        //İd bazlı container get işlemi
        [HttpGet("{id}")]
        public container Get(long id)
        {
            container result = session.Containers.Where(x => x.id == id).FirstOrDefault();
            return result;
        }
        //Container için post işlemleri
        [HttpPost]
        public void Post([FromBody] container container)
        {
            try
            {
                session.BeginTransaction();
                session.Save(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();

            }
            finally
            {
                session.CloseTransaction();
            }
        }
        //Container güncelleme işlemi
        [HttpPut]
        public ActionResult<container> Put([FromBody] container request)
        {
            container container = session.Containers.Where(x => x.id == request.id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                
                container.id = request.id;
                container.containername = request.containername;
                container.latitude = request.latitude;
                container.longitude = request.longitude;
                container.vehicleid = request.vehicleid;



                session.Update(container);

                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                
            }
            finally
            {
                session.CloseTransaction();
            }


            return Ok();
        }
        //Container silme işlemi
        [HttpDelete("{id}")]
        public ActionResult<container> Delete(long id)
        {
            container container = session.Containers.Where(x => x.id == id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                
            }
            finally
            {
                session.CloseTransaction();
            }

            return Ok();
        }

    }
}
