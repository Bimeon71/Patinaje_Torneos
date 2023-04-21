using Firebase.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patinaje_Torneos.Server
{
    public class ApplicationDbContext: DbContext
    {
        FirebaseAuthProvider auth;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            auth = new FirebaseAuthProvider(
                new FirebaseConfig("AIzaSyBArWkWSoDLt28PUMWS2-Vyd_Y7MtYlRkg")
                );
        }
    }
}
