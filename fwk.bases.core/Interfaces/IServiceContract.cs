using Fwk.Exceptions;

namespace Fwk.Bases
{
    /// <summary>
    /// Interfaz de las contratos que utilizan los servicio.-
    /// </summary>
    /// <date>2007-06-23T00:00:00</date>
    /// <author>moviedo</author>
  	public interface IServiceContract

	{

        /// <summary>
        /// Interfaz de entidad 
        /// </summary>
        IBaseEntity IEntity
        {
            get;
           
        }
        /// <summary>
        /// Indica el nombre del servicio. Este nombre debe ser igual a como esta registrado
        /// </summary>
        string ServiceName
        {
            get; set;
        }
        /// <summary>
        /// Informacion del contexto del Request o Response.-
        /// </summary>
		ContextInformation ContextInformation
		{
			get;
			set;
		}
        /// <summary>
        /// Contiene una lista de errores que se pudieran producir en la ejecucion del servicio.-
        /// </summary>
        ServiceError Error
        {
            get; 
            set;
        }
       



        /// <summary>
        /// Establece la informacion de inicio de contexto del Request o Responce .-
        /// </summary>
        void InitializeServerContextInformation();

        /// <summary>
        /// Establece la informacion de context del Request o Responce .-
        /// </summary>
        void InitializeHostContextInformation();
	}


    /// <summary>
    /// 
    /// </summary>
    public interface IRequest:IServiceContract
    {

        /// <summary>
        /// 
        /// </summary>
        //Fwk.Caching.CacheSettings CacheSettings
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Nmbre del proveedor de seguridad
        /// </summary>
        string SecurityProviderName
        {
            get;
            set;
        }

       

    }



}
