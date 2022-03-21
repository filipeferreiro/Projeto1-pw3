using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto1
{
    class UsuarioDAO
    {
        private Banco db;

        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "insert into tbUsuario(nomeUsu, cargo, datanasc)";
            strQuery += string.Format("VALUES('{0}', '{1}', DATE_FORMAT(STR_TO_DATE('{2}', '%d/%m/%Y'), '%Y-%m-%d'));", usuario.nomeUsu, usuario.cargo, usuario.datanasc);

            using(db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "update tbUsuario set";
            strQuery += string.Format("nomeUsu = '{0}',", usuario.nomeUsu);
            strQuery += string.Format("cargo = '{1}',", usuario.cargo);
            strQuery += string.Format("datanasc = '{2}',", usuario.datanasc);
            strQuery += string.Format("where idUsu = ({0} ", usuario.idUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
    }
}
