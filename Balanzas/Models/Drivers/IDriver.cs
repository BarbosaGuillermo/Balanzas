namespace Balanzas.Models.Drivers
{
    public interface IDriver
    {
        DatoLeido GetLectura(Dispositivo dispositivo);
        string DriverName { get; }
    }
}
