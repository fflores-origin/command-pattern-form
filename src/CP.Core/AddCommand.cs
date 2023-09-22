namespace CP.Core
{
    public class AddCommand : ICommand
    {
        private double _operand;
        public AddCommand(CalculatorReceiver receiver, double operand) : base(receiver)
        {
            _operand = operand;
        }

        public override void Execute()
        {
            _receiver.Add(_operand);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}