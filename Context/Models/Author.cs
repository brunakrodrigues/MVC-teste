using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_with_EF.Context.Models
{
    public class Author
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }

        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
