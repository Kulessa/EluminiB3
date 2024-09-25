using CristianRichardKulessa.Elumini.B3.Server.Models;

namespace CristianRichardKulessa.Elumini.B3.Server.Services
{
    public class CdbService : ICdbService
    {
        private const double tb = 1.08d;
        private const double cdi = 0.009d;
        private const double ir1_6 = 0.225d;
        private const double ir7_12 = 0.2d;
        private const double ir13_24 = 0.175d;
        private const double ir25_60 = 0.15d;
        public CdbResponseModel Calcular(CdbRequestModel model)
        {
            var valorInicial = model.Valor;
            var periodo = model.Prazo;
            var taxa = tb * cdi;
            var valorBruto = valorInicial * Math.Pow(1d + taxa, periodo);
            var rendimento = valorBruto - valorInicial;
            var taxaImposto = periodo switch
            {
                <= 6 => ir1_6,
                <= 12 => ir7_12,
                <= 24 => ir13_24,
                _ => ir25_60,
            };
            var valorImposto = rendimento * taxaImposto;
            var valorLiquido = valorBruto - valorImposto;
            return new()
            {
                ValorBruto = Math.Round(valorBruto, 2, MidpointRounding.ToEven),
                ValorLiquido = Math.Round(valorLiquido, 2, MidpointRounding.ToEven)
            };
        }
    }
}
