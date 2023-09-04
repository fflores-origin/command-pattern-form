namespace CP.Core
{
    public class AddCommand : ICommand
    {
        public AddCommand(CalculatorReceiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            _receiver.Add();
        }
    }
}