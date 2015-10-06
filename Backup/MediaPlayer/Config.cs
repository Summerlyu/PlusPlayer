using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LrcCollection
{
    internal class Config
    {
        public static string GetValue(string AppKey)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(System.AppDomain.CurrentDomain.BaseDirectory + "LrcSet.xml");
                XmlElement element = (XmlElement)document.SelectSingleNode("//appSettings").SelectSingleNode("//add[@key='" + AppKey + "']");
                if (element != null)
                {
                    return element.GetAttribute("value");
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static void SetValue(string AppKey, string AppValue)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(System.AppDomain.CurrentDomain.BaseDirectory + "LrcSet.xml");
                XmlNode node = document.SelectSingleNode("//appSettings");
                XmlElement element = (XmlElement)node.SelectSingleNode("//add[@key='" + AppKey + "']");
                if (element != null)
                {
                    element.SetAttribute("value", AppValue);
                }
                else
                {
                    XmlElement newChild = document.CreateElement("add");
                    newChild.SetAttribute("key", AppKey);
                    newChild.SetAttribute("value", AppValue);
                    node.AppendChild(newChild);
                }
                document.Save(System.AppDomain.CurrentDomain.BaseDirectory + "LrcSet.xml");
            }
            catch
            {
                SetValue(AppKey, AppValue, true);
            }
        }
        public static void SetValue(string AppKey, string AppValue, bool tt)
        {
            XmlDocument document = new XmlDocument();
            XmlNode node = document.CreateNode(XmlNodeType.Element, "configuration", "");
            document.AppendChild(node);
            XmlNode node2 = document.CreateNode(XmlNodeType.Element, "appSettings", "");
            node.AppendChild(node2);
            XmlElement newChild = document.CreateElement("add");
            newChild.SetAttribute("key", AppKey);
            newChild.SetAttribute("value", AppValue);
            node2.AppendChild(newChild);
            document.Save(System.AppDomain.CurrentDomain.BaseDirectory + "LrcSet.xml");
        }
    }
}
