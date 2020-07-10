namespace Balanzas.ViewModels
{
    public class LecturaBalanza
    {
        public string Text { get; set; }
        public decimal Value { get; set; }
        public bool Error { get; set; }
        public string ErrorText { get; set; }
    }
}