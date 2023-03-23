using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Windows.Themes;
using System.Xml.Linq;
using System.Reflection.Metadata;
using System.Windows.Interop;

namespace Practice10._6_Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // initialize start visibility
            infoLabel.Visibility = Visibility.Hidden;
            AddButton.Visibility = Visibility.Hidden;
            EditButton.Visibility = Visibility.Hidden;
            AddButton.IsEnabled = false;
            SeriesTextBlock.IsEnabled = false;
            NumberTextBlock.IsEnabled = false;
            SurnameTextBlock.IsEnabled = false;
            NameTextBlock.IsEnabled = false;
            PatronymicTextBlock.IsEnabled = false;

            // generate file if not exists + transfer data from file to list box  
            string path = FileCheck();
            FileToWPFListBox();
        }

        // generate some content if file doesn't exist (for easier code-checking)
        // returns generated client
        private Client GeneratingContent()
        {
            Random rng = new Random();

            string[] surnames = { "Смирнов", "Иванов", "Кузнецов", "Соколов", "Попов", "Лебедев", "Козлов" };
            List<string> surnamesList = new List<string>(surnames);
            string[] names = { "Александр", "Сергей", "Дмитрий", "Андрей", "Алексей", "Максим", "Евгений" };
            List<string> namesList = new List<string>(names);
            string[] patronymics = { "Александрович", "Максимович", "Иванович", "Владимирович", "Михаилович", "Андреевич", "Алексеевич" };
            List<string> patronymicsList = new List<string>(patronymics);

            
            int rngIndex;
            rngIndex = rng.Next(surnamesList.Count);
            string surname = surnamesList[rngIndex];
            rngIndex = rng.Next(namesList.Count);
            string name = namesList[rngIndex];
            rngIndex = rng.Next(patronymicsList.Count);
            string patronymic = patronymicsList[rngIndex];

            string passportSeries = rng.Next(1000, 10000).ToString();
            string passportNumber = rng.Next(100000, 1000000).ToString();

            string phone = "89" + rng.Next(100000000, 1000000000).ToString();

            Client generatedClient = new Client(surname, name, patronymic, passportSeries, passportNumber, phone);

            return generatedClient;
        }

        // create file if it doesn't exist and generate content
        // returns path
        public string FileCheck()
        {
            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
            path = path.Parent.Parent.Parent;
            if (!File.Exists(path + @"\client.txt"))
            {
                Client[] clientList = new Client[11];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    clientList[i] = GeneratingContent();
                    clientList[i].Id = i.ToString();
                    sb.AppendLine(clientList[i].ClientToString());
                }
                clientList[10] = GeneratingContent();
                clientList[10].Id = "10";
                sb.Append(clientList[10].ClientToString());
                FileStream fs = File.Create(path + @"\client.txt");
                using (StreamWriter streamWriter = new StreamWriter(fs))
                {
                    streamWriter.WriteLine(sb);
                }
                fs.Close();
                Console.WriteLine($"client.txt successfully created at {path}.");
            }
            return (path + @"\client.txt");
        }

        // get all clients in the file
        // returns array of Client objects
        private Client[] GetAllClients()
        {
            string path = FileCheck(); 

            string[] lines = File.ReadAllLines(path);
            Client[] clients = new Client[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                clients[i] = new Client(lines[i].Split('#')[0], lines[i].Split('#')[1],
                    lines[i].Split('#')[2], lines[i].Split('#')[3],
                    lines[i].Split('#')[4], lines[i].Split('#')[5], lines[i].Split('#')[6]);
            }
            return clients;
        }

        // shows client info
        private void ListBoxClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // shows the details of selected client
            infoLabel.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;

            // unlocks some functions if manager was selected 
            if (ChoiseBox.SelectedIndex == 1)
            {
                AddButton.IsEnabled = true;
                SurnameTextBlock.IsEnabled = true;
                NameTextBlock.IsEnabled = true;
                PatronymicTextBlock.IsEnabled = true;
            }

            if (ListBoxClients.SelectedItem != null)
            {
                ClientListBox clb = (ClientListBox)ListBoxClients.SelectedItem;
                Client selectedClient = clb.Client;
                Consultant cons = new Consultant(selectedClient.Surname, selectedClient.Name, selectedClient.Patronymic,
            selectedClient.PassportSeries, selectedClient.PassportNumber, selectedClient.Phone);
                Manager mng = new Manager(selectedClient.Surname, selectedClient.Name, selectedClient.Patronymic,
            selectedClient.PassportSeries, selectedClient.PassportNumber, selectedClient.Phone);
                SurnameTextBlock.Text = cons.Surname;
                NameTextBlock.Text = cons.Name;
                PatronymicTextBlock.Text = cons.Patronymic;
                if (ChoiseBox.SelectedIndex == 0)
                {
                    SeriesTextBlock.Text = cons.PassportSeries;
                    NumberTextBlock.Text = cons.PassportNumber;
                }
                else
                {
                    SeriesTextBlock.Text = mng.PassportSeries;
                    NumberTextBlock.Text = mng.PassportNumber;
                }
                PhoneTextBlock.Text = cons.Phone;
            }
        }

        // changes client info after selecting a consultant or manager
        private void ChoiseBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // consultant case
            if ((ChoiseBox.SelectedIndex == 0) && (ListBoxClients != null) && (ListBoxClients.SelectedItem != null))
            {
                ClientListBox clb = (ClientListBox)ListBoxClients.SelectedItem;
                Client selectedClient = clb.Client;
                Consultant cons = new Consultant(selectedClient.Surname, selectedClient.Name, selectedClient.Patronymic,
            selectedClient.PassportSeries, selectedClient.PassportNumber, selectedClient.Phone);
                SeriesTextBlock.Text = cons.PassportSeries;
                NumberTextBlock.Text = cons.PassportNumber;

                //locks some functions for consultant
                AddButton.IsEnabled = false;
                SeriesTextBlock.IsEnabled = false;
                NumberTextBlock.IsEnabled = false;
                SurnameTextBlock.IsEnabled = false;
                NameTextBlock.IsEnabled = false;
                PatronymicTextBlock.IsEnabled = false;
            }
            // manager case
            else if ((ListBoxClients != null) && (ListBoxClients.SelectedItem != null))
            {
                ClientListBox clb = (ClientListBox)ListBoxClients.SelectedItem;
                Client selectedClient = clb.Client;
                Manager mng = new Manager(selectedClient.Surname, selectedClient.Name, selectedClient.Patronymic,
            selectedClient.PassportSeries, selectedClient.PassportNumber, selectedClient.Phone);

                SeriesTextBlock.Text = selectedClient.PassportSeries;
                NumberTextBlock.Text = selectedClient.PassportNumber;

                //unlocks some functions for manager
                AddButton.IsEnabled = true;
                SurnameTextBlock.IsEnabled = true;
                NameTextBlock.IsEnabled = true;
                PatronymicTextBlock.IsEnabled = true;
            }
        }

        // adds client to the file and list box
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((PhoneTextBlock.Text != null) && (PhoneTextBlock.Text != ""))
            {
                ErrorTextBlock.Text = ""; // ErrorTextBlock needs for the case of empty phone number

                ClientListBox clb = (ClientListBox)ListBoxClients.SelectedItem;
                Client selectedClient = clb.Client;
                int selectedId = Convert.ToInt32(selectedClient.Id); // for reloading active client

                Client addClient = new Client(SurnameTextBlock.Text, NameTextBlock.Text, PatronymicTextBlock.Text,
                selectedClient.PassportSeries, selectedClient.PassportNumber, PhoneTextBlock.Text, GetAllClients().Length.ToString());

                AddClient(addClient);
                FileToWPFListBox();
                ListBoxClients.SelectedItem = ListBoxClients.Items[selectedId];
            }
            else if (PhoneTextBlock.Text == "")
            {
                ErrorTextBlock.Text = "Это поле не должно быть пустым";
            }
        }

        // edits client info 
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if ((PhoneTextBlock.Text != null) && (PhoneTextBlock.Text != ""))
            {
                ErrorTextBlock.Text = ""; // ErrorTextBlock needs for the case of empty phone number

                ClientListBox clb = (ClientListBox)ListBoxClients.SelectedItem;
                Client selectedClient = clb.Client;
                int selectedId = Convert.ToInt32(selectedClient.Id);
                Client[] clients = GetAllClients();

                IDataEdition dataEdit;
                if (ChoiseBox.SelectedIndex == 0)
                {
                    dataEdit = new Consultant();
                }
                else
                {
                    dataEdit = new Manager();
                }
                Client editedClient = new Client(SurnameTextBlock.Text, NameTextBlock.Text, PatronymicTextBlock.Text,
                selectedClient.PassportSeries, selectedClient.PassportNumber, PhoneTextBlock.Text, selectedClient.Id);
                clients[selectedId] = dataEdit.Edit(selectedClient, editedClient);
                clients[selectedId].Id = selectedId.ToString();


                // refreshing the list box
                List<ClientListBox> items = new List<ClientListBox>();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < clients.Length; i++)
                {
                    sb.AppendLine(clients[i].ClientToString());
                    items.Add(new ClientListBox()
                    {
                        Initials = "Фамилия: " +
                        clients[i].Surname + "\n" +
                        "Имя: " + clients[i].Name + "\n" +
                        "Отчество: " + clients[i].Patronymic + "\n"
                        ,
                        Phone = clients[i].Phone,
                        Client = clients[i],
                        DateTimeEdit = clients[i].DateTimeEdit,
                        PersonEdit = clients[i].PersonEdit,
                        DataEdit = clients[i].DataEdit
                    }); 
                }
                ListBoxClients.ItemsSource = items;
                ListBoxClients.SelectedItem = ListBoxClients.Items[selectedId];

                // rewriting the file
                string path = FileCheck();
                using (StreamWriter streamWriter = new StreamWriter(path, false))
                {
                    streamWriter.Write(sb);
                }
            }
            else if (PhoneTextBlock.Text == "")
            {
                ErrorTextBlock.Text = "Это поле не должно быть пустым";
            }

        }

        // adds client to file
        private void AddClient(Client client)
        {
            string path = FileCheck(); // file checking + returns path
            string[] lines = File.ReadAllLines(path);

            StringBuilder outputLine = new StringBuilder();
            outputLine.Append(client.ClientToString());
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(outputLine);
            }

        }

        // transfer file data to list box
        private void FileToWPFListBox()
        {
            Client[] clients = GetAllClients();
            List<ClientListBox> items = new List<ClientListBox>();
            for (int i = 0; i < clients.Length; i++)
            {
                items.Add(new ClientListBox()
                {
                    Initials = "Фамилия: " +
                    clients[i].Surname + "\n" +
                    "Имя: " + clients[i].Name + "\n" +
                    "Отчество: " + clients[i].Patronymic + "\n"
                    ,
                    Phone = clients[i].Phone,
                    Client = clients[i]
                }); ;
            }
            ListBoxClients.ItemsSource = items;
        }

    }
}

