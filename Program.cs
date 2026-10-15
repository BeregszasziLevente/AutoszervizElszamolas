using AutoszervizElszamolas;
using System.IO;

List<Szerelo> szerelok = new List<Szerelo>();
string[] sorok = File.ReadAllLines("szerviz.txt");

foreach (string sor in sorok)
{
    string[] darabolt = sor.Split(";");
    Szerelo peldany = new Szerelo();

    peldany.Nev = darabolt[0];
    peldany.JavitottAutok = int.Parse(darabolt[1]);
    peldany.Munkaora = int.Parse(darabolt[2]);
    peldany.GarancialisJavitasok=int.Parse(darabolt[3]);

    szerelok.Add(peldany);
}

int Munkaber = 0;
int TeljesMunkaber = 0;
int LegnagyobbBer = 0;
string LegnagyobbBerNev = "";
int NincsGarancia = 0;

Console.WriteLine("Szerelők napi elszámolásai:");

foreach (Szerelo sor in szerelok)
{
    Munkaber += sor.Munkaora * 4000 + sor.JavitottAutok * 5000;
    
    if (sor.JavitottAutok>=6 && sor.GarancialisJavitasok<=1)    Munkaber += 15000;
    if (sor.GarancialisJavitasok >= 2) Munkaber -= 10000;

    Console.WriteLine($"{sor.Nev}: {sor.JavitottAutok} autó, {sor.Munkaora} óra (Garanciális: {sor.GarancialisJavitasok}) - Munkabér: {Munkaber} Ft");
    
    TeljesMunkaber += Munkaber;
    if (Munkaber>LegnagyobbBer)
    {
        LegnagyobbBer = Munkaber;
        LegnagyobbBerNev = sor.Nev;
    }
    if (sor.GarancialisJavitasok==0) NincsGarancia++;

    Munkaber = 0;

}
Console.WriteLine();
Console.WriteLine("Összesített statisztika: ");
Console.WriteLine($"Szervíz által kifizetett teljes munkabér: {TeljesMunkaber} Ft");
Console.WriteLine($"Átlagos munkaóra szerelőnként: {szerelok.Average(a => a.Munkaora):f0} óra");
Console.WriteLine($"Legmagasabb napi bér: {LegnagyobbBerNev} ({LegnagyobbBer} Ft)");
Console.WriteLine($"Garanciális hiba nélkül dolgozó szerelők száma: {NincsGarancia} fő");