using UserManager.BL;
using UserManager.Models;

namespace UserManager.GUICons {
    internal class Program {
        
        static void Main(string[] args) {
        UserAdministration Admin = new();
            while(true) {
                Console.WriteLine("Menü\n\n\r" +
                                  "[0] User hinzufügen\n\r" +
                                  "[1] User anzeigen\n\r" +
                                  "[2] User löschen\n\r" +
                                  "[3] User modifizieren\n\r" +
                                  "[e] beenden\n\r");

                string input = Console.ReadLine();

                switch (input) {
                    case "0":
                        Admin.AddUser(CreateUser());
                        break;
                    case "e":
                        return;
                    case "1":
                        Admin.ListUsers();
                        break;
                    case "2":
                    Admin.DeleteUser();
                    break;
                        case "3":
                        Admin.ModifyUser();
                    break;
                    default:
                        break;
                }

            }
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
            user.Birthdate = DateTime.Parse(Console.ReadLine());
            
            return user;
        }
    }
}