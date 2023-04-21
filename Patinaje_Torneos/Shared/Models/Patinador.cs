using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Patinador
    {
        public string Id { get; set; }
        [FirestoreProperty] 
        public string Nombre { get; set; }
        [FirestoreProperty] 
        public string Apellidos { get; set; }
        [FirestoreProperty] 
        public DateTime FechaNacimiento { get; set; }
        [FirestoreProperty] 
        public string Dni { get; set; }
        [FirestoreProperty] 
        public string Direccion { get; set; }
        [FirestoreProperty] 
        public string Domiciliacion { get; set; }
        [FirestoreProperty] 
        public string Padre { get; set; }
        [FirestoreProperty] 
        public string Madre { get; set; }
        [FirestoreProperty] 
        public string Telefono { get; set; }
        [FirestoreProperty] 
        public string Email { get; set; }
        [FirestoreProperty] 
        public string Foto { get; set; }
        [FirestoreProperty] 
        public DateTime FechaAlta { get; set; }
        [FirestoreProperty] 
        public DateTime FechaBaja { get; set; }
        [FirestoreProperty] 
        public int ClubId { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellidos;
            }
        }
        //public virtual Club Club { get; set; }
        //public virtual ICollection<Participante> Participantes { get; set; } = new HashSet<Participante>();
    }
}
