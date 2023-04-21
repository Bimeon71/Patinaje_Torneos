using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Categoria
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string Nombre { get; set; }
        
        //public virtual ICollection<CompCategorias> CompCategorias { get; set; } = new HashSet<CompCategorias>();
        //public virtual ICollection<Participante> Participantes { get; set; } = new HashSet<Participante>();
    }
}
