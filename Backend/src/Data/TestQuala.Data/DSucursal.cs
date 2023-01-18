using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using TestQuala.Data.Models;
using TestQuala.Entities;
using TestQuala.Utilitys;

namespace TestQuala.Data
{
    public class DSucursal : UResult, IDSucursal
    {
        private readonly ContextMain _ctx;
        private readonly string msgErr = "Error Almacenando Datos";

        public DSucursal(ContextMain ctx)
        {
            _ctx = ctx;
        }

        public Result AgregarSucursal()
        {
            throw new NotImplementedException();
        }

        public Result ObtenerSucursales()
        {
            var result = new Result() { Error = 1 };
            try
            {
                var query = from ms in _ctx.MonedaSucursals 
                            join m in _ctx.Moneda on ms.IdModena equals m.Id
                            orderby m.Id descending
                            select new DtoSucursal
                            { 
                               Id = ms.Id,
                               Codigo = ms.Codigo,
                               Descripcion = ms.Descripcion,
                               Direccion = ms.Direccion,
                               Identificacion = ms.Identificacion,
                               Moneda = m.Codigo,
                               IdMoneda = m.Id

                            };


                result = new Result
                {
                    Error = 0,
                    Message = "Exito",
                    Values = query.ToList()
                };

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }

        public Result EliminarSucursales(int id)
        {
            var result = new Result() { Error = 1 };
            try
            {
                var s = _ctx.MonedaSucursals.FirstOrDefault(x => x.Id == id);
                if (s is not null) 
                {
                    _ctx.MonedaSucursals.Remove(s);
                    _ctx.SaveChanges();

                }
                else return result = new Result {  Error = 1, Message = "NO existe",  Values = null  };



                result = new Result
                {
                    Error = 0,
                    Message = "Exito",
                    Values = null
                };

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }

        public Result ObtenerSucursalPorId()
        {
            throw new NotImplementedException();
        }
    }

    public interface IDSucursal
    {
        Result ObtenerSucursales();
        Result ObtenerSucursalPorId();
        Result AgregarSucursal();
        Result EliminarSucursales(int id);
    }
}
