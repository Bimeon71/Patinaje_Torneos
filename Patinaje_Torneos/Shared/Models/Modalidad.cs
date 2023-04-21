using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patinaje_Torneos.Shared.Models
{
    [FirestoreData]
    public class Modalidad
    {
        public string Id { get; set; }
        [FirestoreProperty] 
        public string Nombre { get; set; }
    }
}
