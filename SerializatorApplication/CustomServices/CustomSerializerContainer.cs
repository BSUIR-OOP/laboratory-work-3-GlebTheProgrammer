namespace SerializatorApplication.CustomServices
{
    public class CustomSerializerContainer
    {
        string filePath { get; set; }
        public CustomSerializerContainer(string filePath)
        {
            this.filePath = filePath;
        }
        public void CustomSerialize(Type dataType, object data)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
            CustomSerializer customSerializer = new CustomSerializer(dataType);
            FileStream fileStream = File.OpenWrite(filePath);
            customSerializer.Serialize(fileStream, data);
            fileStream.Close();
        }

        public object CustomDeserialize(Type dataType = null)
        {
            object obj = null;

            CustomSerializer customSerializer = new CustomSerializer(dataType);
            if(File.Exists(filePath))
            {
                FileStream fileStream = File.OpenRead(filePath);
                //FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate);
                obj = customSerializer.Deserialize(fileStream);
                fileStream.Close();
            }

            return obj;
        }

        public string GetCharacterClass(Type dataType = null)
        {
            string type = null;

            CustomSerializer customSerializer = new CustomSerializer(dataType);
            if (File.Exists(filePath))
            {
                FileStream fileStream = File.OpenWrite(filePath);
                //FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate);
                type = customSerializer.GetCharacterType(fileStream);
                fileStream.Close();
            }

            return type;
        }
    }
}
