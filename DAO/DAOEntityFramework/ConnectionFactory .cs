using DAOEntityFramework.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAOEntityFramework
{
	public class ConnectionFactory
	{
        private bool disposedValue = false; // To detect redundant calls

        public AppContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<AppContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;
            var context = new AppContext(option);

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
