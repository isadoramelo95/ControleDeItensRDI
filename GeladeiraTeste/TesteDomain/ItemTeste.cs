using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GeladeiraTeste.TesteDomain
{
    public class ItemTeste
    {
        private void ValidateModel(object model, List<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
        }

        [Fact]
        public void Item_DeveSerValido_CamposPreenchidos()
        {
            var item = new Item
            {
                Id = 1,
                Alimento = "Maçã",
                Unidade = "Kg",
                Quantidade = 5,
                Classificacao = "A",
                Posicao = 1,
                NumeroAndar = 2,
                NumeroContainer = 3
            };

            var validationResults = new List<ValidationResult>();

            ValidateModel(item, validationResults);

            Assert.Empty(validationResults); 
        }

        [Fact]
        public void Item_DeveSerInvalido_CamposFaltando()
        {
            var item = new Item
            {
                Id = 1,
                Unidade = "Kg",
                Quantidade = 5,
                Classificacao = "A",
            };

            var validationResults = new List<ValidationResult>();
            ValidateModel(item, validationResults);

            foreach (var result in validationResults)
            {
                Console.WriteLine($"Erro de validação no campo: {string.Join(", ", result.MemberNames)}");
            }
            Assert.Equal(4, validationResults.Count);
        }

        [Fact]
        public void Item_ValoresOpicionaisAdicionados()
        {
            var item = new Item
            {
                Id = 1,
                Alimento = "Banana",
                Quantidade = 3,
                Posicao = 2,
                NumeroAndar = 1,
                NumeroContainer = 1
            };

            var validationResults = new List<ValidationResult>();

            ValidateModel(item, validationResults);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void Item_ValidarPropriedadesSucesso()
        {
            var item = new Item
            {
                Id = 1,
                Alimento = "Pera",
                Quantidade = 10,
                Unidade = "Kg",
                Posicao = 3,
                NumeroAndar = 1,
                NumeroContainer = 2
            };

            var validationResults = new List<ValidationResult>();

            ValidateModel(item, validationResults);

            Assert.Empty(validationResults); 
        }

        [Fact]
        public void Item_DeveSerInvalido_QuandoQuantidadeForNegativa()
        {
            // Arrange
            var item = new Item
            {
                Id = 1,
                Alimento = "Uva",
                Quantidade = -5, 
                Unidade = "Kg",
                Posicao = 1,
                NumeroAndar = 2,
                NumeroContainer = 1
            };

            var validationResults = new List<ValidationResult>();

     
            ValidateModel(item, validationResults);


            Assert.Single(validationResults);
            Assert.Contains(validationResults, vr => vr.ErrorMessage.Contains("Quantidade deve ser maior que zero"));
        }
    }
}
