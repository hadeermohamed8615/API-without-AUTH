using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinyaG02Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [Range(22,60)]
        public int Age { get; set; }
        [Range(5000,20000)]
        public int Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
       // [JsonIgnore]
        public Department? Department { get; set; }
    }
}
