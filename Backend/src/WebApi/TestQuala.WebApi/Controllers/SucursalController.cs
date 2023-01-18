using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestQuala.Business;
using TestQuala.Utilitys;

namespace TestQuala.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SucursalController : Controller
    {

        private readonly IBSucursal _bus;
        private readonly IULogger _exec;

        public SucursalController(IBSucursal bus, IULogger exec)
        {
            _bus = bus;
            _exec = exec;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Route("GetAllSucursales")]
        public ActionResult GetAllSucursales()
        {
            Result res;
            try
            {
                res = _bus.GetAllSucursales();
            }
            catch (Exception ex)

            {
                res = _exec.Exception(ex);
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public ActionResult DeleteSucursal(int id)
        {
            Result res;
            try
            {
                res = _bus.DeleteSucursales(id);
            }
            catch (Exception ex)

            {
                res = _exec.Exception(ex);
            }
            return Ok(res);
        }


    }

}
