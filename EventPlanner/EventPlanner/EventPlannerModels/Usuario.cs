using System;
using System.Collections.Generic;

namespace EventPlannerModels;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int TipoUsuario { get; set; }

    public virtual TipoUsuario TipoUsuarioNavigation { get; set; } = null!;
}
