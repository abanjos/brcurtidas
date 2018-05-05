using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRCurtidas.Data
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string PostalCode { get; set; }
    }
}
