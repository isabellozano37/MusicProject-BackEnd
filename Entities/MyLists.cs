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
    public class MyLists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_MyLists { get; set; }
        public string Name_List { get; set; }

        [ForeignKey("Users")]
        public int Id_Users { get; set; }

        [JsonIgnore]
        public virtual Users Users { get; set; }

        [JsonIgnore]
        public ICollection<DetailList> DetailList { get; set; }
    }
}
