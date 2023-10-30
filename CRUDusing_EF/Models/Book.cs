using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDusing_EF.Models
{

    //this class is called entity class /BO business object / POCO (plan old clr object)
    [Table("Book")]   //map class with table in DB  (match table name)
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public int Price { get; set; }


    }
}
