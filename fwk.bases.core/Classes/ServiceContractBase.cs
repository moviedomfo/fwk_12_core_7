using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.HelperFunctions;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Exceptions;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base con el comportamiento general de los Request y Responses
    /// </summary>
    /// <typeparam name="T"> <see cref="IEntity"/> </typeparam>
    public class ServiceContractBase<T> : IServiceContract where T : IBaseEntity, new()
    {

        T m_Data = new T();
        
        ContextInformation m_Context = new ContextInformation();

       

        /// <summary>
        /// Contiene una lista de errores que se pudieran producir en la ejecucion del servicio.-
        /// </summary>
        public ServiceError Error { get; set; }


        /// <summary>
        /// Indica el nombre del servicio. Este nombre debe ser igual a como esta registrado
        /// </summary>
        public string ServiceName { get; set; }
      

        #region [BusinessData]

        /// <summary>
        /// Clase que implementa <see cref="IEntity"/>
        /// </summary>
        public T BusinessData
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        


      
        #endregion

        #region [Request/Response]
     
       
     
        #endregion

        #region [Context Information]

        /// <summary>
        /// Informacion de contexto hacerca del Request del servio.-
        /// </summary>
        public ContextInformation ContextInformation
        {
            get { return m_Context; }
            set { m_Context = value; }
        }



        /// <summary>
        /// Establece la informacion de contexto del Request o Response del lado del despachador de servicios.-
        /// </summary>
        public void InitializeServerContextInformation()
        {
            if (m_Context == null)
                m_Context = new ContextInformation();

            m_Context.ServerTime = DateTime.Now;
            m_Context.ServerName = Environment.MachineName;

        }

        /// <summary>
        /// Establece la informacion de contexto del Request o Response del lado del cliente.-
        /// </summary>
                   
        public void InitializeHostContextInformation()
        {
            if (m_Context == null)
                m_Context = new ContextInformation();

            m_Context.HostName = Environment.MachineName;
            if (string.IsNullOrEmpty(m_Context.UserId))
                m_Context.UserId = Environment.UserName;

            m_Context.HostTime = DateTime.Now;
           
        }


       


        #endregion





        #region IServiceContract Members
        /// <summary>
        /// GetBusinessDataObject
        /// </summary>
        public IBaseEntity IEntity
        {
            get
            {
                return m_Data;
            }

        }

        
        #endregion


    }
}

