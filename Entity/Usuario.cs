using portalinvestimento.virtualtilab.com.dto;
using portalinvestimento.virtualtilab.com.repository;
using static portalinvestimento.virtualtilab.com.entity.ativo;

namespace portalinvestimento.virtualtilab.com.entity
{

    public class usuario : entidade
    {
        #region construtor
        public usuario()
        {
        }
        public usuario(int _id, string _nome)
        {
            this.id = _id;
            this.nome = _nome;
        }
        public usuario(cadastrarusuariodto cad)
        {
            this.nome = cad.nome;
            this.senha = cad.senha;
            this.tipopermissao = cad.tipoacesso;
            this.codigo_usuario = cad.email;
            //this.digito_conta = cad.digito_conta;
            //this.codigo_conta = cad.codigo_conta;
            //this.cpf = cad.cpf;
            //this.saldo_carteira = cad.saldo_carteira;

            validateentity();
        }
        public usuario(alterarusuariodto cad)
        {
            this.nome = cad.nome;
            //this.senha = cad.senha;
            this.tipopermissao = cad.tipoacesso;
            this.email = cad.email;
            //this.digito_conta = cad.digito_conta;
            //this.codigo_conta = cad.codigo_conta;
            //this.cpf = cad.cpf;
            //this.saldo_carteira = cad.saldo_carteira;
            //this.id = cad.id;

            if (this.id == 0)
                throw new argumentexception("id não poder ser nulo ou 0.");

            //            if (cad.saldo_carteira <= 0)
            //              throw new argumentexception("saldo carteira não poder ser 0.");

            //validateentity();
        }

        #endregion
        public entipoacesso tipopermissao { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string codigo_usuario { get; set; }
        public entipoacesso tipoacesso { get; set; }
        public portfolio portfolio { get; set; }

        //public list<aplicacao> aplicacoes // não tem config
        //{ 
        //    get {
        //        aplicacaorepository r = new aplicacaorepository(config);
        //        return r.obteraplicacaoporuserid(this.id);
        //    } 
        //}


        //public string contacompleta { 
        //    get { 
        //        return string.format("{0}-{1}", this.codigo_conta, this.digito_conta); 
        //    } 
        //}


        public override void validateentity()
        {
            //assertionconcern.assertargumentrange((double)codigo_conta, 1, 1000, "codigo conta precisa ser preenchido de 0-1000.");
            //assertionconcern.assertargumentrange((double)digito_conta, 0, 99, "digito conta precisa ser preenchido de 0-99.");
            //assertionconcern.assertargumentlength(codigo_conta, 50, "codigo do investimento precisa ter no maximo 10 caracteres.");

            assertionconcern.assertargumentnotempty(nome, "nome precisa ser preenchido.");
            assertionconcern.assertargumentnotempty(codigo_usuario, "e-mail precisa ser preenchido.");
            assertionconcern.assertargumentmatches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", codigo_usuario, "e-mail invalido!");
            //assertionconcern.assertargumentnotempty(cpf, "cpf precisa ser preenchido.");
            //assertionconcern.assertargumentmatches(@"^\d{3}.?\d{3}.?\d{3}-?\d{2}$", cpf, "cpf invalido!");

            assertionconcern.assertargumentnotequals(tipoacesso, 0, "tipo acesso precisa ser preenchido");

            //assertionconcern.assertargumentrange((double)saldo_carteira, 0.1, 10, "taxa adm precisa estar entre 0.1 e 10.");
            //assertionconcern.assertargumentrange((double)saldo_carteira, 0, 1000000, "saldo carteira precisa ser maior que 0 e menor que 1.000.00,00");

            //throw new notimplementedexception();
        }

    }
}
