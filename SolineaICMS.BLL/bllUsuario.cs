using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;
using SolineaICMS.Util;

namespace SolineaICMS.BLL
{
    public class bllUsuario : IBllBase<voUsuario>
    {
        public IList<voUsuario> Select(voUsuario voUsuario)
        {
            dalUsuario dalUsuario = new dalUsuario();
            
            return dalUsuario.Select(voUsuario);
        }

        public int Insert(voUsuario voUsuario)
        {
            dalUsuario dalUsuario = new dalUsuario();
            
            return dalUsuario.Insert(voUsuario);
        }

        public int Update(voUsuario voUsuario)
        {
            dalUsuario dalUsuario = new dalUsuario();
            
            return dalUsuario.Update(voUsuario);
        }

        public int Delete(voUsuario voUsuario)
        {
            dalUsuario dalUsuario = new dalUsuario();
            
            return dalUsuario.Delete(voUsuario);
        }

        public voUsuario Login(voUsuario voUsuario)
        {
            dalUsuario dalUsuario = new dalUsuario();
            
            return dalUsuario.Login(voUsuario);
        }

        public bool LoginExiste(UtilEnums.Acao Acao, voUsuario voUsuario, int codigoUsuarioEditado)
        {
            dalUsuario dalUsuario = new dalUsuario();

            voUsuario objUsuario = dalUsuario.LoginExiste(voUsuario);

            if (Acao == UtilEnums.Acao.Incluir)
            {
                if (objUsuario != null)
                {
                    return true;
                }
            }
            else if (Acao == UtilEnums.Acao.Editar)
            {
                if ((objUsuario != null) && (objUsuario.CodigoUsuario != codigoUsuarioEditado))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

