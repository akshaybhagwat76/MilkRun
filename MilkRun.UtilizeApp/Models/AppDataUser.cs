using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilkRun.UtilizeApp.Models
{
    [Table("Data_User")]
    public class AppDataUser
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SupplierCode { get; set; }
        public Nullable<int> AccessLevel { get; set; }
        public Nullable<int> UserLevel { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Create_date { get; set; }
        public string Email { get; set; }
    }
}
