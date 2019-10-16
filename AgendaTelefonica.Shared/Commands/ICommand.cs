using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaTelefonica.Shared.Commands
{
    public interface ICommand
    {
        void Validate();
    }
}
