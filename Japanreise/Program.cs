// See https://aka.ms/new-console-template for more information

using Japanreise;

var reise = new Reisekalender(new DateOnly(2024,4,6), new DateOnly(2024,4,24));

reise.AddUnternehmung("Osaka", 2, "APA Hotel Umeda-eki Tower", "Ankunft ~17:00", "Rumbummeln/Jetlag");
reise.AddUnternehmung("Nakatsugawa",1,"Ryokan O","Von Osaka: 4-5h","Ankunft: 18 Uhr");
reise.AddUnternehmung("Nakatsugawa",1,"Ryokan O","Magome-Tsumago-Pfad","Museumsdorf");
reise.AddUnternehmung("Matsumoto",1, "Mitsubikiya", "Wasabifarm","Burg Matsumoto");
reise.AddUnternehmung("Takayama",1,"Wanosato",new DateOnly(2024,4,12));
reise.AddUnternehmung("Takayama",4,"Wing International","Frühlingsfest","Shirakawago");
reise.AddUnternehmung("Osaka",1,"Hokke Club","Anreise, Übernachtung");
reise.AddUnternehmung("Osaka",1,"Hokke Club","Dragon Quest Land");
reise.AddUnternehmung("Tanabe",1,"The CUE",new DateOnly(2024,4,19),"Anreise nach Tanabe, Rumpimmeln in Tanabe");
reise.AddUnternehmung("Chikatsuyu", 1, "Minshuku WAGO",new DateOnly(2024,4,20), "Kumano-Kodo-Pfad, Takajiri->Chikatsuyu");
reise.AddUnternehmung("Hongu", 1, "--", "Kumano-Kodo-Pfad, Chikatsuyu->Hongu");
reise.AddUnternehmung("Nachi",1,"--",new DateOnly(2024,4,22),"Bootstour->Hayatama, Hayatama angucken, nach Nachi laufen");
reise.AddUnternehmung("Osaka",1,"APA Hotel Umeda-eki Tower",new DateOnly(2024,4,23),"Nachi Taisha angucken, RÜckfahrt nach Osaka");
reise.AddUnternehmung("Osaka",1,"--",new DateOnly(2024,4,24),"Rumbummeln","Burg Osaka","Dotonburi","Pokemon Cafe,Rückflug");
reise.PrintKalender();
reise.WriteToFile("Japanreise_2024.txt");