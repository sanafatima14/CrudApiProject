using CrudApiProject.Data;
using CrudApiProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiProject.Services
{
    public class base_service
    {
        protected readonly api_demo_db_class _dbContext;

        public base_service(api_demo_db_class dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
