using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
//using Newtonsoft.Json;
namespace Fwk.HelperFunctions
{
 
   
    /// <summary>
    /// Esta clase ayuda con los problemas que tienen que ver
    /// con la serialización de objetos.
    /// </summary>
    public class SerializationFunctions
    {
      

        

        #region -- Xml Serialization using Xml --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pXmlData"></param>
        /// <returns></returns>
        public static object DeserializeFromXml(Type pObjType, string pXmlData)
        {
            XmlSerializer wSerializer;
            UTF8Encoding wEncoder = new UTF8Encoding();
            MemoryStream wStream = new MemoryStream(wEncoder.GetBytes(pXmlData));

            wSerializer = new XmlSerializer(pObjType);
            return wSerializer.Deserialize(wStream);
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTipo"></param>
        /// <param name="pXml"></param>
        /// <returns></returns>
        //public static object DeserializeFromXml2(Type pTipo, string pXml)
        //{
        
            //XmlSerializer wSerializer;
            //StringReader wStrSerializado = new StringReader(pXml);
            //XmlTextReader wXmlReader = new XmlTextReader(wStrSerializado);
            ////XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();
            //object wResObj = null;

            ////wNameSpaces.Add(String.Empty, String.Empty);
            //wSerializer = new XmlSerializer(pTipo);
            //wResObj = wSerializer.Deserialize(wXmlReader);

            //return wResObj;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        //public static string SerializeToXml(object pObj)
        //{
        //    XmlSerializer wSerializer;
        //    StringWriter wStwSerializado = new StringWriter();
        //    XmlTextWriter wXmlWriter = new XmlTextWriter(wStwSerializado);
        //    XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

        //    wXmlWriter.Formatting = Formatting.Indented;
        //    wNameSpaces.Add(String.Empty, String.Empty);

        //    wSerializer = new XmlSerializer(pObj.GetType());
        //    wSerializer.Serialize(wXmlWriter, pObj, wNameSpaces);


        //    return wStwSerializado.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", String.Empty);
        //}

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <returns>Representación en XML del objeto</returns>
        public static string SerializeToXml(object pObj)
        {
            return Serialize(pObj, false);
        }

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <param name="pRemoveDeclaration">Indica si se debe remover el nodo de declaración</param>
        /// <returns>Representación en XML del objeto</returns>
        public static string Serialize(object pObj, bool pRemoveDeclaration)
        {
            XmlDocument wDoc = new XmlDocument();
            wDoc.Load(GetStream(pObj));

            if (pRemoveDeclaration && wDoc.ChildNodes.Count > 0 && wDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                wDoc.RemoveChild(wDoc.FirstChild);
            }

            return wDoc.InnerXml;
        }


        /// <summary>
        /// Devuelve un stream formado a partir del objeto enviado por parámetro.
        /// </summary>
        /// <param name="pObj">Objeto para extraer stream</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream GetStream(object pObj)
        {
            XmlSerializer wSerializer;
            MemoryStream wStream = new MemoryStream();

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wStream, pObj);

            wStream.Position = 0;

            return wStream;
        }

        #endregion

        [Obsolete("En la version 3.1.0.4  use SerializeObjectToJson")]
        /// <summary>
        /// Serializar un objeto utilizando Newtonsoft.Json.SerializeObject
        /// <code>
        /// </code>
        /// </summary>
        /// <param name="objType">typeOf(type)</param>
        /// <param name="obj">Objetc</param>
        /// <returns></returns>
        public static string SerializeObjectToJson_Newtonsoft(object obj)
        {
            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj, new JsonSerializerSettings());

            //return json;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serealiza pobject to json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObjectToJson<T>(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
            //return JsonConvert.SerializeObject(obj);
            
        }
        
       

        /// <summary>
        /// deserialize an instance of type T from JSON
        /// </summary>
        /// <returns></returns>
        public static T DeSerializeObjectFromJson<T>(string json)
        {
            return (T)System.Text.Json.JsonSerializer.Deserialize<T>(json);

        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTypeNameOld"></param>
        /// <param name="pTypeNameNew"></param>
        /// <param name="pXml"></param>
        /// <returns></returns>
        public static string ReplaseTypeNameForSerialization(Type pTypeNameOld, Type pTypeNameNew, String pXml)
        {
            System.Text.StringBuilder strXml = new System.Text.StringBuilder(pXml);

            strXml.Replace("<" + pTypeNameOld.Name + ">", "<" + pTypeNameNew.Name + ">");
            strXml.Replace("</" + pTypeNameOld.Name + @">", "</" + pTypeNameNew.Name + @">");

            return strXml.ToString();
        }
    }


}