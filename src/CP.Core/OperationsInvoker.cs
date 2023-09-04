namespace CP.Core
{
    public class OperationsInvoker
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void TakeOrder(ICommand command)
        {
            _commands.Add(command);
        }

        public void Process()
        {
            foreach (ICommand command in _commands)
            {
                command.Execute();
            }

            _commands.Clear();
        }
    }
}