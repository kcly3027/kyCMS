﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Xml;

namespace KyCMS.Common.Globalization.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public static class ResXResourceFileHelper
    {
        #region Methods
        /// <summary>
        /// Parses the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="category">The category.</param>
        public static void Parse(string fileName, out string culture, out string category)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetFileName(fileName));
            if (!fileNameWithoutExtension.Contains("."))
            {
                culture = fileNameWithoutExtension;
                category = string.Empty;
            }
            else
            {
                var pointIndex = fileNameWithoutExtension.LastIndexOf('.');
                culture = fileNameWithoutExtension.Substring(pointIndex + 1);
                category = fileNameWithoutExtension.Substring(0, pointIndex);
            }
        }
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string GetFileName(string category, string culture)
        {
            if (string.IsNullOrEmpty(category) && category.Trim() == string.Empty)
            {
                return culture + ".resx";
            }
            else
            {
                return category + "." + culture + ".resx";
            }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResXResource
    {
        #region Fields
        private static System.Threading.ReaderWriterLock locker = new ReaderWriterLock();

        private string path;
        #endregion

        #region .ctor
        public ResXResource(string path)
        {
            this.path = path;
        }
        #endregion

        #region Methods

        private void CreateDir()
        {
            if (Directory.Exists(path) == false)
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (IOException exception)
                {
                    throw new DirectoryCreateException(exception);
                }
            }
        }

        /// <summary>
        /// Removes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public bool RemoveCategory(string category, string culture)
        {
            locker.AcquireWriterLock(Timeout.Infinite);
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    string culture1;
                    string category1;
                    ResXResourceFileHelper.Parse(file, out culture1, out category1);
                    if (StringExtensions.EqualsOrNullEmpty(category, category1, StringComparison.CurrentCultureIgnoreCase) && StringExtensions.EqualsOrNullEmpty(culture1, culture, StringComparison.CurrentCultureIgnoreCase))
                    {
                        File.Delete(file);
                    }
                }
                return true;
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        public void AddCategory(string category, string culture)
        {
            string filePath = Path.Combine(this.path, ResXResourceFileHelper.GetFileName(category, culture));

            XmlDocument document = GetResxDocument(filePath);

            if (document == null)
            {
                document = CreateResXDocument();
            }
            locker.AcquireWriterLock(Timeout.Infinite);
            try
            {
                document.Save(filePath);
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ElementCategory> GetCategories()
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    string culture;
                    string category;
                    ResXResourceFileHelper.Parse(file, out culture, out category);

                    if (!string.IsNullOrEmpty(category))
                    {
                        yield return new ElementCategory() { Category = category, Culture = culture };
                    }

                }
            }
        }
        /// <summary>
        /// Gets the cultures.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CultureInfo> GetCultures()
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    string culture;
                    string category;
                    ResXResourceFileHelper.Parse(file, out culture, out category);
                    if (!string.IsNullOrEmpty(culture))
                    {
                        yield return new CultureInfo(culture);
                    }
                }
            }
        }


        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Element> GetElements()
        {
            locker.AcquireWriterLock(Timeout.Infinite);
            try
            {
                List<Element> elements = new List<Element>();
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path);

                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileName = files[i];
                        if (fileName.EndsWith(".resx"))
                        {

                            XmlDocument doc = new XmlDocument();
                            doc.Load(files[i]);
                            string culture;
                            string category;
                            ResXResourceFileHelper.Parse(fileName, out culture, out category);

                            foreach (XmlNode xn in doc.SelectNodes("root/data"))
                            {
                                    Element element = new Element();
                                    element.Name = xn.Attributes["name"].Value;
                                    element.Value = XMLConvertStr(xn.FirstChild.InnerXml);
                                    element.Category = category;
                                    element.Culture = culture;
                                    elements.Add(element);
                            }
                        }
                    }
                }
                return elements;
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public Element GetElement(string name, string category, string culture)
        {
            locker.AcquireReaderLock(Timeout.Infinite);
            try
            {
                string filePath = Path.Combine(this.path, ResXResourceFileHelper.GetFileName(category, culture));

                XmlDocument document = GetResxDocument(filePath);

                if (document == null)
                {
                    return null;
                }

                foreach (XmlNode xn in document.SelectNodes("root/data"))
                {
                    if (StringExtensions.EqualsOrNullEmpty(xn.Attributes["name"].Value, name, StringComparison.OrdinalIgnoreCase))
                    {
                        Element element = new Element();
                        element.Name = xn.Attributes["name"].Value;
                        element.Value = XMLConvertStr(xn.FirstChild.InnerXml);
                        element.Category = category;
                        element.Culture = culture;
                        return element;
                    }
                }
                return null;
            }
            finally
            {
                locker.ReleaseReaderLock();
            }

        }

        /// <summary>
        /// Adds the resource.
        /// </summary>
        /// <param name="element">The element.</param>
        public void AddResource(Element element)
        {
            locker.AcquireWriterLock(Timeout.Infinite);
            try
            {
                CreateDir();
                string filePath = Path.Combine(this.path, ResXResourceFileHelper.GetFileName(element.Category, element.Culture));
                XmlDocument document = GetResxDocument(filePath);

                if (document == null)
                {
                    document = CreateResXDocument();
                }
                XmlNode exists = null;
                foreach (XmlNode xn in document.SelectNodes("root/data"))
                {
                    if (StringExtensions.EqualsOrNullEmpty(xn.Attributes["name"].Value, element.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = xn;
                        break;
                    }
                }
                if (exists == null)
                {
                    XmlElement xe = document.CreateElement("data");
                    xe.SetAttribute("name", element.Name);
                    xe.SetAttribute("xml:space", "preserve");
                    xe.InnerXml = string.Format("<value>{0}</value>", StrConvertXML(element.Value));
                    document.SelectSingleNode("root").AppendChild(xe);
                    document.Save(filePath);
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }

        }

        /// <summary>
        /// Updates the resource.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public bool UpdateResource(Element element)
        {
            locker.AcquireWriterLock(Timeout.Infinite);
            try
            {
                CreateDir();
                string filePath = Path.Combine(this.path, ResXResourceFileHelper.GetFileName(element.Category, element.Culture));

                XmlDocument document = GetResxDocument(filePath);

                if (document == null)
                {
                    return false;
                }

                XmlNode newElement = null;
                foreach (XmlNode xn in document.SelectNodes("root/data"))
                {
                    if (StringExtensions.EqualsOrNullEmpty(xn.Attributes["name"].Value, element.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        newElement = xn;
                        break;
                    }
                }

                if (newElement == null)
                {
                    return false;
                }
                newElement.SelectSingleNode("value").Value = element.Value;
                document.Save(filePath);

                return true;
            }
            finally
            {
                locker.ReleaseWriterLock();
            }

        }

        /// <summary>
        /// Removes the resource.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public bool RemoveResource(Element element)
        {
            locker.AcquireWriterLock(Timeout.Infinite);
            try
            {
                CreateDir();
                string filePath = Path.Combine(this.path, ResXResourceFileHelper.GetFileName(element.Category, element.Culture));

                XmlDocument document = GetResxDocument(filePath);

                if (document == null)
                {
                    return false;
                }
                XmlNode newElement = null;
                foreach (XmlNode xn in document.SelectNodes("root/data"))
                {
                    if (StringExtensions.EqualsOrNullEmpty(xn.Attributes["name"].Value, element.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        newElement = xn;
                        break;
                    }
                }
                if (newElement == null)
                {
                    return false;
                }
                document.RemoveChild(newElement);
                document.Save(filePath);

                return true;

            }
            finally
            {
                locker.ReleaseWriterLock();
            }

        }

        private XmlDocument GetResxDocument(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            return xmlDocument;
        }

        private XmlDocument CreateResXDocument()
        {
            string resheader = @"<root>
                                    <xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">
                                    <xsd:import namespace=""http://www.w3.org/XML/1998/namespace"" />
                                    <xsd:element name=""root"" msdata:IsDataSet=""true"">
                                      <xsd:complexType>
                                        <xsd:choice maxOccurs=""unbounded"">
                                          <xsd:element name=""metadata"">
                                            <xsd:complexType>
                                              <xsd:sequence>
                                                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" />
                                              </xsd:sequence>
                                              <xsd:attribute name=""name"" use=""required"" type=""xsd:string"" />
                                              <xsd:attribute name=""type"" type=""xsd:string"" />
                                              <xsd:attribute name=""mimetype"" type=""xsd:string"" />
                                              <xsd:attribute ref=""xml:space"" />
                                            </xsd:complexType>
                                          </xsd:element>
                                          <xsd:element name=""assembly"">
                                            <xsd:complexType>
                                              <xsd:attribute name=""alias"" type=""xsd:string"" />
                                              <xsd:attribute name=""name"" type=""xsd:string"" />
                                            </xsd:complexType>
                                          </xsd:element>
                                          <xsd:element name=""data"">
                                            <xsd:complexType>
                                              <xsd:sequence>
                                                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
                                                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />
                                              </xsd:sequence>
                                              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" msdata:Ordinal=""1"" />
                                              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""3"" />
                                              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""4"" />
                                              <xsd:attribute ref=""xml:space"" />
                                            </xsd:complexType>
                                          </xsd:element>
                                          <xsd:element name=""resheader"">
                                            <xsd:complexType>
                                              <xsd:sequence>
                                                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
                                              </xsd:sequence>
                                              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />
                                            </xsd:complexType>
                                          </xsd:element>
                                        </xsd:choice>
                                      </xsd:complexType>
                                    </xsd:element>
                                  </xsd:schema>
                                  <resheader name=""resmimetype"">
                                    <value>text/microsoft-resx</value>
                                  </resheader>
                                  <resheader name=""version"">
                                    <value>2.0</value>
                                  </resheader>
                                  <resheader name=""reader"">
                                    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
                                  </resheader>
                                  <resheader name=""writer"">
                                    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
                                  </resheader>
                                    </root>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(resheader);

            return doc;
        }

        private string XMLConvertStr(string xml)
        {
            return xml.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\'").Replace("&apos;", "'").Replace("&amp;", "&");
        }

        private string StrConvertXML(string str)
        {
            return str.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\'", "&quot;").Replace("'", "&apos;");
        }

        #endregion
    }
}