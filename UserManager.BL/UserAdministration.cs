using UserManager.Models;

namespace UserManager.BL {
    public class UserAdministration {

        private bool _alreadyImported = false;

        // Feld
        private List<User> _users = new List<User>();

        // Eigenschaften
        public List<User> Users { get => _users; set => _users = value; }
        
        public void ListUsers() {
            foreach(User value in Users) {
                Console.WriteLine($"{value.UserID} {value.UserName} {value.FirstName} {value.LastName} {value.Email} {value.Birthdate:dd.MM.YYYY}");
            }
        }

        public void AddUser(User user) {
            Users.Add(user);
        }

        public void DeleteUser() {
            Console.WriteLine("Geben Sie die ID des zu löschenden Users ein: ");
            string input = Console.ReadLine();
            int id = Convert.ToInt32(input);
            Users.RemoveAt(id - 1);
            for(int i = 0; i < Users.Count; i++) {
                Users[i].UserID = i + 1;
            }
            ExportUsersCsv();
        }

        public void ModifyUser() {
            Console.WriteLine("Geben Sie die ID des zu modifizierenden Users ein: ");
            string input = Console.ReadLine();
            int id = Convert.ToInt32(input);
            Console.WriteLine("Geben Sie den neuen Benutzernamen ein: ");
            string newUserName = Console.ReadLine();
            Console.WriteLine("Geben Sie den neuen Vornamen ein: ");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Geben Sie den neuen Nachnamen ein: ");
            string newLastName = Console.ReadLine();
            Console.WriteLine("Geben Sie die neue Email ein: ");
            string newEmail = Console.ReadLine();
            Console.WriteLine("Geben Sie das neue Geburtsdatum ein: ");
            string newBirthdate = Console.ReadLine();
            Users[id - 1].UserName = newUserName;
            Users[id - 1].FirstName = newFirstName;
            Users[id - 1].LastName = newLastName;
            Users[id - 1].Email = newEmail;
            Users[id - 1].Birthdate = newBirthdate;
            ExportUsersCsv();
        }

        public void ExportUsersCsv() {
            string separator = ";";
            var lines = new List<string>();

            foreach(User user in Users) {
                lines.Add(
                    $"{user.UserID}{separator}{user.FirstName}{separator}{user.LastName}{separator}{user.UserName}{separator}{user.Email}{separator}{user.Birthdate:dd.MM.YYYY}");
            }

            File.WriteAllLines(@"C:\Users\noahr\source\repos\UserManager\users.csv", lines);
        }

        public void ImportUsersCSV(string path, string separator = ";") {
            if(_alreadyImported) {
                return;
            }
            else {
                Users.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach(string line in lines) {
                    string[] values = line.Split(separator);
                    User user = new User();
                    user.UserID = Convert.ToDouble(values[0]);
                    user.UserName = values[1];
                    user.FirstName = values[2];
                    user.LastName = values[3];
                    user.Email = values[4];
                    user.Birthdate = values[5];
                    Users.Add(user);
                }
                _alreadyImported = true;
            }
        }
    }
}