namespace ImagenTarjeta.Api.Models
{
    public class TarjetaMapping
    {
        public int Bin { get; set; }
        public int TipoTarjeta { get; set; }
        public required string  UrlImagen { get; set; }
    }
}
