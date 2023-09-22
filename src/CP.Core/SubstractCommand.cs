namespace CP.Core
{
    public class SubstractCommand : ICommand
    {
        private double _operand;

        public SubstractCommand(CalculatorReceiver receiver, double operand) : base(receiver)
        {
            _operand = operand;
        }

        public override void Execute()
        {
            _receiver.Subtract(_operand);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}