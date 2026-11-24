namespace pizzafutar;

public class Pizza
{
    private int id;
    private string nev;
    private int meret;
    private int ar;

    public Pizza(int id, string nev, int meret, int ar)
    {
        this.id = id;
        this.nev = nev;
        this.meret = meret;
        this.ar = ar;
    }

    public int Id => id;

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Meret
    {
        get => meret;
        set => meret = value;
    }

    public int Ar
    {
        get => ar;
        set => ar = value;
    }
}