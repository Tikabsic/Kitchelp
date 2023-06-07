using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> Create<TEntity>() where TEntity : class
        {
            var repositoryType = typeof(IRepository<>).MakeGenericType(typeof(TEntity));
            return (IRepository<TEntity>)_serviceProvider.GetRequiredService(repositoryType);
        }
    }
}
