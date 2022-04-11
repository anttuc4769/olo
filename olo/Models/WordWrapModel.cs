namespace olo.Models
{
    public class WordWrapModel : BaseModel
    {
        public string OriginalText { get; set; }
        public int LengthPerLine { get; set; }
        public List<string> ConvertedText {get; set; }
    }
}
