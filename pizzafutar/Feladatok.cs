namespace pizzafutar;

public class Feladatok
{
    private List<Rendeles> lista;

    public Feladatok()
    {
        Adatbazis a = new Adatbazis();
        lista = a.Feltolt();

        Console.WriteLine(lista[0].Cim.Nev);
        Console.WriteLine(lista[1].Pizza.Meret);
        
    }
}