﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Version 2 of 2019W CSD 3354 Assignment 1 Starter Code:

class JournalEntry
{
    public JournalEntry(string note, int dist)
    {
        villageName = note; distanceTraveled = dist;
        // TO DO : What additional code must you add to enable the Calculate Distance algorithm to 
        // produce an accurate result?
        HowFarToGetBack = distanceTraveled;
    }
    public int HowFarToGetBack = 0;
    private string villageName;
    private int distanceTraveled;
    public int getDistanceWalked() { return distanceTraveled; }
    public string getVillageName() { return villageName; }
}

class Hugi
{
    private static JournalEntry je;
    public static bool FoundAstrilde = false;

    // TO DO
    public static List<JournalEntry> HugiJournal = new List<JournalEntry>();

    public static int CalculateDistanceWalked()
    {
        int DistanceWalked = 0;
        // walk over the List and add the distances
        foreach (var je in HugiJournal)
        {
            Console.WriteLine(" {0}  --   {1} *** --- {2} ", je.getDistanceWalked(), je.getVillageName(), je.HowFarToGetBack);
            DistanceWalked += je.getDistanceWalked() + je.HowFarToGetBack;
        }
        return DistanceWalked;
    }
}

class CountrySide
{
    static void Main()
    {
        new CountrySide().Run();
    }

    // Create the LinkedList to reflect the Map in the PowerPoint Instructions
    Village Maeland;
    Village Helmholtz;
    Village Alst;
    Village Wessig;
    Village Badden;
    Village Uster;
    Village Schvenig;

    public void TraverseVillages(Village CurrentVillage)
    {
        try
        {

            if (Hugi.FoundAstrilde) return;

            // Here Hugi records his travels, as any Norse Hero will do:
            // TO DO : How does Hugi journal his visit to each village?
            Hugi.HugiJournal.Add(new JournalEntry(CurrentVillage.VillageName, CurrentVillage.distanceFromPreviousVillage));

            Console.WriteLine("I am in {0}", CurrentVillage.VillageName);



            if (CurrentVillage.isAstrildgeHere)
            {
                Console.WriteLine("I found Dear Astrildge in {0}", CurrentVillage.VillageName);
                Console.WriteLine("**** FEELING HAPPY!!! ******");
                Console.WriteLine("Astrilde, I walked {0} vika to find you. Will you marry me?", Hugi.CalculateDistanceWalked());
                Hugi.FoundAstrilde = true;
            }

            // TO DO: Complete this section to make the Recursion work           
            TraverseVillages(CurrentVillage.west);
            TraverseVillages(CurrentVillage.east);

        }
        catch (NullReferenceException)
        {
        }
    }

    public void Run()
    {
        Alst = new Village("Alst", false);
        Schvenig = new Village("Schvenig", false);
        Wessig = new Village("Wessig", false);
        Maeland = new Village("Maeland", false);
        Helmholtz = new Village("Helmholtz", false);
        Badden = new Village("Badden", false);
        Uster = new Village("Uster", true);
        // TO DO: Complete this section

        Alst.VillageSetup(0, Schvenig, Wessig);
        Schvenig.VillageSetup(14, Maeland, Helmholtz);
        Wessig.VillageSetup(19, Uster, Badden);
        Maeland.VillageSetup(9, null, null);
        Helmholtz.VillageSetup(28, null, null);
        Uster.VillageSetup(28, null, null);
        Badden.VillageSetup(11, null, null);
        // TO DO: Complete this section

        this.TraverseVillages(Alst);

    }

    public void Announcement()
    {
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("U:/Users/725030/annoucement.txt"))
            {
                string line;

                // Read and display lines from the file until 
                // the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}

class Village
{
    // http://www.vikinganswerlady.com/measurement.shtml

    public Village(string _villageName, bool _isAHere)
    {
        isAstrildgeHere = _isAHere;
        VillageName = _villageName;
    }
    public void VillageSetup(int _prevVillageDist, Village _westVillage, Village _eastVillage)
    {
        east = _eastVillage;
        west = _westVillage;
        distanceFromPreviousVillage = _prevVillageDist;
    }

    public Village west;
    public Village east;
    public string VillageName;
    public int distanceFromPreviousVillage;
    public bool isAstrildgeHere;
}








//Note: this is the Text that is to be outputted to the Screen at the end of the Program Run:
//*------------------------------------------------------*

//An Announcement was posted
//in "The Viking Village Newspaper", later that week:

//The Familes of Astridle Guðmundsdóttir and Hugi Ólafur
//are Happy to announce the Marriage of their Children.

//The Ceremony will take place on the third Sunnudagur of Góa
//at the Temple of Frigga in Alst.

//All are Welcome.