using System;
using System.Collections.Generic;
using ApprovalCommon;

namespace Approval
{
    class Approval
    {
        static void Main()
        {
            List<Employee> managers = new List<Employee>
                                          {
                                              new Employee("William Worker", Decimal.Zero),
                                              new Employee("Mary Manager", new Decimal(1000)),
                                              new Employee("Victor Vicepres", new Decimal(5000)),
                                              new Employee("Paula President", new Decimal(20000)),
                                          };

            Decimal expenseReportAmount;
            while (ConsoleInput.TryReadDecimal("Expense report amount:", out expenseReportAmount))
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                bool expenseProcessed = false;

                foreach (Employee approver in managers)
                {
                    ApprovalResponse response = approver.ApproveExpense(expense);

                    if (response != ApprovalResponse.BeyondApprovalLimit)
                    {
                        Console.WriteLine("The request was {0}.", response);
                        expenseProcessed = true;
                        break;
                    }
                }

                if (!expenseProcessed)
                {
                    Console.WriteLine("No one was able to approve your expense.");
                }
            }
        }
    }
}
