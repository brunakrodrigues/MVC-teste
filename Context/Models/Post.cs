using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_with_EF.Context.Models
{
    public class Post
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Crated { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

    }
}
