using UserManager.Models;

namespace UserManager.BL {
    public class UserAdministration {

        // Feld
        private List<User> users = new List<User>();

        // Eigenschaften
        public List<User> Users { get => users; set => users = value; }

        public void ListUsers() {
            foreach(User user in Users) {
                Console.WriteLine( user.UserID + " " + user.UserName + " " + user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Birthdate);
            }
        }

        public void AddUser(User user) {
            Users.Add(user);
        }

        public void DeleteUser() {
            Console.WriteLine("Welchen User wollen Sie löschen?");
            int input = int.Parse(Console.ReadLine());
            Users.RemoveAt(input - 1);
        }

        public void ModifyUser() {
            Console.WriteLine("Welchen User wollen Sie modifizieren?");
            int input = int.Parse(Console.ReadLine());
            User user = Users[input - 1];
            Console.WriteLine("Neuen Benutzernamen eingeben: ");
            user.UserName = Console.ReadLine() ?? "";
            Console.WriteLine("Neuen Vornamen eingeben: ");
            user.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Neuen Nachnamen eingeben: ");
            user.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Neue E-Mail eingeben: ");
            user.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Neues Geburtsdatum eingeben: ");
            user.Birthdate = DateTime.Parse(Console.ReadLine());
        }
    }
}