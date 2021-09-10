namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private Dictionary<string, Invoice> invoices;

        public Agency()
        {
            this.invoices = new Dictionary<string, Invoice>();
        }

        public void Create(Invoice invoice)
        {
            if (this.Contains(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            this.invoices.Add(invoice.SerialNumber, invoice);
        }

        public int Count() => this.invoices.Count;

        public bool Contains(string number)
        {
            return this.invoices.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            var counter = 0;

            foreach (var invoice in this.invoices)
            {
                if (invoice.Value.DueDate == due)
                {
                    invoice.Value.Subtotal = 0;
                    counter++;
                }
            }

            if (counter == 0)
            {
                throw new ArgumentException();
            }
        }

        public void ThrowInvoice(string number)
        {
            if (!this.Contains(number))
            {
                throw new ArgumentException();
            }

            this.invoices.Remove(number);
        }

        public void ThrowPayed()
        {
            foreach (var invoice in this.invoices)
            {
                if (invoice.Value.Subtotal == 0)
                {
                    this.invoices.Remove(invoice.Key);
                }
            }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            return this.invoices.Values
                .Where(x => x.IssueDate >= start && x.IssueDate <= end)
                .OrderBy(x => x.IssueDate)
                .ThenBy(x => x.DueDate);
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var result = this.invoices.Values.Where(x => x.SerialNumber.Contains(serialNumber)).OrderByDescending(x => x.SerialNumber);

            if (result.Count() == 0)
            {
                throw new ArgumentException();
            }

            return result;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var result = this.invoices.Values.Where(x => x.DueDate > start && x.DueDate < end);

            if (result.Count() == 0)
            {
                throw new ArgumentException();
            }

            foreach (var invoice in result)
            {
                this.invoices.Remove(invoice.SerialNumber);
            }

            return result;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            return this.invoices.Values
                   .Where(x => x.Department == department)
                   .OrderByDescending(x => x.Subtotal)
                   .ThenBy(x => x.IssueDate);
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            return this.invoices.Values
                   .Where(x => x.CompanyName == company)
                   .OrderByDescending(x => x.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            int counter = 0;

            foreach (var invoice in this.invoices)
            {
                if (invoice.Value.DueDate == dueDate)
                {
                    invoice.Value.DueDate = invoice.Value.DueDate.AddDays(days);
                    counter++;
                }
            }

            if (counter == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
