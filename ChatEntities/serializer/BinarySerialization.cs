using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChatEntities.serializer
{
    public class BinarySerialization
    {
        public static byte[] Serializate(object toSerializate)
        {
            MemoryStream memory = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(memory, toSerializate);

            return memory.ToArray();

        }

        public static object? Deserializate(byte[] data)
        {
            MemoryStream memory = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Binder = new CurrentAssemblyDeserializationBinder();

            try
            {
                return formatter.Deserialize(memory);
            } catch (Exception ex)
            {
                Console.WriteLine("Serializer: " + ex.Message);
            }
            return null;
        }

    }

    internal class CurrentAssemblyDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return Type.GetType(string.Format("{0}, {1}", typeName, Assembly.GetExecutingAssembly().FullName));
        }
    }
}
