using Google.Cloud.Firestore;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Participante
    {
        public string Id { get; set; }
        [FirestoreProperty] 
        public int CompeticionId { get; set; }
        [FirestoreProperty] 
        public int CategoriaId { get; set; }
        [FirestoreProperty] 
        public int PatinadorId { get; set; }
        [FirestoreProperty] 
        public decimal Dificultad1 { get; set; }
        [FirestoreProperty] 
        public decimal Dificultad2 { get; set; }
        [FirestoreProperty] 
        public decimal Dificultad3 { get; set; }
        [FirestoreProperty] 
        public decimal Estilo1 { get; set; }
        [FirestoreProperty] 
        public decimal Estilo2 { get; set; }
        [FirestoreProperty] 
        public decimal Estilo3 { get; set; }
        [FirestoreProperty] 
        public int Victorias { get; set; }
        public decimal Juez1
        {
            get
            {
                return Dificultad1 + Estilo1;
            }
        }
        public decimal Juez2
        {
            get
            {
                return Dificultad2 + Estilo2;
            }
        }
        public decimal Juez3
        {
            get
            {
                return Dificultad3 + Estilo3;
            }
        }

        public decimal TotalDificultad
        {
            get
            {
                return Dificultad1 + Dificultad2 + Dificultad3;
            }
        }
        public decimal TotalEstilo
        {
            get
            {
                return Estilo1 + Estilo2 + Estilo3;
            }
        }
        public decimal Total
        {
            get
            {
                return Juez1 + Juez2 + Juez3;
            }
        }

        //public virtual Competicion Competicion { get; set; }
        //public virtual Categoria Categoria { get; set; }
        //public virtual Patinador Patinador { get; set; }
    }
}
