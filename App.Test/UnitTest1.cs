using Application.Interfaces.Repoitories;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IUnitOfWork _unitOfWork;
        public IConfiguration Configuration;
        private IServiceCollection Services;


        public UnitTest1(IUnitOfWork unitOfWork, IConfiguration configuration, IServiceCollection services)
        {
            _unitOfWork = unitOfWork;
            Configuration = configuration;
            Services = services;

            Services.AddInfrastructure(Configuration);
        }


        [TestMethod]
        public void TestMethod1()
        {
            var unitOfWorkMock = _unitOfWork.Documentos.GetAll();
            Assert.AreEqual(unitOfWorkMock.First(), "Cedula");

        }
    }
}
