using CristianRichardKulessa.Elumini.B3.Server.Models;

namespace CristianRichardKulessa.Elumini.B3.Server.Services
{
    public interface ICdbService
    {
        CdbResponseModel Calcular(CdbRequestModel model);
    }
}