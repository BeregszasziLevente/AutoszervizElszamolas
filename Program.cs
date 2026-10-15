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