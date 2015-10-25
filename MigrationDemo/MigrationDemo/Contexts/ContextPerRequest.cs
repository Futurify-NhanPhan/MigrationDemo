using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigrationDemo.Contexts
{
    public class ContextPerRequest
    {
        
    
        private const string myDbPerRequestContext = "MDPRC";

        public static DemoContext Db
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(myDbPerRequestContext))
                {
                    var context = new DemoContext();
                    HttpContext.Current.Items.Add(myDbPerRequestContext, context);
                }

                return HttpContext.Current.Items[myDbPerRequestContext] as DemoContext;
            }
        }

        /// <summary>
        /// Called automatically on Application_EndRequest()
        /// </summary>
        public static void DisposeDbContextPerRequest()
        {
            // Getting dbContext directly to avoid creating it in case it was not already created.
            var entityContext = HttpContext.Current.Items[myDbPerRequestContext] as DemoContext;
            if (entityContext != null)
            {
                entityContext.Dispose();
                HttpContext.Current.Items.Remove(myDbPerRequestContext);
            }
        }
    }
}
