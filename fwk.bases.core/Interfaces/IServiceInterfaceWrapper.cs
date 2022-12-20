using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases.ISVC;
using System.Threading.Tasks;

namespace Fwk.Bases
{

	/// <summary>
	/// Interfaz para clases que funcionan como wrappers de interfaces de servicio.
	/// </summary>
	/// <remarks>
	/// Las clases que implementen esta interfaz deben ser capaces de solicitar la  ejecución de servicios de negocio a través de métodos de la intefaz de servicio utilizada, y devolver el resultado del mismo como resultado de la  ejecución.
	/// </remarks>
	/// <date>2007-06-23T00:00:00</date>
    /// <author>moviedo</author>
	public interface IServiceWrapper
	{
      

   

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        string ProviderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SourceInfo { get; set; }
        
        /// <summary>
        /// identificador del proveedor de metadata en el server.Nombre proveedor de megtadatos de servicios en el dispatcher
        /// </summary>
        string ServiceMetadataProviderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ConfigProviderNameWithCultureInfo { get; set; }

        /// <summary>
        /// identificador de aplicacion
        /// </summary>
        string AppId { get; set; }

		/// <summary>
		/// Ejecuta un servicio de negocio.
		/// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
		/// <param name="pData">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con datos de salida del servicio.</returns>
		/// <date>2007-06-23T00:00:00</date>
		/// <author>moviedo</author>
        string ExecuteService( string pServiceName, string pData);

        /// <summary>
        /// Si retorna StringEmpty 
        /// </summary>
        /// <returns></returns>
        DispatcherInfoBE CheckServiceAvailability(bool includeCnnstSrings = false, bool includeAppSettings = false, bool includeMetadata=false);

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="req">Clase que imlementa la interfaz IServiceContract datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que imlementa la interfaz IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        TResponse ExecuteService<TRequest, TResponse>( TRequest req)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new();

        /// <summary>
        /// Ejecuta un servicio de negocio de forma asincrona
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<TResponse> ExecuteServiceAsync<TRequest, TResponse>(TRequest req) where TRequest : IServiceContract
            where TResponse : IServiceContract, new();

        /// <summary>
        ///  Ejecuta un servicio de negocio de forma asincrona y no pasa por la validacion de seguridad basada en jwt
        ///  Este método puede no estar implementado en el Dispatcher y puede que por defecto el ExecuteServiceAsync esté libre de autorizacion
        ///  Pero en caso de que se chequee la autorizacion en ExecuteServiceAsync el método ExecuteServiceAllowedAuth_Async puede ser necesartio 
        ///  que permita ciertos SVC libres : Estos SVC deberian estar en uan white-list de servicios sin control
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<TResponse> ExecuteServiceAuthTokenAsync<TRequest, TResponse>(TRequest req) where TRequest : IServiceContract
            where TResponse : IServiceContract, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="req"></param>
        /// <returns></returns>
        TResponse ExecuteServiceAuthToken<TRequest, TResponse>(TRequest req) where TRequest : IServiceContract
         where TResponse : IServiceContract, new();
        #region [ServiceConfiguration]

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        ServiceConfiguration GetServiceConfiguration(string pServiceName);

        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2010-08-10T00:00:00</date>
        /// <author>moviedo</author>
        ServiceConfigurationCollection GetAllServices();


        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2010-08-10T00:00:00</date>
        /// <author>moviedo</author>
        void SetServiceConfiguration(String pServiceName, ServiceConfiguration pServiceConfiguration);

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration);

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        void DeleteServiceConfiguration(string pServiceName);

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        List<String> GetAllApplicationsId();


        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        //Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo();
       
        #endregion
    }
}
