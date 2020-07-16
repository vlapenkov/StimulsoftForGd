using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Shared
{
   public class SettingsTransformer
    {
        /// <summary>
        /// Изменить строку настройку (по сути mrt-файл)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
       public string Transform(string source)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(source);
            var nodePathData = xmlDoc.SelectSingleNode("/StiSerializer/Dictionary/Databases/XML/PathData");
            var nodeResources = xmlDoc.SelectSingleNode("/StiSerializer/Dictionary/Resources");
            XmlNode nodeVariables = xmlDoc.SelectSingleNode("/StiSerializer/Dictionary/Variables");
            nodePathData.InnerText = "{pathToUri}";
            nodeResources.InnerText = "";
            nodeVariables.Attributes["count"].Value = "1";
            nodeResources.Attributes["count"].Value = "0";

            XmlNode nodeValue = xmlDoc.CreateNode(XmlNodeType.Element, "value", "");
            nodeValue.InnerText = ",pathUrl,pathUrl,pathUrl,System.String,http://localhost:443,False,False,False,False";
            nodeVariables.AppendChild(nodeValue);
            return xmlDoc.OuterXml;
            
        }
    }
}
