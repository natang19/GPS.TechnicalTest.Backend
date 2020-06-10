using Cnpj.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cnpj.Business.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
