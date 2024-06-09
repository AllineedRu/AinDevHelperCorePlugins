﻿using System;

namespace AinDevHelperChainOfResponsibilityPattern {
    /// <summary>
    /// Конкретный обработчик - "Банковский менеджер"
    /// </summary>
    public class BankManager : ICreditApprover {
        private ICreditApprover _nextApprover;

        public void ProcessRequest(CreditRequest request) {
            if (request.Amount <= 10000) {
                Console.WriteLine("Заявка на кредит одобрена банковским менеджером.");
            } else if (_nextApprover != null) {
                _nextApprover.ProcessRequest(request);
            }
        }

        public void SetNextApprover(ICreditApprover nextApprover) {
            _nextApprover = nextApprover;
        }
    }
}
