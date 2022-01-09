using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
  public class PatioTestes: IDisposable
  {
    private Veiculo veiculo;
    private Operador operador;
    public ITestOutputHelper SaidaConsoleTest;

    public PatioTestes(ITestOutputHelper saidaConsoleTest)
    {
      SaidaConsoleTest = saidaConsoleTest;
      SaidaConsoleTest.WriteLine("construtor do patio test");
      veiculo = new Veiculo();
      operador = new Operador();
      operador.Nome = "Nildo";
    }

    //é Possível rodar o testes com Xunit usando o gerenciador de pacotes do 
    //NUGET
    [Fact]
    public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
    {
      //arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = operador;
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
    public void ValidarFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
    {
      //Arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = operador;
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

    //O teste de regressão acontece quando o sistema é alterado devido a uma solicitação do usuário
    /// e em seguida o teste precisa ser modificado também devido a esta alteração
    [Theory]
    [InlineData("Vitor brito", "ASD-7777", "PRETO", "GOL")]
    public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
    {
      //Arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = operador;
      veiculo.Proprietario = proprietario;
      veiculo.Tipo = TipoVeiculo.Automovel;
      veiculo.Cor = cor;
      veiculo.Modelo = modelo;
      veiculo.Placa = placa;

      estacionamento.RegistrarEntradaVeiculo(veiculo);

      //Act
      var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

      //Assert
      Assert.Contains("### Ticket Estacionameno Alura ###", consultado.Ticket);
    }

    [Fact]
    public void AlterarDadosDoProprioVeiculo()
    {
      //Arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = operador;
      veiculo.Proprietario = "André luiz silva da hora";
      veiculo.Tipo = TipoVeiculo.Automovel;
      veiculo.Cor = "Verde";
      veiculo.Placa = "ZXC-8524";
      veiculo.Modelo = "Opala";

      estacionamento.RegistrarEntradaVeiculo(veiculo);

      var veiculoAlterado = new Veiculo();
      veiculoAlterado.Proprietario = "Vanderlei campos moura";
      veiculoAlterado.Tipo = TipoVeiculo.Automovel;
      veiculoAlterado.Cor = "azul";
      veiculoAlterado.Modelo = "BMW";
      veiculoAlterado.Placa = "ZXC-8524";


      //act 
      var alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

      //assert
      Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
    }

    [Fact]
    public void FecharPortaoPatio()
    {
      //arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = operador;

      //act
      bool fechouPortao = estacionamento.FecharPortao();

      //assert
      Assert.Equal(fechouPortao, estacionamento.PortaoAberto);
    }

    [Fact]
    public void AbrirPortaoPatio()
    {
      //arrange
      var estacionamento = new Patio();
      estacionamento.OperadorPatio = operador;

      //act
      bool abriuPortao = estacionamento.AbrirPortao();

      //assert
      Assert.Equal(abriuPortao, estacionamento.PortaoAberto);
    }

    public void Dispose()
    {
      SaidaConsoleTest.WriteLine("Dispose invocado");
    }
  }
}
