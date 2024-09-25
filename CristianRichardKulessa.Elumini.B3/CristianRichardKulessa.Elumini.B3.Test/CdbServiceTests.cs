using CristianRichardKulessa.Elumini.B3.Server.Models;
using CristianRichardKulessa.Elumini.B3.Server.Services;

namespace CristianRichardKulessa.Elumini.B3.Test
{
    public class CdbServiceTests
    {
        private readonly ICdbService service;
        public CdbServiceTests()
        {
            this.service = new CdbService();
        }
        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaPeriodoDe6Meses()
        {
            var request = new CdbRequestModel
            {
                Valor = 1000d,
                Prazo = 6
            };
            var response = service.Calcular(request);
            Assert.Equal(1059.76d, response.ValorBruto);
            Assert.Equal(1046.31d, response.ValorLiquido);
        }
        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaPeriodoDe12Meses()
        {
            var request = new CdbRequestModel
            {
                Valor = 1000d,
                Prazo = 12
            };
            var response = service.Calcular(request);
            Assert.Equal(1123.08d, response.ValorBruto);
            Assert.Equal(1098.47d, response.ValorLiquido);
        }
        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaPeriodoDe24Meses()
        {
            var request = new CdbRequestModel
            {
                Valor = 1000d,
                Prazo = 24
            };
            var response = service.Calcular(request);
            Assert.Equal(1261.31d, response.ValorBruto);
            Assert.Equal(1215.58d, response.ValorLiquido);
        }
        [Fact]
        public void Calcular_DeveRetornarValoresCorretos_ParaPeriodoDe60Meses()
        {
            var request = new CdbRequestModel
            {
                Valor = 1000d,
                Prazo = 60
            };
            var response = service.Calcular(request);
            Assert.Equal(1786.72d, response.ValorBruto);
            Assert.Equal(1668.72d, response.ValorLiquido);
        }
    }
}