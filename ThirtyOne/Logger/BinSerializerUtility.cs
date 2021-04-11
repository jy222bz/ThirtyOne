using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ThirtyOne.Exceptions;

namespace ThirtyOne.Logger
{
    /// <summary>
    /// A class for handling XML serialization and de-serialization.
    /// Author: Jacob Yousif
    /// </summary>
    public class XMLSerializerUtility
    {

        /// <summary>
        /// It serilizes the data into a XML file.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <param name="bucketOfElements">The collection of elements.</param>
        public static List<E> XMLDeSerialize<E>()
        {
            string fileName = "scores.xml";
            TextReader textReader = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<E>));
                if (File.Exists(fileName))
                {
                    textReader = new StreamReader(fileName);
                    List<E> bucketOfElements = xmlSerializer.Deserialize(textReader) as List<E>;
                    textReader.Close();
                    return bucketOfElements;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new FileSerializationException();
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
        }

        /// <summary>
        /// It de-serilizes the data from a XML file.
        /// </summary>
        /// <param name="fileName"> The file name.</param>
        /// <returns>The collection of objects.</returns>
        public static void XMLSerialize<E>(List<E> bucketOfElements)
        {
            string fileName = "scores.xml";
            TextWriter writer = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<E>));
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                writer = new StreamWriter(fileName);
                xmlSerializer.Serialize(writer, bucketOfElements);
                writer.Close();
            }
            catch (Exception)
            {
                throw new FileDeserializationException();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

    }
}
