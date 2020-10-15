namespace Balanzas.Models
{
    using Balanzas.Models.DataDecoders;
    using Balanzas.Models.Drivers;

    public class DeviceQuery
    {
        private readonly DriverFactory _driverFactory;
        private readonly DataDecoderFactory _decoderFactory;

        public DeviceQuery(DriverFactory driverFactory, DataDecoderFactory decoderFactory)
        {
            _driverFactory = driverFactory;
            _decoderFactory = decoderFactory;
        }

        public DatoLeido Query(Dispositivo dispositivo)
        {
            var driver = _driverFactory.GetDriver(dispositivo.Driver.Nombre);
            var decoder = _decoderFactory.GetDataDecoder(dispositivo.DataDecoder.Nombre);
          
            var datoLeido = driver.GetLectura(dispositivo);
            datoLeido.Text = decoder.Decode(datoLeido.Text);
          
            return datoLeido;
        }
    }
}