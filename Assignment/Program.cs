using Assignment.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

           

            using (NorthwindDbContext context = new NorthwindDbContext())
            {
                #region Stored Procedure

                //NorthwindDbContextProcedures contextProcedures = new NorthwindDbContextProcedures(context);

                //var Procedures = contextProcedures.SalesByCategoryAsync("Beverages", "1998").Result;

                //foreach (var Procedure in Procedures)
                //    Console.WriteLine($"{Procedure.ProductName} :: {Procedure.TotalPurchase}");

                #endregion


                #region Run Sql Query 
                // 1. Execute Select Statement

                //var Result = context.Categories.FromSqlRaw("select * from Categories ").ToList();
                // var Result = context.Categories.FromSqlInterpolated($"select * from Categories ").ToList();

                //var Result = context.Categories.Where(x => x.CategoryName == "Beverages");

                //foreach (var item  in Result) 
                //    Console.WriteLine($" {item.CategoryName} :: {item.Description}");


                // 2. Execute DML Statement

                // context.Database.ExecuteSqlInterpolated($"update Products set ProductName = 'Chai02' where ProductId ={1}" );
                #endregion

                #region Lazy Loading Vs Eager Loading Vs Explicit Loading


                //var product = context.Products.Include(x => x.Category).ThenInclude(x =>x.Products).FirstOrDefault();

                //var CategoryName = product.Category.CategoryName;


                var product = context.Products.FirstOrDefault();


                context.Entry(product).Reference(x => x.Category).Load();

                var CategoryName = product.Category.CategoryName;

                #endregion



            }




        }
    }
}
