using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using TestQuala.Data;
using TestQuala.Data.Models;
using TestQuala.Utilitys;

namespace TestQuala.Business
{

    public class BSucursal : UResult, IBSucursal
    {
        private readonly IDSucursal _dat;
        public BSucursal(IDSucursal dat) //IULogger log
        {
            _dat = dat;
        }


        public Result GetAllSucursales()
        {
            var result = new Result();
            try
            {
                result = _dat.ObtenerSucursales();
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }

        public Result DeleteSucursales(int id)
        {
            var result = new Result();
            try
            {
                result = _dat.EliminarSucursales(id);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }

    }

    public interface IBSucursal
    {
        Result GetAllSucursales();
        Result DeleteSucursales(int id);

    }
}
