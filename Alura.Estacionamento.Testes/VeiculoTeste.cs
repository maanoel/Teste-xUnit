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
    [Fact]
    public void TestaVeicularFrear()
    {
      //Arrange
      var veiculo = new Veiculo();
      //Act
      veiculo.Frear(10);
      //Assert
      Assert.Equal(-150, veiculo.VelocidadeAtual);
    }
  }
}
