using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Mediator.Interfaces
{
    public interface IMediator
    {
        void Notificar(object remetente, string evento);
    }
}
