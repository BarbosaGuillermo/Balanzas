namespace Balanzas.Models.DataDecoders
{
    public interface IDataDecoder
    {
        string Decode(string data);
        string DataDecoderName { get; }
    }
}
