using System.Configuration;
using System.Xml;

namespace KyCMS.Common.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class FileConfigurationSection : ConfigurationSection
    {
        #region Methods
        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sectionName">Name of the section.</param>
        public virtual void GetSection(string fileName, string sectionName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlReader xmlReader = null;
            foreach (XmlNode node in xmlDocument.ChildNodes)
            {
                if (node.Name == sectionName)
                {
                    xmlReader = XmlReader.Create(fileName);
                    break;
                }
            }
            base.DeserializeSection(xmlReader);
        }
        #endregion
    }
}
