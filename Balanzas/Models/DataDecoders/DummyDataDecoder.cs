namespace Balanzas.Models.DataDecoders
{
    public class DummyDataDecoder : IDataDecoder
    {
        public string DataDecoderName => "Dummy";

        public string Decode(string data)
        {
            return data;
        }
    }
}