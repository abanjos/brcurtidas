using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRCurtidas.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string PhoneNumber { get; set; }

        public Account Account { get; set; }

        public Address Address { get; set; }
    }
}
