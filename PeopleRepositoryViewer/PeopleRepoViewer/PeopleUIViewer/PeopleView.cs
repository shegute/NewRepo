using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeopleUIViewer
{
    public partial class PeopleView : Form
    {
        IPersonRepository personRepo;

        public PeopleView()
        {
            InitializeComponent();
        }

        public PeopleView(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ClearListViews();
            try
            {
                listView2.Items.Add(this.LogEntry("Disable Button"));
                button1.Enabled = false;
                bool? userInList = await IsUserInList(textBox1.Text);
                listView2.Items.Add(this.LogEntry("Authenticating"));
                if (userInList.HasValue ? userInList.Value : false)
                {
                    listView2.Items.Add(this.LogEntry("User found, call PopulateListView"));
                    this.PopulateListView();
                }
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private async Task<bool?> IsUserInList(string name)
        {
            var people = personRepo.GetPeople();
            foreach (var p in people)
            {
                if (p.FirstName.ToLower().Equals(name.ToLower()))
                {
                    System.Threading.Thread.Sleep(100);
                    listView2.Items.Add(this.LogEntry("User found, in IsUserInList"));
                    return true;
                }
            }

            listView2.Items.Add(this.LogEntry("User not found, in IsUserInList"));
            return false;
        }

        private void PrintHIEvery5Seconds()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(50);
                Action action = () => this.LogEntry(string.Format("Printing Hi", i));
                this.BeginInvoke(action);
            }
        }
        private void PopulateListView()
        {
            var people = personRepo.GetPeople();
            foreach (var p in people)
            {
                this.PrintHIEvery5Seconds();
                listView2.Items.Add(this.LogEntry(string.Format("Adding new person: {0}", p.FirstName)));
                listView1.Items.Add(p.FirstName + " " + p.LastName + " " + p.Gender);
            }

            listView2.Items.Add(this.LogEntry("Completed PopulateListView"));
        }

        private void ClearListViews()
        {
            listView1.Items.Clear(); listView2.Items.Clear();
        }

        public string LogEntry(string logEntry)
        {
            return string.Format("LOG:{0}, {1}", DateTime.Now.ToLocalTime(), logEntry);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
