using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace MilkRun.UtilizeApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginModels
    {
        /// <summary>
        /// 
        /// </summary>
        [RegularExpression(@"^.{6,15}$", ErrorMessage = "Password must contain: Minimum 6 and Maximum 15 characters ")]
        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please enter Username")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool isEdit { get; set; }
    }
}
