using DIMI.WebApi.Services.Interfaces;

namespace DIMI.WebApi.Services
{
    public abstract class Service : IService
    {
        public Guid Id { get; set; }

        protected Service() 
        {
            Id = Guid.NewGuid();
        }
    }
}
