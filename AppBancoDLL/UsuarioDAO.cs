using System;
using System.Collections.Generic;
using AppBancoADO;
using MySql.Data.MySqlClient;


namespace Projeto1
{
    public class UsuarioDAO
    {
        private Banco db;

        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "insert into tbUsuario(nomeUsu, cargo, datanasc)";
            strQuery += string.Format("VALUES('{0}', '{1}', (STR_TO_DATE('{2}','%d/%m/%Y %H:%i:%s')) );", usuario.nomeUsu, usuario.cargo, usuario.datanasc);

            using(db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "update tbUsuario set";
            strQuery += string.Format(" nomeUsu = '{0}', ", usuario.nomeUsu);
            strQuery += string.Format(" cargo = '{0}', ", usuario.cargo);
            strQuery += string.Format(" datanasc = (STR_TO_DATE('{0}','%d/%m/%Y %H:%i:%s')) ", usuario.datanasc);
            strQuery += string.Format(" where idUsu = {0} ", usuario.idUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Salvar (Usuario usuario)
        {
            if (usuario.idUsu > 0)
            {
                Atualizar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }

        public void Excluir (Usuario usuario)
        {
            using(db = new Banco())
            {
                var strQuery = string.Format(" delete from tbUsuario where idUsu = '{0}' ", usuario.idUsu);
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> Listar()
        {
            using (var db = new Banco())
            {
                var strQuery = "select * from tbUsuario; ";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno);
            }
        }

        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    idUsu = int.Parse(retorno["idUsu"].ToString()),
                    nomeUsu = retorno["nomeUsu"].ToString(),
                    cargo = retorno["cargo"].ToString(),
                    datanasc = DateTime.Parse(retorno["datanasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }
    }
}
