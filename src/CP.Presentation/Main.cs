using CP.Core;

namespace CP.Presentation
{
    public partial class Main : Form
    {
        private readonly CalculatorReceiver _receiver;
        private readonly OperationsInvoker _invoker = new();
        private readonly List<string> _history = new();

        private bool shouldClean = false;

        public Main(CalculatorReceiver receiver)
        {
            InitializeComponent();
            _receiver = receiver;
        }

        private void SetButtonValue(int value)
        {
            if (shouldClean) { input.Text = "0"; shouldClean = false; }

            var valueAsText = $"{input.Text}{value}";

            if (input.Text == "0")
            {
                valueAsText = $"{value}";
            }

            input.Text = valueAsText;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _history.Add($"+ {input.Text}");
            UpdateHistoryListBox();
            ICommand command = new AddCommand(_receiver, double.Parse(input.Text));
            _invoker.TakeOrder(command);
            lblResult.Text = _receiver.Result.ToString();
            input.Text = "0";
        }

        private void btnSubstract_Click(object sender, EventArgs e)
        {
            _history.Add($"- {input.Text}");
            UpdateHistoryListBox();
            ICommand command = new SubstractCommand(_receiver, double.Parse(input.Text));
            _invoker.TakeOrder(command);
            lblResult.Text = _receiver.Result.ToString();
            input.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            _invoker.Process();
            _history.Add($"= {_receiver.Result}");
            input.Text = _receiver.Result.ToString();
            lblResult.Text = _receiver.Result.ToString();
            UpdateHistoryListBox();
            _receiver.Clear();
            shouldClean = true;
        }

        private void UpdateHistoryListBox()
        {
            lbHistory.Items.Clear();
            lbHistory.Items.AddRange(_history.ToArray());
        }

        #region NumbersButtonsAction

        private void btn9_Click(object sender, EventArgs e) => SetButtonValue(9);

        private void btn8_Click(object sender, EventArgs e) => SetButtonValue(8);

        private void btn7_Click(object sender, EventArgs e) => SetButtonValue(7);

        private void btn6_Click(object sender, EventArgs e) => SetButtonValue(6);

        private void btn5_Click(object sender, EventArgs e) => SetButtonValue(5);

        private void btn4_Click(object sender, EventArgs e) => SetButtonValue(4);

        private void btn3_Click(object sender, EventArgs e) => SetButtonValue(3);

        private void btn2_Click(object sender, EventArgs e) => SetButtonValue(2);

        private void btn1_Click(object sender, EventArgs e) => SetButtonValue(1);

        private void btn0_Click(object sender, EventArgs e) => SetButtonValue(0);

        private void btnAC_Click(object sender, EventArgs e)
        {
            _receiver.Clear();
            input.Text = "0";
        }

        #endregion NumbersButtonsAction
    }
}