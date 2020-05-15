
namespace SoluçãoSemInterface.Services
{
    class BrasilTaxService : ITaxService // Isto aqui e uma realizacao de interface, nao e heranca...
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}
