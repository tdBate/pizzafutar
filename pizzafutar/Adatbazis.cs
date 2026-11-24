using MySql.Data.MySqlClient;

namespace pizzafutar;

public class Adatbazis
{
    private readonly string connectionstring;

    public Adatbazis()
    {
        this.connectionstring = "server=localhost;database=Pizzafutár;user=root;password=";
    }

    public List<Rendeles> Feltolt()
    {
        List<Rendeles> lista = new List<Rendeles>();
        Dictionary<int, Pizza> pizzak = new Dictionary<int, Pizza>();
        Dictionary<int, Cim> cimek = new Dictionary<int, Cim>();

        try
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionstring))
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

                query = "SELECT * FROM rendeles";
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            Pizza p = pizzak[reader.GetInt32("pizzaid")];
                            Cim c = cimek[reader.GetInt32("cimid")];
                            int db = reader.GetInt32("darab");
                            TimeSpan t = reader.GetTimeSpan("szallitas");

                            lista.Add(new Rendeles(id, p, db, c, t));
                        }
                    }
                }

            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e);
            Environment.Exit(0);
        }
        catch (Exception e)
        {
            Console.WriteLine();
            Environment.Exit(0);
        }


        return lista;
    }
}