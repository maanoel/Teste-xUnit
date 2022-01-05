using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
  public class VeiculoTeste
  {
    //AAA PATTERN
    //arrange 
    //Act
    //Assert 

    [Fact]
    [Trait("Funcionalidade", "acelerar")]
    public void TestaVeiculoAcelerar()
    {
      //Arrange
      var veiculo = new Veiculo();
      //Act
      veiculo.Acelerar(10);
      //Assert
      Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    //Na totvs, usamos o MSTest para realizar o testes unitários..
    //MSTEXT usa TestMethod e TestClass
    [Fact(DisplayName = "Teste numero 1")]
    [Trait("Funcionalidade", "frear")]
    public void TestaVeicularFrear()
    {
      //Arrange
      var veiculo = new Veiculo();
      //Act
      veiculo.Frear(10);
      //Assert
      Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste numero 2")]
    public void TestaTipoVeiculo()
    {
      var veiculo = new Veiculo();

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
      var veiculo = new Veiculo();

      //Act
      veiculo.Acelerar(10);
      modelo.Acelerar(10);

      //Assert
      Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void DadosVeiculo()
    {
      //Arrange
      var carro = new Veiculo();
      carro.Proprietario = "Manoel Moura";
      carro.Tipo = TipoVeiculo.Automovel;
      carro.Placa = "FUS-7777";
      carro.Cor = "Preto";
      carro.Modelo = "Variante";

      //Act
      string dados = carro.ToString();

      //Assert
      Assert.Contains("Ficha do Veículo:", dados);
    }
  }
}
