using MySql.Data.MySqlClient;

namespace pizzafutar;

public class Adatbazis
{
    private readonly string connectionstring;

    public Adatbazis()
    {
        this.connectionstring = "server=localhost;database=pizzafutár;user=root;password=''";
    }

    public List<Rendeles> Feltolt()
    {
        List<Rendeles> lista = new List<Rendeles>();
        Dictionary<int, Pizza> pizzak = new Dictionary<int, Pizza>();
        Dictionary<int, Cim> cimek = new Dictionary<int, Cim>();
        
        try
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.Open();
                string query = "SELECT * FROM pizza";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            Pizza p = new Pizza(
                                id,
                                reader.GetString("nev"),
                                reader.GetInt32("meret"),
                                reader.GetInt32("ar")
                            );
                            pizzak[id] = p;
                        }
                    }
                }
                
                
                query = "SELECT * FROM cim";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            Cim c = new Cim(
                                id,
                                reader.GetString("nev"),
                                reader.GetString("utca"),
                                reader.GetString("hsz")
                            );
                            cimek[id] = c;
                        }
                    }
                }
                
                query = "SELECT * FROM rendelesek";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            
                        }
                    }
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        return lista;
    }
}