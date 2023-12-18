using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegralService146.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string QuestionText { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Answer1 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Answer2 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Answer3 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Answer4 { get; set; }
        public int RightAnswer { get; set; }
    }
}
