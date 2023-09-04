namespace CP.Core
{
    public abstract class ICommand
    {
        public abstract void Execute();

        protected CalculatorReceiver _receiver;

        public ICommand(CalculatorReceiver receiver)
        {
            _receiver = receiver;
        }
    }
}