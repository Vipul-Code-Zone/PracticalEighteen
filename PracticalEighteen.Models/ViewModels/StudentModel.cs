using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalEighteen.Models.ViewModels
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "Name should be max 50 charcter only!")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "JoiningDate")]
        [DataType(DataType.Date, ErrorMessage = "Date is Required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }
        [Required]
        [RegularExpression(@"^[1-9][0-9]?$", ErrorMessage = "Age can only between the 1 to 99")]
        public int Age { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Address should be maximum 100 characters")]
        public string Address { get; set; }
    }
}
