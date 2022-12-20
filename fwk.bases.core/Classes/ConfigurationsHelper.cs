using fwk.bases.services;
using Fwk.Database;
using Fwk.Security.Cryptography;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace Fwk.Bases
{
    /// <summary>
    /// Clase que expone atributos de configuracion utilizados por el framework.-
    /// </summary>
    public static class ConfigurationsHelper
    {
        private static string _HostApplicationName;

        /// <summary>
        /// Indica el nombre de la aplicacion que esta corriendo y utilizando el framework
        /// Ejemplo: Nombre de un servicio, nombre de sitio web, nombre de aplicacion de windows
        /// Este nombre lo utilizanlos componentes del framework para establecer el source u origen de 
        /// eventos lanzado por la aplicacion
        /// </summary>
        public static string HostApplicationName
        {
            get { return _HostApplicationName; }
            set { _HostApplicationName = value; }
        }

        ///// <summary>
        ///// Indica la configuracion del wrapper en el .config .-
        ///// </summary>
        //public static String WrapperSetting
        //{
        //    get { return Properties.Settings.Default.Wrapper; }

        //}



        ///// <summary>
        ///// Indica el nombre del archivo de remoting que utiliza el cliente en el .config .-
        ///// </summary>
        //public static String RemotingConfigFilePathSetting
        //{
        //    get { return Properties.Settings.Default.DispatcherRemotingConfigFilePath; }

        //}
        ///// <summary>
        ///// Indica direccion URL para conectarce a un servicio web que utiliza .-
        ///// </summary>
        //public static String WebServiceDispatcherUrlSetting
        //{
        //    get { return Properties.Settings.Default.WebServiceDispatcherUrl; }

        //}


        ///// <summary>
        ///// ServiceConfigurationFilePath
        ///// </summary>
        //public static String ServiceConfigurationSourceName
        //{
        //    get { return Properties.Settings.Default.ServiceConfigurationSourceName; }

        //}
        ///// <summary>
        ///// ServiceConfigurationManagerType
        ///// </summary>
        //public static String ServiceConfigurationManagerType
        //{
        //    get { return Properties.Settings.Default.ServiceConfigurationManagerType; }

        //}
      

        public static string ServiceDispatcherConnection { get; set; }

      


      
    }

    /// <summary>
    /// 
    /// </summary>
    public class CnnStringHelper
    {
      
        static ICnnStringService CnnStringService;

       
        public static void InitHelpers(ICnnStringService cnnStringService)
        {
            CnnStringService = cnnStringService;
        }
        /// <summary>
        /// retorna una SqlConnection del mediante el servicio inyectado ICnnStringService 
        /// </summary>
        /// <param name="cnnName"></param>
        /// <returns></returns>
        public static ConnectionString get_cnnString_byName(string cnnName)
        {
            return CnnStringService.get_cnnString_byName(cnnName);


        }
    }
}
