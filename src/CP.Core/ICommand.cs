namespace CP.Core
{
    public abstract class ICommand
    {
        public abstract void Execute();

        public abstract void Undo();

        protected CalculatorReceiver _receiver;

        public ICommand(CalculatorReceiver receiver)
        {
            _receiver = receiver;
        }
    }
}