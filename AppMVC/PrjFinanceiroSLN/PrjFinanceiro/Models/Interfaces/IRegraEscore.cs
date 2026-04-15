namespace PrjFinanceiro.Models.Interfaces
{
    public interface IRegraEscore
    {
        int CalcularPontuacao(Cliente cliente, ContaBancaria conta);
    }
}
