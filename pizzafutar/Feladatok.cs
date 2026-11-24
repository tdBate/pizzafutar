namespace pizzafutar;

public class Feladatok
{
    private List<Rendeles> lista;

    public Feladatok()
    {
        Adatbazis a = new Adatbazis();
        lista = a.Feltolt();
    }
}