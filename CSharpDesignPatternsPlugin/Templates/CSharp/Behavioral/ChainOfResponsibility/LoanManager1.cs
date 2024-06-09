using System;

namespace AinDevHelperChainOfResponsibilityPattern {
    /// <summary>
    /// Другой конкретный обработчик - "Менеджер по кредитам"
    /// </summary>
    public class LoanManager : ICreditApprover {
        private ICreditApprover _nextApprover;

        public void ProcessRequest(CreditRequest request) {
            if (request.Amount > 10000 && request.Amount <= 50000) {
                Console.WriteLine("Заявка на кредит одобрена менеджером по кредитам.");
            } else if (_nextApprover != null) {
                _nextApprover.ProcessRequest(request);
            }
        }

        public void SetNextApprover(ICreditApprover nextApprover) {
            _nextApprover = nextApprover;
        }
    }
}
