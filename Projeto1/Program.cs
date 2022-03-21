using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;


namespace Projeto1
{
    class Banco : IDisposable
    {
        private readonly MySqlConnection conexao; 
        public Banco()
        {
            
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
    

        }

       
        
        public void ExecutaComando (string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery, CommandType = CommandType.Text, Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }
         public MySqlDataReader RetornaComando (string StrQuery)
        {
            var comando = new MySqlCommand(StrQuery, conexao);
            return comando.ExecuteReader(); 
        }

        public void Dispose()
        {
            if(conexao.State==ConnectionState.Open)
            conexao.Close();
        }

    }
     
    class Program
    {
        static void Main(string[] args)
        {
            var Banco = new Banco();
            
            /*
             string strAtualizaUsu = "update tbUsuario set nomeUsu = 'meachoesperta' where idUsu = 2 ";
             MySqlCommand comandoAtualiza = new MySqlCommand(strAtualizaUsu, conexao);
             comandoAtualiza.ExecuteNonQuery();
            

            
              string insereUsu = "insert into tbUsuario(nomeUsu, cargo, datanasc) values('Emma', 'cerimonialista', '2000/04/17')";
              MySqlCommand comandoinserir = new MySqlCommand(insereUsu, conexao);
              comandoinserir.ExecuteNonQuery();*/

            Console.WriteLine("Digite seu nome: ");
            string vNome = Console.ReadLine();
            Console.WriteLine("Informe seu cargo: ");
            string vCargo = Console.ReadLine();
            Console.WriteLine("informe sua data de nascimento: ");
            string vData = Console.ReadLine();


            var usuario = new Usuario { nomeUsu = vNome, cargo = vCargo, datanasc = DateTime.Parse(vData) }; // erro de conversao.
            new UsuarioDAO().Atualizar(usuario);   


            string strSelecionaUsu = "Select * from tbUsuario";
            MySqlDataReader leitor = Banco.RetornaComando(strSelecionaUsu);


            while (leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor["idUsu"], leitor["nomeUsu"], leitor["cargo"], leitor["datanasc"]);
            };

            Console.ReadLine();



            /*  MySqlCommand comandoinserir = new MySqlCommand(strinsereUsu, conexao);
              comandoinserir.ExecuteNonQuery();







             MySqlCommand comandoApagar = new MySqlCommand("delete from tbUsuario where idUsu = 2", conexao);
              comandoApagar.ExecuteNonQuery();



              while (leitor.Read())
              {
                  Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor["idUsu"], leitor["nomeUsu"], leitor["cargo"], leitor["datanasc"]);
              };


              Console.ReadLine(); */
        }
    }
}

