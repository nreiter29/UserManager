﻿namespace UserManager.Models {
    
    /// <summary>
    /// 
    /// Zugriffsmodifizierer
    ///     public:     ganze Solution
    ///     private:    nur in der Klasse und vererbbar
    ///     internal:   in der gesamten Libary
    ///                 default
    ///                 
    ///     class User { // ist internal
    ///     }
    /// 
    /// </summary>
    
    public class User : IDisposable {

        // Felder !sollten immer private sein!

        /// <summary>
        /// Ist nicht am Objekt gebunden!
        /// Alle Instanzen können auf das selbe Feld/Methode zugreifen!
        /// </summary>
        private static int count = 0;

        private int _userID;
        
        // Eigenschaften

        /// <summary>
        /// property
        /// 
        /// Properties besitzen immer get und set
        /// sowie ein Feld auf das sie zugreifen!
        /// </summary>
        public int UserID {
            // Lesezugriff von außen auf das Feld - Beispiel:
            //      User user = new();
            //      int id = user.UserID;
            get { return _userID; }

            // Schreibzugriff von außen auf das Feld - Beispiel:
            //      User user = new();
            //      user.UserID = 100;
            private set { _userID = value; }
        }

        /// <summary>
        /// Auto-Property
        ///     Das private Feld ist versteckt
        /// </summary>
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime Birthdate { get; set; }

        // Konstruktoren

        /// <summary>
        /// Standard-Konstruktoren haben keinen Übergabeparameter
        /// 
        /// Konstruktoren heißen wie die Klasse und haben kein Rückgabewert!
        /// 
        /// Beispiel:
        ///     User user = new();
        /// 
        /// </summary>

        public User() { // Wenn keine Instanz mit dem Standard-Konstruktors erzeugt werden sollen, setzt man diesen auf private!
            // Zählt wie viele Instanzen erzeugt wurden
            count++;
            UserID = count;
        }

        /// <summary>
        /// 
        ///
        /// Beispiel:
        ///     User user = new("Reiter");
        ///     
        /// </summary>
        /// <param name="lastName"></param>
        public User(string lastName) {
            LastName = lastName;
            count++;
            UserID = count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="userID"></param>
        public User(string lastName, int userID) {
            LastName = lastName;
            UserID = userID;
        }

        // Methoden

        /// <summary>
        /// Methoden haben immer einen Rückgabewert oder void.
        /// </summary>
        /// <returns></returns>
        public string GetFullName() {
            return $"{FirstName} {LastName}";
        }

        public int GetAge() {
            return DateTime.Now.Year - Birthdate.Year;
        } 
        
        // Destruktoren

        /// <summary>
        /// WIrd aufgeruffen wenn die Instanz entsorgt wurde!
        /// </summary>
        ~User() {
            
        }

        /// <summary>
        /// Erzwingt das löschen des Objekts
        /// </summary>
        public void Dispose() {
            // throw new NotImplementedException();
            GC.SuppressFinalize(this);
        }
    }
}