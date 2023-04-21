using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class CompCategorias
    {
        public string Id { get; set; }
        [FirestoreProperty] 
        public int CompeticionId { get; set; }
        [FirestoreProperty] 
        public int CategoriaId { get; set; }
        
        //public virtual Competicion Competicion { get; set; }
        //public virtual Categoria Categoria { get; set; }
    }
}
