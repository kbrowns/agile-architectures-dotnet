using AA.Domain.Exceptions;

namespace AA.Domain;

public static class ServiceProviderRoot
{
    private static IServiceProvider _serviceProvider;
        
    public static void Initialize(IServiceProvider services)
    {
        _serviceProvider = services;
    }
        
    public static IServiceProvider Services
    {
        get
        {
            if (_serviceProvider == null) 
                throw new SystemConfigurationException( "ServiceProviderRoot not initialized");
                
            return _serviceProvider;
        } 
        private set => _serviceProvider = value;
    }
}