using System.Collections.Generic;
using System.Net.Mail;

namespace PTCS.Solid.Examples
{
    public class Employer
    {
        
        // Only cares about reports and has to pay the employees

        private readonly List<Developer> _developers;
        private readonly List<SuperMiddleManager> _superMiddleManagers;
        private readonly Accounting _accounting;

        private const string TaxManEmailAddress = "theman@taxes.foo";

        public Employer()
        {
            _accounting = new Accounting();
            _developers = new List<Developer>();
            _superMiddleManagers = new List<SuperMiddleManager>();
        }

        public void AddDeveloper(Developer developer)
        {
            _developers.Add(developer);
        }

        public void AddSuperMiddleManager(SuperMiddleManager superMiddleManager)
        {
            _superMiddleManagers.Add(superMiddleManager);
        }
        
        public void PaySalaries()
        {
            // A fair start-up company pays everyone the same amount
            const decimal salary = 1001.5m;

            foreach (var developer in _developers)
            {
                developer.GetPayed(salary);
            }

            foreach (var superMiddleManager in _superMiddleManagers)
            {
                superMiddleManager.GetPayed(salary);
            }
            
            // Changing requirements:
            // - Company is doing well and starts hiring super coders that need more moneys!
            // - Hiring all those super coders means that more managers are needed but there is only enough money for simple manager thar require less moneys!
            
            // Bonus: completely unnecessary premature optimization based on assumptions.
            decimal totalSalaryPayed = salary * (_developers.Count + _superMiddleManagers.Count);


            _accounting.AddToBooks(totalSalaryPayed);
            
            // Accounting told that the taxman needs to be informed about the salaries by email (direct translation from change request to code).
            // Boom! Mixed abstractions!
            var emailClient = new SmtpClient("EmailHost");
            
            emailClient.Send("salaries@company.com", TaxManEmailAddress, "Salaries payed this month", $"Payed {totalSalaryPayed}.");
        }
        
        public void ReceiveReport(SuperMiddleManager superMiddleManager)
        {
            // Increase business wisdom by looking at that fish animation generated from all those reports
        }
    }
}