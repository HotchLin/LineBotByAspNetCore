using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LineBotByAspNetCore.Models
{
    public class LineKeyword
    {
        [Key]
        public string Keyword { get; set; }
        [Required]
        public string ReplyMessage { get; set; }
    }
}
