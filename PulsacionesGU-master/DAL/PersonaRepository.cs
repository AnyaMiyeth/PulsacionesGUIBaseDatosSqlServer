using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
namespace DAL
{
    public class PersonaRepository
    {
        SqlConnection connectionBD;

        List<Persona> personas = new List<Persona>();
      
        public  PersonaRepository(SqlConnection connection)
        {
            connectionBD = connection;
            

        }
          

        public void Guardar(Persona persona)
        {

            using (var command=connectionBD.CreateCommand()) 
            {
                command.CommandText = "Insert Into Persona (Identificacion,Nombre,Edad, Sexo, Pulsacion) values (@Identificacion,@Nombre,@Edad,@Sexo,@Pulsacion)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad",persona.Edad);
                command.Parameters.AddWithValue("@Pulsacion", persona.Pulsacion);
                var Filas=command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Persona persona)
        {

            using (var command = connectionBD.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos ()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            var register=string.Empty;
            using (var command = connectionBD.CreateCommand())
            {
                command.CommandText = "select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
                
             
            }
            return personas;
        }

        public Persona Buscar(string identificacion )
        {
           
            SqlDataReader dataReader;
            using (var command = connectionBD.CreateCommand())
            {
                command.CommandText = "select * from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                return DataReaderMapToPerson (dataReader);
            }
        }

        private static Persona DataReaderMapToPerson (SqlDataReader dataReader)
        {
            
            if (dataReader.HasRows)
            {
                dataReader.Read();
                Persona persona = new Persona();
                persona.Identificacion = (string)dataReader["Identificacion"];
                persona.Nombre = (string)dataReader["Nombre"];
                persona.Sexo = (string)dataReader["Sexo"];
                persona.Edad = (int)dataReader["Edad"];
                return persona;
            }
            return null;
        }

        public Int64 Totalizar() 
        {
            return personas.Count();
        }

        public Int64 TotalizarMujeres()
        {
            return personas.Where(p => p.Sexo.Equals( "F")).Count();
        }

        public Int64 TotalizarHombres()
        {
            return personas.Where(p => p.Sexo.Equals("M")).Count();
        }

    }
}
