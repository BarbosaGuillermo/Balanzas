namespace Balanzas.Models.DataDecoders
{
    using Balanzas.Infrastructure;

    public class StripNonNumericCharsDataDecoder : IDataDecoder
    {
        public string DataDecoderName => "StripNonNumericChars";

        public string Decode(string data)
        {
            return data.StripNonNumericChars();
        }
    }
}