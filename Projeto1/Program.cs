using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Projeto1
{
    class Banco
    {
        private readonly MySqlConnection conexao;
        public Banco()
        {
            
            MySqlConnection conexao = new MySqlConnection("Server=localhost;DataBase=dbExemplo; User=root; pwd=12345678");
            conexao.Open();

            
        }
        public void ExecutaComando (string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery, CommandType = System.Data.CommandType.Text, Connection = conexao
            };
        }
    }
     
    
    class Program
    {
        static void Main(string[] args)
        {
            

            /* string strAtualizaUsu = "update tbUsuario set nomeUsu = 'meachoesperta' where idUsu = 2 ";
             MySqlCommand comandoAtualiza = new MySqlCommand(strAtualizaUsu, conexao);
             comandoAtualiza.ExecuteNonQuery();
            */

            /*
              string insereUsu = "insert into tbUsuario(nomeUsu, cargo, datanasc) values('Emma', 'cerimonialista', '2000/04/17')";
              MySqlCommand comandoinserir = new MySqlCommand(insereUsu, conexao);
              comandoinserir.ExecuteNonQuery();*/

            Console.WriteLine("Digite seu nome: ");
            string vNome = Console.ReadLine();
            Console.WriteLine("Informe seu cargo: ");
            string vCargo = Console.ReadLine();
            Console.WriteLine("informe sua data de nascimento: ");
            string vData = Console.ReadLine();


            string strinsereUsu = string.Format("insert into tbUsuario(nomeUsu, cargo, datanasc) VALUES('{0}', '{1}', DATE_FORMAT(STR_TO_DATE('{2}', '%d/%m/%Y'), '%Y-%m-%d'));", vNome, vCargo, vData);

            MySqlCommand comandoinserir = new MySqlCommand(strinsereUsu, conexao);
            comandoinserir.ExecuteNonQuery();

         
            




          /* MySqlCommand comandoApagar = new MySqlCommand("delete from tbUsuario where idUsu = 2", conexao);
            comandoApagar.ExecuteNonQuery();*/

            string strSelecionaUsu = "Select * from tbUsuario";
            MySqlCommand comando = new MySqlCommand(strSelecionaUsu, conexao);
            MySqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", leitor["idUsu"], leitor["nomeUsu"], leitor["cargo"], leitor["datanasc"]);
            };



           




         


            Console.ReadLine();
        }
    }
}

