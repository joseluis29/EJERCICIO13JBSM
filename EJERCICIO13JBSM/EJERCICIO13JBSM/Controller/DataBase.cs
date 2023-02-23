using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EJERCICIO13JBSM.Models;
using SQLite;

namespace EJERCICIO13JBSM.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;
        public DataBase(String dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);
            dbase.CreateTableAsync<Personas>().Wait();
        }

        public Task <int> SavePersonaAsync(Personas personas)
        {
            if (personas.id != 0)
            {
                return dbase.UpdateAsync(personas);
            }
            else
            {
                return dbase.InsertAsync(personas);
            }
        }
        /// <summary>
        /// Recuperar todos los alumnos
        /// </summary>
        /// <returns></returns>
        public Task<List<Personas>> GetPersonasAsync()
        {

            return dbase.Table<Personas>().ToListAsync();
        }
        /// <summary>
        /// Recupera alumnos por id
        /// </summary>
        /// <param name="idPersona">id del alumno que se requiere</param>
        /// <returns></returns>
        public Task<Personas> GetPersonasByIdAsync(int idPersona)
        {
            return dbase.Table<Personas>().Where(a => a.id == idPersona).FirstOrDefaultAsync();
        }

        public Task<int> DeletePersonaAsync(Personas persona)
        {
            return dbase.DeleteAsync(persona);
        }
    }
}
