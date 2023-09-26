using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class DetailList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_DetailList { get; set; }

        [ForeignKey("MyLists")]
        public int Id_MyLists { get; set; }

        [JsonIgnore]
        public virtual MyLists MyLists { get; set; }

        [ForeignKey("Products")]
        public int Id_Product { get; set; }

        [JsonIgnore]
        public virtual Products Products { get; set; }
    }
}
