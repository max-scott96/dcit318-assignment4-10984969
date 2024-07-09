namespace AddressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            String Name = txtName.Text;
            String Email = txtEmail.Text;
            String PhoneNumber = txtPhoneNumber.Text;


            MessageBox.Show($"Name: {Name} \nEmail: {Email} \nPhone Number: {PhoneNumber}", "Saved Info");
        }
    }
}
