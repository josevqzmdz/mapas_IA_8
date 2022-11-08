using System.Text.Json;
using System.Text.Json.Serialization;

namespace mapas_IA_8
{
    public class JSONParser
    {
        public string jsonString { get; set; } 
        public JSONParser(IEnumerable<(nodo, nodo, int)> nodo)
        {
            this.jsonString = JsonSerializer.Serialize(nodo);
        }
    }
}
