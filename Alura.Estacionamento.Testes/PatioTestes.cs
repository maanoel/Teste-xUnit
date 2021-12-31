using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
  public class PatioTestes
  {
    [Fact]
    public void ValidaFaturamento() 
    {
      //arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = new Operador();
      var veiculo = new Veiculo();
      veiculo.Proprietario = "André Silva";
      veiculo.Tipo = TipoVeiculo.Automovel;
      veiculo.Cor = "Verde";
      veiculo.Modelo = "Fusca";
      veiculo.Placa = "asd-9999";

      estacionamento.RegistrarEntradaVeiculo(veiculo);
      estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

      //act
      double faturamento = estacionamento.TotalFaturado();

      //assert
      Assert.Equal(2, faturamento);
    }
  }
}
