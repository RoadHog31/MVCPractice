namespace MVCPractice
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using MVCPractice.Models;
    using MVCPractice.Data;

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {            
            MVCGridDefinitionTable.Add("PersonTestGrid", new MVCGridBuilder<Person>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add().WithColumnName("First Name")
                        .WithHeaderText("First Name")
                        .WithValueExpression(i => i.FirstName); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Last Name")
                        .WithHeaderText("Last Name")
                        .WithValueExpression(i => i.LastName);
                    cols.Add().WithColumnName("Age")
                        .WithHeaderText("Age")
                        .WithValueExpression(i => i.Age.ToString());
                    cols.Add().WithColumnName("Is Active?")
                        .WithHeaderText("Is Active")
                        .WithValueExpression(i => i.IsActive.ToString());
                })
                .WithRetrieveDataMethod((context) =>
                {
                    // Query your data here. Obey Ordering, paging and filtering parameters given in the context.QueryOptions.
                    // Use Entity Framework, a module from your IoC Container, or any other method.
                    // Return QueryResult object containing IEnumerable<YouModelItem>

                    var result = new QueryResult<Person>();
                    using (var db = new ApplicationDbContext())
                    {
                        //TO DO: p.IsActive only returns active rows not all rows.
                        result.Items = db.Persons.Where(p => p.IsActive).ToList();
                    }
                    return result;

                })
            );
            
        }
    }
}