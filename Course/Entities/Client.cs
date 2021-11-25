using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator.Entities
{
    public class Client
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client(string nome, string email, DateTime birthDate)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            BirthDate = birthDate;
        }

        public Client() { }
    }
}
