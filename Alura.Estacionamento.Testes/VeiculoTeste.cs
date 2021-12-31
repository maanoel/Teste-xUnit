using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
  public class VeiculoTeste
  {
    [Fact]
    public void TestaVeiculoAcelerar()
    {
      var veiculo = new Veiculo();
      veiculo.Acelerar(10);
      Assert.Equal(100, veiculo.VelocidadeAtual);
    }
  }
}
