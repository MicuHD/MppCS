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
    class CumparatorDBRepository : IRepository<Cumparator, int>
    {

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Cumparator where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No cumparator deleted!");
            }
        }

        public IEnumerable<Cumparator> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Cumparator> cumparatorsR = new List<Cumparator>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select Id,Nume,Bilete,IdSpectacol from Cumparator";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        int bilete = dataR.GetInt32(2);
                        int idspec = dataR.GetInt32(3);
                        Cumparator cumparator = new Cumparator(idO, nume, bilete, idspec);
                        cumparatorsR.Add(cumparator);
                    }
                }
            }

            return cumparatorsR;
        }

        public Cumparator findOne(int id)
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select Id,Nume,Bilete,IdSpectacol from Cumparator where Id=@id";
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
                        int bilete = dataR.GetInt32(2);
                        int idspec = dataR.GetInt32(3);
                        Cumparator cumparator = new Cumparator(idO,nume,bilete,idspec);
                        return cumparator;
                    }
                }
            }
            return null;
        }

        public void save(Cumparator entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Cumparator(nume,bilete,idspectacol)  values (@nume,@bilete,@idspectacol)";
                

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramBilet = comm.CreateParameter();
                paramBilet.ParameterName = "@bilete";
                paramBilet.Value = entity.Bilete;
                comm.Parameters.Add(paramBilet);

                var paramSpec = comm.CreateParameter();
                paramSpec.ParameterName = "@idspectacol";
                paramSpec.Value = entity.IdSpectacol;
                comm.Parameters.Add(paramSpec);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No cumparator added !");
            }
        }

        public long size()
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count(*) as [SIZE] from Cumparator";

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

        public void update(int id, Cumparator entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "UPDATE Cumparator SET Nume = @nume,bilete=@Bilete,idspectacol=@idspectacol WHERE Id = @id; ";


                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramBilet = comm.CreateParameter();
                paramBilet.ParameterName = "@bilete";
                paramBilet.Value = entity.Bilete;
                comm.Parameters.Add(paramBilet);

                var paramSpec = comm.CreateParameter();
                paramSpec.ParameterName = "@idspectacol";
                paramSpec.Value = entity.IdSpectacol;
                comm.Parameters.Add(paramSpec);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No cumparator updated !");
            }
        }
    }
}
