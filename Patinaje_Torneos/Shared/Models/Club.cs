using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Club
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string Nombre { get; set; }
        
        //public virtual ICollection<Patinador> Patinadores { get; set; } = new HashSet<Patinador>();
    }
}
