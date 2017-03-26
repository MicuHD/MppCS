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
    public class SpectacolDBRepository : IRepository<Spectacol, int>
    {

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Spectacol where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No spectacol deleted!");
            }
        }

        public IEnumerable<Spectacol> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Spectacol> spectacolsR = new List<Spectacol>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,locatie,disponibile,vandute,artist,data,ora from Spectacol";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String locatie = dataR.GetString(1);
                        int disp = dataR.GetInt32(2);
                        int sold = dataR.GetInt32(3);
                        String art = dataR.GetString(4);
                        String data = dataR.GetString(5);
                        String ora = dataR.GetString(6);


                        Spectacol spectacol = new Spectacol(idO, locatie, disp, sold, art,data,ora);
                        spectacolsR.Add(spectacol);
                    }
                }
            }

            return spectacolsR;
        }

        public Spectacol findOne(int id)
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,locatie,disponibile,vandute,artist,data,ora from Spectacol where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String locatie = dataR.GetString(1);
                        int disp = dataR.GetInt32(2);
                        int sold = dataR.GetInt32(3);
                        String art = dataR.GetString(4);
                        String data = dataR.GetString(5);
                        String ora = dataR.GetString(6);


                        Spectacol spectacol = new Spectacol(idO, locatie, disp, sold, art, data, ora);
                        return spectacol;
                    }
                }
            }
            return null;
        }

        public void save(Spectacol entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Spectacol(locatie,disponibile,vandute,idartist)  values (@loc,@disp,@vand,@idart)";
                

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@loc";
                paramLoc.Value = entity.Locatie;
                comm.Parameters.Add(paramLoc);

                var paramDisp = comm.CreateParameter();
                paramDisp.ParameterName = "@disp";
                paramDisp.Value = entity.Disponibile;
                comm.Parameters.Add(paramDisp);

                var paramVand = comm.CreateParameter();
                paramVand.ParameterName = "@vand";
                paramVand.Value = entity.Vandute;
                comm.Parameters.Add(paramVand);

                var paramIdArt = comm.CreateParameter();
                paramIdArt.ParameterName = "@idart";
                paramIdArt.Value = entity.Artist;
                comm.Parameters.Add(paramIdArt);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No spectacol added !");
            }
        }

        public long size()
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count(*) as [SIZE] from Spectacol";

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

        public void update(int id, Spectacol entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "UPDATE Spectacol SET Locatie = @loc,Disponibile=@disp,vandute=@vand,artist=@art, data=@data,ora = @ora WHERE Id = @id; ";


                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@loc";
                paramLoc.Value = entity.Locatie;
                comm.Parameters.Add(paramLoc);

                var paramDisp = comm.CreateParameter();
                paramDisp.ParameterName = "@disp";
                paramDisp.Value = entity.Disponibile;
                comm.Parameters.Add(paramDisp);

                var paramVand = comm.CreateParameter();
                paramVand.ParameterName = "@vand";
                paramVand.Value = entity.Vandute;
                comm.Parameters.Add(paramVand);

                var paramIdArt = comm.CreateParameter();
                paramIdArt.ParameterName = "@art";
                paramIdArt.Value = entity.Artist;
                comm.Parameters.Add(paramIdArt);

                var paramIdOra = comm.CreateParameter();
                paramIdOra.ParameterName = "@ora";
                paramIdOra.Value = entity.Ora;
                comm.Parameters.Add(paramIdOra);

                var paramIdData = comm.CreateParameter();
                paramIdData.ParameterName = "@data";
                paramIdData.Value = entity.Data;
                comm.Parameters.Add(paramIdData);


                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No Spectacol updated !");
            }
        }
    }
}
