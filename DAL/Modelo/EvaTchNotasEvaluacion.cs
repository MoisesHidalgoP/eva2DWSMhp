using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class EvaTchNotasEvaluacion
    {
        public string? MdUuid { get; set; }
        public DateTime? MdFch { get; set; }
        public long IdNotaEvaluacion { get; set; }
        public string? CodAlumno { get; set; }
        public long? NotaEvaluacion { get; set; }
        public string CodEvaluacion { get; set; } = null!;

        public virtual EvaCatEvaluacion CodEvaluacionNavigation { get; set; } = null!;
    }
}
