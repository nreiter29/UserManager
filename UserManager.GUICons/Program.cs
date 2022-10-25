using UserManager.BL;
using UserManager.Models;

namespace UserManager.GUICons {
    internal class Program {
        
        static void Main(string[] args) {
        UserAdministration Admin = new();
            while(true) {
                Console.WriteLine("\n\rMenü\n\n\r" +
                                  "[0] User hinzufügen\n\r" +
                                  "[1] User anzeigen\n\r" +
                                  "[2] User löschen\n\r" +
                                  "[3] User modifizieren\n\r" +
                                  "[4] Users speichern\n\r" +
                                  "[e] beenden\n\r");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input) {
                    case "0":
                        Admin.AddUser(CreateUser());
                        break;
                    case "e":
                        return;
                    case "1": 
                        Admin.ImportUsersCSV(@"C:\Users\noahr\source\repos\UserManager\users.csv");
                    Admin.ListUsers();
                        break;
                    case "2":
                        Admin.DeleteUser();
                    break;
                        case "3":
                        Admin.ModifyUser();
                    break;
                    case "4":
                        SaveUsers(Admin);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SaveUsers(UserAdministration Admin) {
            Console.WriteLine("Speichern\n\r");
            Admin.ExportUsersCsv();
        }

        private static User CreateUser() {
            User user = new();

            Console.WriteLine("Neuen user anlegen");
            Console.WriteLine("Benutzername: ");
            user.UserName = Console.ReadLine() ?? "";
            Console.WriteLine("Vorname: ");
            user.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Nachname: ");
            user.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("E-Mail: ");
            user.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Geburtsdatum: ");
            string Birthdate = Console.ReadLine();
            user.Birthdate = Birthdate;
            
            return user;
        }
    }
}