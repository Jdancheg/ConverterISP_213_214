using ConverterLib;

namespace Converter2024App
{
    public partial class Form1 : Form
    {
        Manager cm = new Manager();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(cm.GetPhysicValuesList().ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            string valueName = comboBox1.Text;
            string from = comboBox2.Text;
            string to = comboBox3.Text;

            textBox2.Text = cm.GetConvertedValue(num, valueName,from,to).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(cm.GetMeasureList(comboBox1.Text).ToArray());
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(cm.GetMeasureList(comboBox1.Text).ToArray());
            comboBox3.SelectedIndex = 0;
        }
    }
}