using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
  public class PatioTestes
  {
    //é Possível rodar o testes com Xunit usando o gerenciador de pacotes do 
    //NUGET
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

    //O inline data permite que para o mesmo teste possamos ter diversos dados diferentes
    [Theory]
    [InlineData("Vitor brito", "ASD-7777", "PRETO", "GOL")]
    [InlineData("Nadine brito", "ASB-7777", "PRETO", "GOL")]
    [InlineData("Dante brito", "ABB-7777", "PRETO", "GOL")]
    public void ValidarFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
    {
      //Arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = new Operador();
      var veiculo = new Veiculo();
      veiculo.Proprietario = proprietario;
      veiculo.Tipo = TipoVeiculo.Automovel;
      veiculo.Cor = cor;
      veiculo.Modelo = modelo;
      veiculo.Placa = placa;

      estacionamento.RegistrarEntradaVeiculo(veiculo);
      estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

      //Act
      double faturamento = estacionamento.TotalFaturado();
      //Assert
      Assert.Equal(2, faturamento);
    }
  }
}
