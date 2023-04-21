using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Evento
    {
        public string Id { get; set; }
        [FirestoreProperty] 
        public string Nombre { get; set; }
        //public virtual ICollection<Competicion> Competiciones { get; set; } = new HashSet<Competicion>();
    }
}
