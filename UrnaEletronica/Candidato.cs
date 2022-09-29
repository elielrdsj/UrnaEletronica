using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica
{
    public class Candidato
    {
        public string Name;
        public int Votes;
        public Candidato(string name)
        {
            this.Name = name;
            this.Votes = 0;
        }
        public int RetornarVotos()
        {
            return (Votes);
        }
        public void AdicionarVoto()
        {
            Votes++;
        }
    }
}
