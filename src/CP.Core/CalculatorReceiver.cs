using CP.Data;

namespace CP.Core
{
    public class CalculatorReceiver
    {
        private double result = 0;
        private double currentNumber = 0;
        private ICommand currentCommand;
        private readonly OrdenesRepository _ordenesRepository;

        public CalculatorReceiver(OrdenesRepository ordenesRepository) => _ordenesRepository = ordenesRepository;

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

        public void Add()
        {
            result += currentNumber;
            _ordenesRepository.SaveOrUpdate("ADD", currentNumber.ToString());
        }

        public void Subtract()
        {
            result -= currentNumber;
            _ordenesRepository.SaveOrUpdate("SUBSTRACT", currentNumber.ToString());
        }
    }
}