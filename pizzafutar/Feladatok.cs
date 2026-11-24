namespace pizzafutar;

public class Feladatok
{
    private List<Rendeles> lista;

    public Feladatok()
    {
        Adatbazis a = new Adatbazis();
        lista = a.Feltolt();

        //3
        Console.WriteLine(String.Join(", ", lista
            .Where(k => k.Pizza.Ar < 1500)
            .OrderByDescending(item => item.Pizza.Meret)
            .ThenBy(item => item.Pizza.Nev)
            .Select(item => $"{item.Pizza.Nev} {item.Pizza.Meret} {item.Pizza.Ar}")
        ));
        
        // NepSzeru();
        // Esti();
        // JolFogy();
        // Reklam();
        Osszeg();
    }

    // 4. feladat
    private void NepSzeru()
    {
        var kedvenc = lista
            .GroupBy(r => new { r.Pizza.Nev, r.Pizza.Meret })
            .Select(g => new { g.Key.Nev, g.Key.Meret, Darab = g.Sum(r => r.Db) })
            .MaxBy(x => x.Darab);

        Console.WriteLine($"4. feladat: {kedvenc.Nev} {kedvenc.Meret} - {kedvenc.Darab} db");
    }

    // 5. feladat
    private void Esti()
    {
        TimeSpan kezdet = new TimeSpan(18, 0, 0);
        TimeSpan veg = new TimeSpan(19, 0, 0);

        var esti = lista
            .Where(r => r.Ido >= kezdet && r.Ido <= veg)
            .GroupBy(r => new { r.Pizza.Nev, r.Pizza.Meret })
            .Select(g => new { g.Key.Nev, g.Key.Meret, Darab = g.Sum(r => r.Db) })
            .OrderBy(x => x.Nev)
            .ThenBy(x => x.Meret);

        foreach (var e in esti)
        {
            Console.WriteLine($"{e.Nev} {e.Meret}: {e.Darab} db");
        }
    }

    // 6. feladat
    private void JolFogy()
    {
        var mindharom = lista
            .GroupBy(r => r.Pizza.Nev)
            .Where(g => g.Select(r => r.Pizza.Meret).Distinct().Count() == 3)
            .Select(g => g.Key)
            .OrderBy(n => n);

        foreach (var item in mindharom)
        {
            Console.WriteLine(item);
        }
    }

    // 7. feladat
    private void Reklam()
    {
        var akciok = lista
            .GroupBy(r => new { r.Ido, r.Cim.Id })
            .Where(g => g.Sum(r => r.Db) > 3)
            .Select(g => new { g.First().Ido, g.First().Cim })
            .OrderBy(x => x.Ido)
            .ThenBy(x => x.Cim.Nev);
        
        foreach (var a in akciok)
        {
            Console.WriteLine($"{a.Ido} {a.Cim.Nev} {a.Cim.Utca} {a.Cim.Hsz}");
        }
    }

    // 8. feladat
    private void Osszeg()
    {
        var fizetendo = lista
            .GroupBy(r => new { r.Ido, r.Cim.Nev })
            .Select(g => new
            {
                g.Key.Ido,
                g.Key.Nev,
                Cim = g.First().Cim,
                Osszeg = g.Sum(r => r.Db * r.Pizza.Ar)
            })
            .OrderBy(x => x.Ido)
            .ThenBy(x => x.Nev);

        foreach (var item in  fizetendo)
        {
            Console.WriteLine($"{item.Nev} {item.Ido} {item.Osszeg}");
        }
        
    }
}