using Microsoft.EntityFrameworkCore;
using RevendaProject.Data;
using RevendaProject.Features.Commands;
using RevendaProject.Features.Handlers;
using Xunit;

namespace RevendaProject.Tests
{
    public class CreateRevendaHandlerTests
    {
        [Fact]
        public async Task Deve_Criar_Revenda_Quando_DadosValidos()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("revenda_test").Options;

            using var context = new AppDbContext(options);
            var handler = new CreateRevendaHandler(context);

            var command = new CreateRevendaCommand
            {
                CNPJ = "00.000.000/0001-00",
                RazaoSocial = "Distribuidora XYZ",
                NomeFantasia = "XYZ",
                Email = "contato@xyz.com",
                Telefones = new List<string> { "(11) 99999-0000" },
                Contatos = new List<string> { "João" },
                EnderecosEntrega = new List<string> { "Rua A, 123" }
            };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result > 0);
            var revenda = await context.Revendas.FindAsync(result);
            Assert.NotNull(revenda);
            Assert.Equal("XYZ", revenda.NomeFantasia);
        }
    }
}
