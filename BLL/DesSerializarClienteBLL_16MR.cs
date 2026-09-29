using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    public class DesSerializarClienteBLL_16MR
    {
        public List<Cliente_16MR> DesSerializar(string rutaArchivo)
        {
            var serializer = new XmlSerializer(typeof(List<Cliente_16MR>));
            using (var reader = new StreamReader(rutaArchivo))
            {
                return (List<Cliente_16MR>)serializer.Deserialize(reader);
            }
        }
    }
}
