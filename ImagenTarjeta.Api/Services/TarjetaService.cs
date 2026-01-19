using ImagenTarjeta.Api.Interfaces;
using ImagenTarjeta.Api.Models;
using Microsoft.Extensions.Options;

namespace ImagenTarjeta.Api.Services
{
    public class TarjetaService : ITarjetasService
    {
        public readonly IEnumerable<TarjetaMapping> listaTarjetas;

        public TarjetaService(IOptions<List<TarjetaMapping>> configTarjetas)
        {
            listaTarjetas = configTarjetas.Value;
        }

        public string GetUrlTarjeta(string? bin, string? clase)
        {
            int claseDefault = 999;
            string url = string.Empty;
            if (!string.IsNullOrEmpty(bin))
            {
                _ = int.TryParse(bin, out int binNumber);
                url = listaTarjetas.FirstOrDefault(p => p.Bin == binNumber)?.UrlImagen ?? string.Empty;
            }
            else if (!string.IsNullOrEmpty(clase))
            {
                _ = int.TryParse(clase, out int claseNumber);
                url = listaTarjetas.FirstOrDefault(p => p.TipoTarjeta == claseNumber)?.UrlImagen ?? string.Empty;
            }

            if (string.IsNullOrEmpty(url))
            {
                url = listaTarjetas.FirstOrDefault(p => p.TipoTarjeta == claseDefault)?.UrlImagen ?? string.Empty;
            }
            
            return url;
        }
    }
}
