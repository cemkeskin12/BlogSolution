using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CKBlog.Web.Areas.Admin.Models
{
    public class UserUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public string FirstName { get; set; }
        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public string UserName { get; set; }
        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
