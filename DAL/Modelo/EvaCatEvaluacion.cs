using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class EvaCatEvaluacion
    {
        public EvaCatEvaluacion()
        {
            EvaTchNotasEvaluacions = new HashSet<EvaTchNotasEvaluacion>();
        }

        public string CodEvaluacion { get; set; } = null!;
        public string? DescEvaluacion { get; set; }

        public virtual ICollection<EvaTchNotasEvaluacion> EvaTchNotasEvaluacions { get; set; }
    }
}
