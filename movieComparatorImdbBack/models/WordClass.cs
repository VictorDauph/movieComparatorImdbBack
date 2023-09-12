using System.ComponentModel.DataAnnotations.Schema;

namespace movieComparatorImdbBack.models
{
    [Table("Words")]
    public class WordClass
    {
        public int Id { get; set; }
        public string Word { get; set; }= null!;

        public WordClass(string word) { 
            this.Word = word;
        }
    }
}
