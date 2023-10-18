using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinyaG02Demo.Models
{
    public class Department
    {
        //[Key]
        public int Id { get; set; }
        [MinLength(2,ErrorMessage ="Name Must be more 2 Char")]
        public string Name { get; set; }
        
        public string MGRName { get; set; }
       // [JsonIgnore]
        public ICollection<Employee>  Employees{ get; set; } = new List<Employee>();
    }
}
