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
    class PersonalDBRepository : IRepositoryLog<Personal, int>
    {

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Personal where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No personal deleted!");
            }
        }

        public IEnumerable<Personal> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Personal> personalsR = new List<Personal>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume,username,parola from Personal";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String user = dataR.GetString(2);
                        String pass = dataR.GetString(3);

                        Personal personal = new Personal(idO, nume, user, pass);
                        personalsR.Add(personal);
                    }
                }
            }

            return personalsR;
        }

        public Personal findOne(int id)
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select Id,Nume,Username,Parola from Personal where Id=@id";
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
                        String user = dataR.GetString(2);
                        String pass = dataR.GetString(3);

                        Personal personal = new Personal(idO,nume,user,pass);
                        return personal;
                    }
                }
            }
            return null;
        }

        public int login(string user, string pass)
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count(*) as [SIZE] FROM Personal where username=@user and parola = @pass";
                IDbDataParameter paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@user";
                paramUser.Value = user;
                comm.Parameters.Add(paramUser);
                IDbDataParameter paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@pass";
                paramPass.Value = pass;
                comm.Parameters.Add(paramPass);



                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idO = dataR.GetInt32(0);
                        if (idO.Equals(1))
                            return idO;
                    }
                }
            }
            return -1;
        }

        public void save(Personal entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Personal(nume,username,parola)  values (@nume, @user,@parola)";
                

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@user";
                paramUser.Value = entity.Username;
                comm.Parameters.Add(paramUser);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@parola";
                paramPass.Value = entity.Parola;
                comm.Parameters.Add(paramPass);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No personal added !");
            }
        }

        public long size()
        {
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select count(*) as [SIZE] from Personal";

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

        public void update(int id, Personal entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "UPDATE Personal SET Nume = @nume,Descriere=@desc WHERE Id = @id; ";


                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@user";
                paramUser.Value = entity.Username;
                comm.Parameters.Add(paramUser);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@parola";
                paramPass.Value = entity.Parola;
                comm.Parameters.Add(paramPass);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No Personal updated !");
            }
        }
    }
}
