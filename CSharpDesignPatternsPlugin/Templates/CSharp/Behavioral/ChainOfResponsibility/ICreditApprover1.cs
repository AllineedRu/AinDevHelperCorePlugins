namespace AinDevHelperChainOfResponsibilityPattern {
    /// <summary>
    /// Общий интерфейс для обработчиков
    /// </summary>
    public interface ICreditApprover {
        void ProcessRequest(CreditRequest request);
        void SetNextApprover(ICreditApprover nextApprover);
    }
}
