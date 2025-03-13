using Assignment.Contexts;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using (NorthwindDbContext context = new NorthwindDbContext())
            {

                NorthwindDbContextProcedures contextProcedures = new NorthwindDbContextProcedures(context);

                var Procedures = contextProcedures.SalesByCategoryAsync("Beverages","1998").Result;

                foreach (var Procedure in Procedures)
                    Console.WriteLine($"{Procedure.ProductName} :: {Procedure.TotalPurchase}");
               


            }
        }
    }
}
