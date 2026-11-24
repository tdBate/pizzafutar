namespace pizzafutar;

public class Rendeles
{
    private int id;
    private Pizza pizza;
    private int db;
    private Cim cim;
    private TimeSpan ido;

    public Rendeles(int id, Pizza pizza, int db, Cim cim, TimeSpan ido)
    {
        this.id = id;
        this.pizza = pizza;
        this.db = db;
        this.cim = cim;
        this.ido = ido;
    }

    public int Id => id;

    public int Id1
    {
        get => id;
        set => id = value;
    }

    public Pizza Pizza
    {
        get => pizza;
        set => pizza = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Db
    {
        get => db;
        set => db = value;
    }

    public Cim Cim
    {
        get => cim;
        set => cim = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TimeSpan Ido
    {
        get => ido;
        set => ido = value;
    }
}