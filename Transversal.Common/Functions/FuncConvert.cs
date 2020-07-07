using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Transversal.Common.Functions
{
    public class FuncConvert
    {
        public static string XmlToJson(string sXml)
        {
            var doc = XElement.Parse(sXml);
            var node_cdata = doc.DescendantNodes().OfType<XCData>().ToList();
            foreach (var node in node_cdata)
            {
                node.Parent.Add(node.Value);
                node.Remove();
            }
            var json = JsonConvert.SerializeXNode(doc, Formatting.None, false);
            return json;
        }

        public static Object TryParseJsonToObject<T1, T2>(string sJon)
        {
            try
            {
                return JsonConvert.DeserializeObject<T2>(sJon);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T1>(sJon);
            }
        }
    }
}
