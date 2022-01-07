using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
  public class VeiculoTeste
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

    //Na totvs, usamos o MSTest para realizar o testes unit�rios..
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

    [Fact(Skip = "Adicionando um skip no fact, far� com que o teste n�o seja executado")]
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
      Assert.Contains("Ficha do Ve�culo:", dados);
    }
  }
}
