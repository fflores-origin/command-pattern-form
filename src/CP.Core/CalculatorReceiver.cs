using CP.Data;
using Microsoft.Extensions.Configuration;

namespace CP.Core
{
    public class CalculatorReceiver
    {
        private double result = 0;
        private double currentNumber = 0;
        private ICommand currentCommand;
        private readonly OrdenesRepository _ordenesRepository;
        private readonly IConfiguration _configuration;

        private readonly bool _useDB;

        public CalculatorReceiver(OrdenesRepository ordenesRepository, IConfiguration configuration)
        {
            _ordenesRepository = ordenesRepository;
            _configuration = configuration;

            _useDB = Convert.ToBoolean(_configuration["Initial:UseDb"]);
        }

        public double Result
        { get { return result; } }

        public void SetCommand(ICommand command) => currentCommand = command;

        public void SetNumber(double number) => currentNumber = number;

        public void Clear()
        {
            result = 0;
            currentNumber = 0;
        }

        public void ExecuteCommand() => currentCommand.Execute();

        public void Add(double operand)
        {
            result += operand;
            if (_useDB)
                _ordenesRepository.SaveOrUpdate("ADD", currentNumber.ToString());
        }

        public void Subtract(double operand)
        {
            result -= operand;
            if (_useDB)
                _ordenesRepository.SaveOrUpdate("SUBSTRACT", currentNumber.ToString());
        }
    }
}