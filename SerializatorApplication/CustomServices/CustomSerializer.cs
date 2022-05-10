using System.Runtime.Serialization;
using System.Reflection;
using SerializatorApplication.Models;
using SerializatorApplication.Characters;

namespace SerializatorApplication.CustomServices
{
    //Type Name - to understand wich object we have
    //Property Name: PropType Value
    public class CustomSerializer : IFormatter
    {
        private Type _type;
        public CustomSerializer(Type type)
        {
            _type = type;
        }
        public void Serialize(Stream serializationStream, Object graph)
        {
            //Get the list of properties
            //Write the type name
            //Write the property names and values

            List<PropertyInfo> properties = _type.GetProperties().ToList();
            StreamWriter streamWriter = new StreamWriter(serializationStream);
            streamWriter.WriteLine(_type.Name);
            foreach (PropertyInfo propertyInfo in properties)
            {
                streamWriter.WriteLine(String.Format("{0}:{1}", propertyInfo.Name, propertyInfo.GetValue(graph)));
            }

            streamWriter.Flush();
        }

        public object Deserialize(Stream serializationStream)
        {

            using(var sr = new StreamReader(serializationStream))
            {
                //To read type name
                string typeName = sr.ReadLine();

                Object obj = Activator.CreateInstance(Type.GetType("SerializatorApplication.Characters."+typeName));
                //read the rest of the contents
                string contents = sr.ReadToEnd();
                List<string> pairs = contents.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key, value;
                foreach (string pair in pairs)
                {
                    string[] keyValue = pair.Split(':');
                    key = keyValue[0];
                    value = keyValue[1];

                    PropertyInfo propertyInfo = Type.GetType("SerializatorApplication.Characters." + typeName).GetProperty(key);
                    if(propertyInfo != null)
                    {
                        if(UInt32.TryParse(value, out _))
                        {
                            propertyInfo.SetValue(obj, Convert.ToUInt32(value), null);
                            continue;
                        }
                        if (Enum.TryParse<DamageType>(value, out _))
                        {
                            propertyInfo.SetValue(obj, Enum.Parse(typeof(DamageType), value), null);
                            continue;
                        }
                        if(Enum.TryParse<ElementType>(value, out _))
                            propertyInfo.SetValue(obj, Enum.Parse(typeof(ElementType), value), null);
                        else
                            propertyInfo.SetValue(obj, value, null);
                    }
                }

                return obj;
            }
        }

        public string GetCharacterType(Stream serializationStream)
        {
            using (var sr = new StreamReader(serializationStream))
            {
                //To read type name
                string typeName = sr.ReadLine();
                return typeName;
            }
        }

        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }
    }
}
