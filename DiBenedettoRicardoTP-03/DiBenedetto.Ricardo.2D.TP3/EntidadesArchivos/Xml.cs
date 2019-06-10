using EntidadesExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesArchivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter wtr = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(wtr, datos);
                wtr.Close();
                return true;

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }



        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader rdr = new XmlTextReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(rdr);
                rdr.Close();
                return true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
        }
    }
}
