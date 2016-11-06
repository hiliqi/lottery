using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsDel { get; set; }
    }

}
