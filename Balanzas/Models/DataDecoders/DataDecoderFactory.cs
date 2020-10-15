namespace Balanzas.Models.DataDecoders
{
    using System.Collections.Generic;
    using System.Linq;

    public class DataDecoderFactory
    {
        private readonly IEnumerable<IDataDecoder> _decoders;

        public DataDecoderFactory(IEnumerable<IDataDecoder> decoders)
        {
            _decoders = decoders;
        }

        public IDataDecoder GetDataDecoder(string decoderName)
        {
            return _decoders.FirstOrDefault(x => x.DataDecoderName == decoderName) ?? new DummyDataDecoder();
        }
    }
}