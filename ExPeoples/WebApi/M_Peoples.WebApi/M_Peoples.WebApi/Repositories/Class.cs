using M_Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples.WebApi.Repositories
{
    public class FuncionarioRepositorio
    {
        // CRIAÇÃO STRING PARA CONEXÃO COM SQL SERVER
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=M_Peoples;User Id=sa;Pwd=132;";


        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select * from Funcionario";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }

            }
            return funcionarios;
        }

        // FINAL DE SELEÇÃO DA TABELA DE FUNCIONÁRIOS

        // BUSCA POR ID DE FUNCIONÁRIO
        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "select * from Funcionario where IdFuncionario = @IdFuncionario;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain()
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }

                // FINAL DE BUSCA POR ID DE FUNCIONÁRIO

            }
        }
        public void Inserir(FuncionarioDomain funcionarioDomain)
        {
            string Query = "insert into Funcionario (Nome, Sobrenome) values (@Nome, @Sobrenome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ATUALIZAÇÃO DE DADOS DE FUNCIONÁRIO

        public void Deletar(int id)
        {
            string Query = "delete from Funcionario where IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "update Funcionario set Nome = @Nome, Sobrenome = @Sobrenome where IdFuncionario = @IdFuncionario;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


           
    }
}
