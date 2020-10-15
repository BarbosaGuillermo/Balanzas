namespace Balanzas.Models.DataDecoders
{
    using Balanzas.Infrastructure;

    public class DoubleReadStripNonNumericCharsDataDecoder : IDataDecoder
    {
        public string DataDecoderName => "DoubleReadStripNonNumericChars";

        public string Decode(string data)
        {
            var posicionComa = data.IndexOf(',');
            var lectura = posicionComa == -1 ? data.Substring(0, 8) : data.Substring(0,posicionComa + 2);
            return lectura.StripNonNumericChars();
        }
    }
}