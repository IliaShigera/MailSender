using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSender.Models
{
    public class MailRequest
    {
        [Required]
        public string ToEmail { get; set; }
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
