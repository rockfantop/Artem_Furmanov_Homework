using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassPractice2
{
    class CustomerQueriesLINQ
    {
        private List<Customer> customers;

        public CustomerQueriesLINQ(List<Customer> customers)
        {
            this.customers = customers;
        }

        public Customer GetFirstRegistretedCustomer()
        {
            return customers.OrderBy(x => x.RegistrationDate).FirstOrDefault();
        }

        public double CustomersBalanceAverage()
        {
            return customers.Average(x => x.Balance);
        }

        public void CustomersFilterByDate(DateTime x, DateTime y)
        {
            customers = customers.Where(i => i.RegistrationDate > x && i.RegistrationDate < y).ToList();

            if (customers == null)
            {
                Console.WriteLine("No results");
            }
        }

        public void CustomersFilterById(long id)
        {
            customers = customers.Where(i => i.Id == id).ToList();
        }

        public void CustomersFilterByName(string name)
        {
            customers = customers.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public void CustomersFilterByMonth()
        {
            customers = customers.OrderBy(i => i.RegistrationDate.Month).ThenBy(i => i.Name).ToList();
        }

        public void CustomersFilterByProperty(string property, string orderBy)
        {
            if (orderBy == "ascending")
            {
                customers = customers.OrderBy(i => i.GetType().GetProperty(property).GetValue(i)).ToList();
            }
            else
            {
                customers = customers.OrderByDescending(i => i.GetType().GetProperty(property).GetValue(i)).ToList();
            }
        }

        public void PrintCustomers()
        {
            customers.ForEach(i => { Console.WriteLine(i.Name + i.RegistrationDate + ", "); });
        }
    }
}
