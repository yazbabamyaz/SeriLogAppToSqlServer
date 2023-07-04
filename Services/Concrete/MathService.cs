using LogAppGiris.Services.Abstract;
using Serilog.Context;

namespace LogAppGiris.Services.Concrete
{
    public class MathService : IMathService
    {
		private readonly ILogger<MathService> _logger;

        public MathService(ILogger<MathService> logger)
        {
            _logger = logger;
        }
        //public MathService(ILogger logger)=> (_logger) = (logger);


        public decimal Divide(decimal value1, decimal value2)
        {
            _logger.LogInformation("Değer 1:{0}",value1);
            _logger.LogInformation($"Değer2: {value2}");
            LogContext.PushProperty("Payda", value2);
            decimal result = decimal.Zero;
			try
			{
                result = value1 / value2;
			}
			catch (DivideByZeroException ex)
			{
                _logger.LogWarning(ex.Message,"You cannot divide by zero.");
                
                throw ex;
			}
            return result;
        }
    }
}
