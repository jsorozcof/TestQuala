using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TestQuala.Utilitys
{
    //by Ing Faber Orozco
    public class ULogger : IULogger
    {
        private readonly IUConfiguration _cnf;
        private readonly HttpContext _htc;
        private readonly ILogger<ULogger> _logger;
        public ULogger(IHttpContextAccessor htc, IUConfiguration cnf, ILogger<ULogger> logger)
        {
            _htc = htc.HttpContext;
            _cnf = cnf;
            _logger = logger;
        }
        public Result Exception(Exception ex)
        {
            var result = new Result() { Error = 999 };
            var guid = Guid.NewGuid().ToString();
            try
            {
                var currentRequest = _htc.Request;
                var obj = new Object()
                {
                   
                };
               
                _logger.LogCritical($"{DateTime.Now:hh:mm:ss} " + ex.Message);
            }
            catch (Exception exi)
            {
                result.Message = "Sucedio un Error de Inicialización contactese con el administrador";
                result.Values = new ResponseLog()
                {
                    Type = "Exception",
                    Message = exi.Message
                };
                _logger.LogCritical($"{DateTime.Now:hh:mm:ss} " + exi.Message);
            }
            return result;
        }
    }
    public interface IULogger
    {
        Result Exception(Exception ex);
    }
    public class ResponseLog
    {
        public string Guid { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
