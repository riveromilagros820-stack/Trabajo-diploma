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
    public class SerializarClienteBLL_16MR
    {
        public void Serializar(List<Cliente_16MR> clientes, string rutaArchivo)
        {
            var serializer = new XmlSerializer(typeof(List<Cliente_16MR>));
            using (var writer = new StreamWriter(rutaArchivo))
            {
                serializer.Serialize(writer, clientes);
            }
        }
    }
}
