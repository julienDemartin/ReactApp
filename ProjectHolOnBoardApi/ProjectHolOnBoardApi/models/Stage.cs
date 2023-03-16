using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectHolOnBoardApi.models
{
    public class Stage
    {
        [Key]
        public int id_stage { get; set; }
        public string name_stage { get; set; }

        public string description_stage { get; set; }
       
        public int id_circuit { get; set; }

        [ForeignKey("Anchor")]
        public int id_Anchor { get; set; }

        [JsonIgnore]
        public virtual Circuit? Circuit { get; set; }
        
        public virtual Anchor? Anchor { get; set; }
       
    }
}
