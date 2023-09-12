namespace movieComparatorImdbBack.models
{
    public class DictionnaryMov
    {
        public ICollection<WordClass> Words { get; set; }= new HashSet<WordClass>();
    }
}
