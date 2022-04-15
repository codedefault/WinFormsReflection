using System.Reflection;

namespace WinFormsReflection
{
    public partial class FrmMain : Form
    {
        private readonly Assembly _assembly;
        public FrmMain()
        {
            _assembly = Assembly.LoadFrom(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libs", "WinFormsLibrary1.dll")
                );
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm("Frm01");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm("Frm02");
        }

        private void LoadForm(string formName)
        {
            var form = (Form)Activator.CreateInstance(_assembly.GetType($"WinFormsLibrary1.{formName}"));
            form?.ShowDialog();
        }
    }
}