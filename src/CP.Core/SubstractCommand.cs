namespace CP.Core
{
    public class SubstractCommand : ICommand
    {
        public SubstractCommand(CalculatorReceiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            _receiver.Subtract();
        }
    }
}