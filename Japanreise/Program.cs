// See https://aka.ms/new-console-template for more information

using Japanreise;

var reise = new Reisekalender(new DateOnly(2024,4,6), new DateOnly(2024,4,24));

reise.AddUnternehmung("Takayama",1,"Wanosato",new DateOnly(2024,4,12));
reise.AddUnternehmung("Osaka",1,"--","Rumbummeln/Jetlag");
reise.AddUnternehmung("Magome",1,"--","Von Osaka: 4-5h");
reise.AddUnternehmung("Tsumago-Juku",1,"--","Magome-Tsumago-Pfad","Museumsdorf");
reise.AddUnternehmung("Matsumoto",1,"--","Wasabifarm","Burg Matsumoto");
reise.AddUnternehmung("Takayama",3,"Wing International","Frühlingsfest","Shirakawago");
reise.AddUnternehmung("Takayama",1,"--");
reise.AddUnternehmung("Dragon Quest Island",2,"--","Dragon Quest Land","Narutoland");
reise.AddUnternehmung("Tatsuyama",3,"--","Kotohiragu-Schrein","Homestay");
reise.AddUnternehmung("Osaka",1,"--","Rumbummeln","Burg Osaka","Dotonburi","Pokemon Cafe");
reise.AddUnternehmung("Koyasan",1,"--","Tempel angucken");
reise.AddUnternehmung("Osaka",1,"--",new DateOnly(2024,4,24),"Rückflug");
reise.PrintKalender();
//reise.WriteToFile("Japanreise_2024.txt");