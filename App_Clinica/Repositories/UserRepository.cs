using App_Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App_Clinica.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool result = false;
                        
            try
            {
                var connection = GetConnection();
                using (var command = new SqlCommand()) {
                command.Connection = connection;
                    connection.Open();
                    command.CommandText = $@"select * from Usuario where Username = '{credential.UserName}' and [Password]= '{credential.Password}'";
                    //command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                    //command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;

                    result = command.ExecuteScalar() == null ? false : true;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocorreu um erro {ex}");
                return false;
            }

            return result;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
