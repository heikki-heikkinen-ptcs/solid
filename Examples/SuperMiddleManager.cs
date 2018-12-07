namespace PTCS.Solid.Examples
{
    public class SuperMiddleManager
    {
        private readonly Employer _employer;

        public SuperMiddleManager()
        {
            _employer = new Employer();
        }
        
        public void ManageProject(Project project)
        {
            // Project management code
            project.Manage();
        }

        public void ManageDeveloper(Developer developer)
        {
            // Developer management code
            developer.GetManaged();
        }

        // Changing requirement: Also needs to manage secretaries
        
        public void SellToCustomer(Customer customer, Service service)
        {
            // Convince customer that they need our service
            customer.GetSoldTo(service);

        }
        
        // Changing requirements: Also needs to sell products on top of services.


        public void ReportToEmployer()
        {
            _employer.ReceiveReport(this);
        }
        
        // What is wrong this this code?
        // How can we make this adhere to SOLID principles?

        public void GetPayed(decimal salary)
        {
            // Invest in that new startup
        }
    }
}