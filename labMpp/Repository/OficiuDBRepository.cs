using labMpp.Domain;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Repository
{
    class OficiuDBRepository : IRepository<Oficiu, int>
    {

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Oficiu where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No oficiu deleted!");
            }
        }

        public IEnumerable<Oficiu> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Oficiu> oficiusR = new List<Oficiu>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume,descriere from Oficiu";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String descriere = dataR.GetString(2);

                        Oficiu oficiu = new Oficiu(idO, nume, descriere);
                        oficiusR.Add(oficiu);
                    }
                }
            }

            return oficiusR;
        }

        public Oficiu findOne(int id)
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select Id,Nume,Descriere from Oficiu where Id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String descriere = dataR.GetString(2);
                       
                        Oficiu oficiu = new Oficiu(idO,nume,descriere);
                        return oficiu;
                    }
                }
            }
            return null;
        }

        public void save(Oficiu entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Oficiu(nume,descriere)  values (@nume, @desc)";
                

                var paramDesc = comm.CreateParameter();
                paramDesc.ParameterName = "@nume";
                paramDesc.Value = entity.Nume;
                comm.Parameters.Add(paramDesc);

                var paramElems = comm.CreateParameter();
                paramElems.ParameterName = "@desc";
                paramElems.Value = entity.Descriere;
                comm.Parameters.Add(paramElems);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No oficiu added !");
            }
        }

        public long size()
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count(*) as [SIZE] from Oficiu";

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int size = dataR.GetInt32(0);

                        return size;
                    }
                }
            }
            return 0;
        }

        public void update(int id, Oficiu entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "UPDATE Oficiu SET Nume = @nume,Descriere=@desc WHERE Id = @id; ";


                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramDesc = comm.CreateParameter();
                paramDesc.ParameterName = "@desc";
                paramDesc.Value = entity.Descriere;
                comm.Parameters.Add(paramDesc);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No Oficiu updated !");
            }
        }
    }
}
