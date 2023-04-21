using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Patinaje_Torneos.Shared.Models;

namespace Patinaje_Torneos.Server.DataAccess
{
    public class CategoriaDataAccess
    {
        string projectId;
        FirestoreDb firestoreDb;
        public CategoriaDataAccess()
        {
            string filePath = "C:\\FirestoreAPIKey\\patinaje-adb0e-firebase-adminsdk-77da0-ffce8434e3.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            projectId = "patinaje-adb0e";
            firestoreDb = FirestoreDb.Create(projectId);
        }
        public async Task<List<Categoria>> GetAllCategoria()
        {
            try
            {
                Query categoriaQuery = firestoreDb.Collection("Categoria");
                QuerySnapshot categoriaQuerySnapshot = await categoriaQuery.GetSnapshotAsync();
                List<Categoria> lstCategoria = new List<Categoria>();
                foreach (DocumentSnapshot documentSnapshot in categoriaQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> categoria = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(categoria);
                        Categoria newCategoria = JsonConvert.DeserializeObject<Categoria>(json);
                        newCategoria.Id = documentSnapshot.Id;
                        lstCategoria.Add(newCategoria);
                    }
                }
                List<Categoria> storeCategoriaList = lstCategoria.OrderBy(x => x.Nombre).ToList();
                return storeCategoriaList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error recuperando categorias: {ex.Message}");
            }
        }
        
        public async Task<Categoria> GetCategoriaId(string id)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("Categoria").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    Categoria cat = snapshot.ConvertTo<Categoria>();
                    cat.Id = snapshot.Id;
                    return cat;
                }
                else
                {
                    return new Categoria();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    
        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            try
            {
                CollectionReference colRef = firestoreDb.Collection("Categoria");
                categoria.Id = await GetLasId();
                await colRef.AddAsync(categoria);
                return categoria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            try
            {
                DocumentReference catRef = firestoreDb.Collection("Categoria").Document(categoria.Id);
                await catRef.SetAsync(categoria, SetOptions.Overwrite);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteCategoria(string id)
        {
            try
            {
                DocumentReference catRef = firestoreDb.Collection("Categoria").Document(id);
                await catRef.DeleteAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected async Task<string> GetLasId()
        {
            List<Categoria> categorias = await GetAllCategoria();
            int numCategorias = categorias.Count + 1;
            return numCategorias.ToString();
        }
    }
}
