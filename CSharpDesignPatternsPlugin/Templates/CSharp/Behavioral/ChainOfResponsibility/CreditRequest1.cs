namespace AinDevHelperChainOfResponsibilityPattern {
    /// <summary>
    /// Заявка на кредит
    /// </summary>
    public class CreditRequest {
        public double Amount { get; set; }

        public CreditRequest(double amount) {
            Amount = amount;
        }
    }
}
