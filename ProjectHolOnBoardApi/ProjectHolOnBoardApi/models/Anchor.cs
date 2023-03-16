
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHolOnBoardApi.models
{
    public class Anchor
    {
        [Key]
        public int id_anchor { get; set; }

        public string? id_string_anchor { get; set; }

        public string? place_anchor { get; set; }

        public string? description_place { get; set; }

        

       

       

       
    }
}
