using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Database
{
    /// <summary>
    /// Clase que representa una conexión
    /// Data Source=pcpde0369\SQLEXPRESS;Initial Catalog=Gastos;Integrated Security=True
    /// Data Source=pcpde0369\SQLEXPRESS;Initial Catalog=Gastos;User ID=sa
    /// </summary>
    public class CnnString : Fwk.Bases.BaseEntity
    {
        private string _Name;
        private Boolean _WindowsAutentification;
        private string _DataSource;
        private string _InitialCatalog;
        private string _User;
        private string _Password;
        /// <summary>
        /// 
        /// </summary>
        public CnnString()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pConnectionString"></param>
        public CnnString(String pName, String pConnectionString)
        {
            _Name = pName;
            ParceCnnString(pConnectionString);

        }

        /// <summary>
        /// Establece si la conexion admitira autorizacion integrada (true) o no (false)
        /// </summary>
        [Description("Establece si la conexion admitira autorizacion integrada (true) o no (false)")]
        public System.Boolean WindowsAutentification
        {
            get { return _WindowsAutentification; }
            set { _WindowsAutentification = value; }
        }

        /// <summary>
        /// Nombre de server de datos
        /// </summary>
        [Description("Nombre de server de datos")]
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("Nombre usuario de sql server. Este atributo se setea solo en el caso de una conexiÃ³n con seguridad de SQL Server")]
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        [Description("Nombre de la base de datos")]
        public string InitialCatalog
        {
            get { return _InitialCatalog; }
            set { _InitialCatalog = value; }
        }

        /// <summary>
        /// Nombre de la cadena de conexion
        /// </summary>
        [Description("Nombre de la cadena de conexion")]
        public string Name
        {
            get
            {

                if (string.IsNullOrEmpty(_Name))
                    _Name = string.Concat("Server: ", _DataSource, "DB: ", _InitialCatalog);
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _Name = string.Concat("Server: ", _DataSource, "DB: ", _InitialCatalog);
                else
                    _Name = value;

            }
        }

        /// <summary>
        /// Password de la cadena de conexion
        /// </summary>
        [Description("Password de la cadena de conexion")]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Retorna la cadena de conexion
        /// </summary>
        /// <returns></returns>
        [Description("Retorna la cadena de conexion")]
        public override string ToString()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = _DataSource;// serverName;
            sqlBuilder.InitialCatalog = _InitialCatalog;// databaseName;
            sqlBuilder.IntegratedSecurity = _WindowsAutentification;


            if (_WindowsAutentification == false)
            {
                sqlBuilder.UserID = _User;
                sqlBuilder.Password = _Password;

            }
            //StringBuilder str = new StringBuilder();

            //if (_WindowsAutentification)
            //{
            //    str.Append("Initial Catalog = [DatabaseName];Data Source=[ServerName];Integrated Security=True;");
            //}
            //else
            //{
            //    str.Append("Initial Catalog = [DatabaseName];Data Source=[ServerName];User ID= [User] ;Password= [Password]");
            //    str.Replace("[User]", _User);
            //    str.Replace("[Password]", _Password);
            //}
            //str.Replace("[ServerName]", _DataSource);
            //str.Replace("[DatabaseName]", _InitialCatalog);


            return sqlBuilder.ConnectionString;
        }

        /// <summary>
        /// Setea los miembros de la clase desde una cadena de conexion
        /// </summary>
        /// <param name="pConnectionString"></param>
        private void ParceCnnString(String pConnectionString)
        {

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(pConnectionString);

            _InitialCatalog = sqlBuilder.InitialCatalog;
            _DataSource = sqlBuilder.DataSource;
            _User = sqlBuilder.UserID;
            _Password = sqlBuilder.Password;
            _WindowsAutentification = sqlBuilder.IntegratedSecurity;

            //List<string> list = new List<string>(pConnectionString.Split(';'));
            //_InitialCatalog = GetValue(list, "Initial Catalog");
            //if (_InitialCatalog.Length == 0)
            //    _InitialCatalog = GetValue(list, "Database");

            //_DataSource = GetValue(list, "Data Source");
            //if (_DataSource.Length == 0)
            //    _DataSource = GetValue(list, "Server");

            //_User = GetValue(list, "User ID");
            //if (_User.Length == 0)
            //    _User = GetValue(list, "User");

            //_Password = GetValue(list, "Password");
            //if (_Password.Length == 0)
            //    _Password = GetValue(list, "pwd");

            //String wIntegratedSecurity = GetValue(list, "Integrated Security");
            //if (wIntegratedSecurity.Trim().ToLower() == "true" || wIntegratedSecurity.Trim().ToLower() == "SSPI")
            //    _WindowsAutentification = true;
            //else
            //    _WindowsAutentification = false;

        }


        /// <summary>
        /// Obtiene un valor o parametro de cadena de conexion 
        /// Ej: Data Source=10.10.65.12\SQLEXPRESS;
        /// Ej: Server = =10.10.65.12\SQLEXPRESS;
        /// </summary>
        /// <param name="pCnnStringList"></param>
        /// <param name="pValueName"></param>
        /// <returns></returns>
        //private string GetValue(List<string> pCnnStringList, String pValueName)
        //{
        //    String[] val = null;
        //    foreach (String s in pCnnStringList)
        //    {
        //        if (s.Contains(pValueName))
        //        {
        //            val = s.Split('=');
        //            if (String.Equals(val[0].Trim().ToLower(), pValueName.Trim().ToLower()))
        //                return val[1].Trim();
        //            else
        //                return val[0].Trim();
        //        }
        //    }
        //    return String.Empty;
        //}
    }
}
