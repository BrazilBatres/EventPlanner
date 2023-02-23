using System;
using System.Collections.Generic;

namespace EventPlannerModels;

public partial class TipoUsuario
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
