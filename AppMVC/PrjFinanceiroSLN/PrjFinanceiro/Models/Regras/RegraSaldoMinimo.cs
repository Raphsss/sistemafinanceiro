using PrjFinanceiro.Models.Interfaces;

namespace PrjFinanceiro.Models.Regras
{
    public class RegraSaldoMinimo : IRegraEscore
    {
        public int CalcularPontuacao(Cliente cliente, ContaBancaria conta)
        {
            if (conta.Saldo < 100m)
                return -30;

            return 0;
        }
    }
}
