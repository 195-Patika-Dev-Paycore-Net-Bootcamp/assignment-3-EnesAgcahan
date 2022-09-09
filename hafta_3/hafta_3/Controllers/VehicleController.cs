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
    public class VehicleController : ControllerBase
    {

        private readonly IMapperSession session;
        public VehicleController(IMapperSession session)
        {
            this.session = session;
        }
        //Araç listesi
        [HttpGet]
        public List<vehicle> Get()
        {
            List<vehicle> result = session.Vehicles.ToList();
            return result;
        }

        
        //id bazlı araç get işlemi
        [HttpGet("{id}")]
        public vehicle Get(long id)
        {
            vehicle result = session.Vehicles.Where(x => x.id == id).FirstOrDefault();
            return result;
        }
        //Araç güncelleme işlemi
        [HttpPost]
        public void Post([FromBody] vehicle vehicle)
        {
            try
            {
                session.BeginTransaction();
                session.Save(vehicle);
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

        //Araç güncelleme işlemi
        [HttpPut]
        public ActionResult<vehicle> Put([FromBody] vehicle request)
        {
            vehicle vehicle = session.Vehicles.Where(x => x.id == request.id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                
                vehicle.id = request.id;
                vehicle.vehiclename = request.vehiclename;
                vehicle.vehicleplate = request.vehicleplate;



                session.Update(vehicle);

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

        //Araç silme işlemi
        [HttpDelete("{id}")]
        public ActionResult<vehicle> Delete(long id)
        {
            vehicle vehicle = session.Vehicles.Where(x => x.id == id).FirstOrDefault();
            
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(vehicle);
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
