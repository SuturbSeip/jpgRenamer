namespace jpgRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = (Directory.GetFiles(textBox1.Text)).Where(file => file.EndsWith(".jpg", StringComparison.Ordinal)).ToArray();
            string raport = "";
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string newName;
                if (fileName.Contains(' '))
                {
                    newName = fileName.Substring(0, fileName.IndexOf(' ')) + ".jpg";

                    string newFile = file.Replace(fileName, newName);
                    if (!File.Exists(newFile))
                    {
                        File.Move(file, newFile);
                        raport += "\"" + fileName + "\" renamed to: \"" + newName + "\"" + Environment.NewLine;
                    }
                    else raport += "There is already a file named: \"" + newName + "\". \"" + fileName + "\" skipped." + Environment.NewLine;
                }
                else raport += "\"" + fileName + "\" skipped." + Environment.NewLine;
            }

            textBox2.Text = raport;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if (!Directory.Exists(path))
            {
                label3.Text = "Wrong path.";
                button1.Enabled = false;
                return;
            }

            if (!(Directory.GetFiles(path)).Any(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)))
            {
                label3.Text = "There are no .jpg files.";
                button1.Enabled = false;
            }
            else
            {
                label3.Text = "";
                button1.Enabled = true;
            }
        }

    }
}
