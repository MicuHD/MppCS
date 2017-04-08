using model;
using System;
using System.Collections.Generic;
using System.Data;

namespace persistance
{
    class ArtistDBRepository : IRepository<Artist, int>
    {

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Artist where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No artist deleted!");
            }
        }

        public IEnumerable<Artist> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Artist> artistsR = new List<Artist>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select Id,Nume from Artist";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);

                        Artist artist = new Artist(idO, nume);
                        artistsR.Add(artist);
                    }
                }
            }

            return artistsR;
        }

        public Artist findOne(int id)
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select Id,Nume from Artist where Id=@id";
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
                       
                        Artist artist = new Artist(idO,nume);
                        return artist;
                    }
                }
            }
            return null;
        }

        public void save(Artist entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Artist(nume)  values (@nume)";
                

                var paramDesc = comm.CreateParameter();
                paramDesc.ParameterName = "@nume";
                paramDesc.Value = entity.Nume;
                comm.Parameters.Add(paramDesc);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No artist added !");
            }
        }

        public long size()
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count(*) as [SIZE] from Artist";

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

        public void update(int id, Artist entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "UPDATE Artist SET Nume = @nume WHERE Id = @id; ";


                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No artist updated !");
            }
        }
    }
}
