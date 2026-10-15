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

foreach (Szerelo sor in szerelok)
{
    Munkaber += sor.Munkaora * 4000 + sor.JavitottAutok * 5000;
    if (sor.JavitottAutok>=6 && sor.GarancialisJavitasok!<1)    Munkaber += 15000;
    if (sor.GarancialisJavitasok >= 2) Munkaber -= 10000;

}