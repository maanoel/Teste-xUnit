using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
  public class VeiculoTeste : IDisposable
  {
    private Veiculo veiculo;
    public ITestOutputHelper SaidaConsoleTest;

    //AAA PATTERN
    //arrange 
    //Act
    //Assert 

    public VeiculoTeste(ITestOutputHelper saidaConsoleTest)
    {
      SaidaConsoleTest = saidaConsoleTest;
      SaidaConsoleTest.WriteLine("construtor invokado invocado.");
      veiculo = new Veiculo();
    }

    [Fact]
    public void TestarVeiculoAcelerarComParametroDez()
    {
      //Arrange
      //var veiculo = new Veiculo();
      //Act
      veiculo.Acelerar(10);
      //Assert
      Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    //Na totvs, usamos o MSTest para realizar o testes unitários..
    //MSTEXT usa TestMethod e TestClass
    [Fact]
    public void TestarVeiculoFrearComParametroDez()
    {
      //Arrange
      //var veiculo = new Veiculo();
      //Act
      veiculo.Frear(10);
      //Assert
      Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste numero 2")]
    public void TestaTipoVeiculo()
    {
      //var veiculo = new Veiculo();

      Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact(Skip = "Adicionando um skip no fact, fará com que o teste não seja executado")]
    public void ValidarNomeProprietario()
    {

    }

    [Theory]
    [ClassData(typeof(Veiculo))]
    public void TestaVeiculoClass(Veiculo modelo)
    {
      //Arrange
      //var veiculo = new Veiculo();

      //Act
      veiculo.Acelerar(10);
      modelo.Acelerar(10);

      //Assert
      Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void FichaDeInformacaoDoVeiculo()
    {
      //Arrange
      //var carro = new Veiculo();
      veiculo.Proprietario = "Manoel Moura";
      veiculo.Tipo = TipoVeiculo.Automovel;
      veiculo.Placa = "FUS-7777";
      veiculo.Cor = "Preto";
      veiculo.Modelo = "Variante";

      //Act
      string dados = veiculo.ToString();

      //Assert
      Assert.Contains("Ficha do Veículo:", dados);
    }

    [Fact]
    public void TestaNomeProprietarioVeiculoComMenosDeTresCaractres()
    {
      //Arrange
      string nomeProprietario = "Ab";

      //Assert
      Assert.Throws<System.FormatException>(
        //Act
        () => new Veiculo(nomeProprietario)
      );
    }

    [Fact]
    public void TestaNomeProprietarioVeiculoComQuartoCaractreDaPlaca()
    {
      //arrange
      string placa = "LAPEA1KE";

      //act
      var mensagem = Assert.Throws<System.FormatException>(
        () => new Veiculo().Placa = placa
      );

      //assert

      //Excepted always become first..
      Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
    }

    public void Dispose()
    {
      SaidaConsoleTest.WriteLine("dispose no console");
    }
  }
}
