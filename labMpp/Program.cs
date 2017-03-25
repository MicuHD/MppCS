using labMpp.Domain;
using labMpp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labMpp
{
    static class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Sorting Tasks Repository DB ...");
            OficiuDBRepository repo = new OficiuDBRepository();

            Console.WriteLine("Taskurile din db");
            Console.WriteLine(repo.size());
            //foreach (Oficiu t in repo.findAll())
            //{
            //    Console.WriteLine(t.Nume);
            //}
            Oficiu oficiu = repo.findOne(1);
            Console.WriteLine(oficiu.Nume);
            repo.update(1, new Oficiu("blah1", "blah2"));
            oficiu = repo.findOne(1);
            Console.WriteLine(oficiu.Nume);
            Console.WriteLine(oficiu.Descriere);
            
        }
    }
}
