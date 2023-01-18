using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Runtime.ExceptionServices;
using Microsoft.Extensions.Configuration;

namespace TestQuala.Utilitys
{

#nullable disable
    public class UConf
    {
        private readonly IConfiguration _cnf;
        private readonly string _env;
        private readonly string _dtap;
        public UConf(IConfiguration cnf)
        {
            _cnf = cnf;
            _env = _cnf.GetSection("AppSettings:Environment").Value;
            _dtap = _cnf.GetSection("AppSettings:Dtap").Value;
        }
        public UConf()
        {
            _cnf = GetCnf();

        }
        public static IConfigurationRoot GetCnf()
        {
            return new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();
        }
        public IConfigurationSection GetSection(string name)
        {
            if (!_cnf.GetSection(name).Exists())
                throw new ArgumentException("No existe la sección " + name, name);
            return _cnf.GetSection(name);
        }
        public string DbConnectionString(string origin = "Main")
        {
            var sec = _cnf.GetConnectionString(origin + _env + _dtap);
            if (string.IsNullOrEmpty(sec))
                throw new ArgumentException("No EXIste el string de conexión " + _env, origin);
            return sec;
        }
     
        public string Url(string name)
        {
            var section = GetSection("AppConnections:" + name + _env + _dtap);
            return section.Value is not null ? section.Value : section.GetSection("Url").Value;
        }
        public string AppId(string name)
        {
            var section = GetSection("AppConnections:" + name + _env + _dtap);
            return section.GetSection("AppId").Value;
        }

        public void AppConnections()
        {
            var claims = new Dictionary<string, string>();
            var selection = GetSection("AppConnections");
            if (selection == null)
                throw new ArgumentException("Error al cargar AppConnections ", "");

        }
    }

    public class UConfiguration : IUConfiguration
    {
        private readonly IConfiguration _cnf;
        public Boolean Production { get; }
        public Boolean Demo { get; }
        private readonly Dictionary<string, string> DicParameters = new();

        public UConfiguration(IConfiguration cnf)
        {
            _cnf = cnf;
            Demo = bool.Parse(_cnf.GetSection("Demo").Value);
            Production = _cnf.GetSection("AppSettings:Dtap").Value == "Production";

        }
        public IConfigurationSection GetSection(string sec) { return new UConf(_cnf).GetSection(sec); }
        public string Url(string name) { return new UConf(_cnf).Url(name); }

        public string DbConnectionString(string origin = "Main") { return new UConf(_cnf).DbConnectionString(origin); }
        public void AppConnections() { new UConf(_cnf).AppConnections(); }

    }
    public interface IUConfiguration
    {
        Boolean Demo { get; }
        Boolean Production { get; }
        IConfigurationSection GetSection(string sec);

        string DbConnectionString(string origin = "Main");
        void AppConnections();
    }

}
