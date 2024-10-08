using System;
using System.IO;

using System.Xml;

using System.Text;

namespace Fwk.HelperFunctions
{



    /// <summary>
    /// Summary description for FileFunctions.
    /// </summary>
    public static class FileFunctions
    {
        /// <summary>
        /// Obtiene el texto de un TextReader
        /// </summary>
        /// <param name="reader">TextReader</param>
        /// <returns></returns>
        public static string GetTextFromReader(TextReader reader)
        {
            StringBuilder list = new StringBuilder();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Append(line);

            }
            reader.Dispose();
            return list.ToString();
        }


        /// <summary>
        /// Abre un archivo de texto
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <returns></returns>
        public static string OpenTextFile(string pFileName)
        {
            using (StreamReader sr = File.OpenText(pFileName))
            {
                string retString = sr.ReadToEnd();



                return retString;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
        public static string PadPath(string pPath)
        {
            string retString = pPath.EndsWith("\\") ? pPath : pPath + "\\";
            return retString;
        }

        /// <summary>
        /// Agrega texto a un archivo. Este metoo sobreescribe el archivo existente.
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <param name="pContent">Contenido del archivo</param>
        public static void SaveTextFile(string pFileName, string pContent)
        {
            //StreamWriter sw = new StreamWriter(pFileName, false);
            using (StreamWriter sw = File.AppendText(pFileName))
            {
                sw.Write(pContent);

            }
        }

        /// <summary>
        /// Agrega el texto a un archivo. Si el archivo no existe, este método crea uno nuevo. 
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <param name="pContent">Contenido del archivo</param>
        /// <param name="pAppend">Determina si se van a agregar datos al archivo. 
        /// Si ya existe el archivo y append es false, el archivo se sobrescribirá. 
        /// Si ya existe el archivo y append es true, los datos se anexarán al archivo. De lo contrario, se crea un nuevo archivo. 
        /// </param>
        public static void SaveTextFile(string pFileName, string pContent, bool pAppend)
        {
            SaveTextFile(pFileName, pContent);
            //using (StreamWriter sw = new StreamWriter(pFileName, pAppend))
            //{
            //    sw.Write(pContent);
            //    //sw.Close();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pContent"></param>
        public static void SaveBinaryFile(string pFileName, byte[] pContent)
        {
            FileStream fs = new FileStream(pFileName, FileMode.Create, FileAccess.Write);
            fs.Write(pContent, 0, pContent.Length);
            fs.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public static byte[] OpenBinaryFile(string pFileName)
        {
            FileStream fs;
            fs = new FileStream(pFileName, FileMode.Open, FileAccess.Read);

            // Tomo los bytes
            byte[] content = new byte[fs.Length];
            fs.Read(content, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();

            return content;
        }

        /// <summary>
        /// Establece una nueva configuracion de seguridad apra el archivo.-
        /// Ej: AddFileSecurity(fileInfo.FullName, @"ALCO\moviedo",FileSystemRights.FullControl, AccessControlType.Allow);
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pAccount">ej: @"ALCO\moviedo"</param>
        /// <param name="pRights"><see cref="FileSystemRights"/> </param>
        /// <param name="pControlType"><see cref="AccessControlType"/></param>
        //public static void AddFileSecurity(string pFileName, string pAccount,
        //FileSystemRights pRights, AccessControlType pControlType)
        //{
        //    // Actual configuracion de seguridad
        //    System.Security.AccessControl.FileSecurity wFileSecurity = File.GetAccessControl(pFileName);

        //    wFileSecurity.AddAccessRule(new FileSystemAccessRule(pAccount, pRights, pControlType));

        //    // Establece la nueva configuracion de seguridad
        //    File.SetAccessControl(pFileName, wFileSecurity);

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pAccount">ej: @"ALCO\moviedo"</param>
        /// <param name="pRights"><see cref="FileSystemRights"/></param>
        /// <param name="pControlType"><see cref="AccessControlType"/></param>
        //public static void RemoveFileSecurity(string pFileName, string pAccount,
        //FileSystemRights pRights, AccessControlType pControlType)
        //{
        //    //Actual configuracion de seguridad
        //    System.Security.AccessControl.FileSecurity wFileSecurity = File.GetAccessControl(pFileName);

        //    // Elimina FileSystemAccessRule de la config de seguridad (wFileSecurity)
        //    wFileSecurity.RemoveAccessRule(new FileSystemAccessRule(pAccount, pRights, pControlType));

        //    File.SetAccessControl(pFileName, wFileSecurity);

        //}


        /// <summary>
        /// Tipos de filtro standars para un objeto <see cref="OpenFileDialog"/>
        /// </summary>
        public static class OpenFilterEnums
        {

            static string _OpenTextAndXmlFilter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|All files (*.*)|*.*";

            public static string OpenTextAndXmlFilter
            {
                get { return _OpenTextAndXmlFilter; }
            }

            static string _OpenImageFilter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.PNG;*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            /// <summary>
            /// "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.PNG;*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
            /// </summary>
            public static string OpenImageFilter
            {
                get { return _OpenImageFilter; }

            }


            static string _OpenAllXmlFilesFilter = "Xml Files(*.XSD;*.XML;*.CONFIG;*.resx;)|*.XSD;*.XML;*.CONFIG;*.resx;|All files (*.*)|*.*";

            /// <summary>
            /// "Xml Files(*.XSD;*.XML;*.CONFIG;)|*.XSD;*.XML;*.CONFIG;|All files (*.*)|*.*"
            /// </summary>
            public static string OpenAllXmlFilesFilter
            {
                get { return _OpenAllXmlFilesFilter; }

            }

            static string _OpenXmlFilter = "Xml Files(*.xml)|*.xml|All files (*.*)|*.*";

            /// <summary>
            /// "Xml Files(*.XSD;*.XML;*.CONFIG;)|*.XSD;*.XML;*.CONFIG;|All files (*.*)|*.*"
            /// </summary>
            public static string OpenXmlFilter
            {
                get { return _OpenXmlFilter; }

            }
            static string _OpenAssembliesFilter = "DLL Files (*.dll;*.exe)|*.dll;*.exe|All Files (*.*)|*.*";

            /// <summary>
            /// "DLL Files (*.dll;*.exe)|*.dll;*.exe|All Files (*.*)|*.*"
            /// </summary>
            public static string OpenAssembliesFilter
            {
                get { return _OpenAssembliesFilter; }

            }

        }
    }


}