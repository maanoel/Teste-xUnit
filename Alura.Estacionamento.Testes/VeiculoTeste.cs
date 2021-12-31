using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
  public class VeiculoTeste
  {
    [Fact]
    public void TestaVeiculoAcelerar()
    {
      //AAA PATTERN
      //arrange 
      //Act
      //Assert 
      var veiculo = new Veiculo();
      veiculo.Acelerar(10);
      Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    //Na totvs, usamos o MSTest para realizar o testes unitários..
    //MSTEXT usa TestMethod e TestClass
    [Fact]
    public void TestaVeicularFrear() 
    {
      var veiculo = new Veiculo();
      veiculo.Frear(10);
      Assert.Equal(-150, veiculo.VelocidadeAtual);
    }
  }
}
