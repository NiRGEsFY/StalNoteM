using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.Other
{
    public class Advertising
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string NameCustomer { get; set; }
        [MaxLength(200)]
        public string Context {  get; set; }
        public int? Count { get; set; }
        public DateTime? Start {  get; set; }
        public DateTime? End { get; set; }
    }
}
