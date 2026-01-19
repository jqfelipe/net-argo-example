namespace ImagenTarjeta.Api.Interfaces
{
    public interface ITarjetasService
    {
        string GetUrlTarjeta(string? bin, string? clase);
    }
}
