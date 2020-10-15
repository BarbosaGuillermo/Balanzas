namespace Balanzas.Models.DataDecoders
{
    using Balanzas.Infrastructure;

    public class DivideByTenStripNonNumericCharsDataDecoder : IDataDecoder
    {
        public string DataDecoderName => "DivideByTenStripNonNumericChars";

        public string Decode(string data)
        {
            var lectura = data.StripNonNumericChars();
            return lectura.Insert(lectura.Length - 1, ",");
        }
    }
}