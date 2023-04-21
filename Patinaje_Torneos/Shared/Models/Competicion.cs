using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Competicion
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public int EventoId { get; set; }
        [FirestoreProperty] 
        public DateTime Fecha { get; set; }
        [FirestoreProperty] 
        public string Lugar { get; set; }

        //public virtual Evento Evento { get; set; }
        //public virtual ICollection<CompCategorias> CompCategorias { get; set; } = new HashSet<CompCategorias>();
        //public virtual ICollection<Participante> Participantes { get; set; } = new HashSet<Participante>();

    }
}
