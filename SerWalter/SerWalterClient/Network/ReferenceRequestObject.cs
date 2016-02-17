using SerWalterClient.Data;

namespace SerWalterClient.Network
{
    internal class ReferenceRequestObject
    {
        public int id;
        public string objectType;

        public ReferenceRequestObject()
        {
        }

        public ReferenceRequestObject(DBObject dbObject)
        {
            this.id = dbObject.id;
            this.objectType = dbObject.objectType;
        }
    }
}