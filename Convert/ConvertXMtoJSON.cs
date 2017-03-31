using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SDK;

namespace Convert
{
    public class ConvertXMtoJSON : IConvert
    {
        private string _json;

        public string Convert(string TextFile)
        {
            XmlDocument DocXML = new XmlDocument();
            
            try
            {
                DocXML.LoadXml(TextFile);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {

                _json = JsonConvert.SerializeXmlNode(DocXML, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return _json;
        }
    }
}
