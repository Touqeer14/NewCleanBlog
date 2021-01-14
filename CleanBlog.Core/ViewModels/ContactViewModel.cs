using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanBlog.Core.ViewModels
{
   public class ContactViewModel
    {
        [Required(ErrorMessage ="please enter your name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "please enter your email address")]

        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your message")]
        [MaxLength(ErrorMessage = "your message must be no longer than 500 cheracter")]

        public string Message { get; set; }

        public int ContactFormId { get; set; }
    }
}
