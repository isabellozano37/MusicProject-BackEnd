using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Product { get; set; }
        public string ProductsName { get; set; }
        public string Imagen { get; set; } 
        public string SongName { get; set; }
        public string FilmName { get; set; }
        public string Audio { get; set; }

        [ForeignKey("Categories")]
        public int Id_Categories { get; set; }

        [JsonIgnore]
        public virtual Categories Categories { get; set; }
        public ICollection<DetailList> DetailList { get; set; }
        public int Id_Products { get; set; }
    }
}
