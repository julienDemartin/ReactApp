using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectHolOnBoardApi.models
{
    public class Circuit
    {
        [Key]
        public  int id_circuit { get; set; }

        public string name_circuit { get; set; }

        public string description_circuit { get; set; }


        [JsonIgnore]
        public virtual ICollection<Stage>? Stage { get; set; }
    }
}
