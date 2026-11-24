namespace pizzafutar;

public class Cim
{
    private int id;
    private string nev;
    private string utca;
    private string hsz;
    
    
    public Cim(int id, string nev, string utca, string hsz)
    {
        this.id = id;
        this.nev = nev;
        this.utca = utca;
        this.hsz = hsz;
    }

    public int Id => id;

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Utca
    {
        get => utca;
        set => utca = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Hsz
    {
        get => hsz;
        set => hsz = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return "";
    }
}