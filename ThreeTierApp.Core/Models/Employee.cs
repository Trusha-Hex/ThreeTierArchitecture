using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeTierApp.Core.Models
{
    [Table("employees")]  
    public class Employee
    {
        [Column("id")] 
        public int Id { get; set; }

        [Column("name")]  
        public string Name { get; set; }

        [Column("department")] 
        public string Department { get; set; }

        [Column("salary")]  
        public decimal Salary { get; set; }
    }
}
