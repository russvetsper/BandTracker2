using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_VenuesEmpty()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }


    [Fact]
    public void Test2_SameName()
    {
      //Arrange, Act
      Venue firstVenue = new Venue("Maxwel");
      Venue secondVenue = new Venue("Maxwel");

      //Assert
      Assert.Equal(firstVenue, secondVenue);
    }


    [Fact]
     public void Test3_SaveVenue()
     {
       //Arrange
       Venue testVenue = new Venue("Maxwel");
       testVenue.Save();

       //Act
       List<Venue> result = Venue.GetAll();
       List<Venue> testList = new List<Venue>{testVenue};

       //Assert
       Assert.Equal(testList, result);
     }

     [Fact]
    public void Test4_FindVenue()
    {
      //Arrange
      Venue testVenue = new Venue("Maxwel");
      testVenue.Save();

      //Act
      Venue foundVenue = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, foundVenue);
    }

    [Fact]
    public void Test5_DeleteVenue()
    {
      //Arrange
      string name1 = "Maxwel";
      Venue testVenue1 = new Venue(name1);
      testVenue1.Save();

      string name2 = "Largo";
      Venue testVenue2 = new Venue(name2);
      testVenue2.Save();

      //Act
      testVenue1.Delete();
      List<Venue> resultVenues = Venue.GetAll();
      List<Venue> testVenueList = new List<Venue> {testVenue2};

      //Assert
      Assert.Equal(testVenueList, resultVenues);
    }

    [Fact]
    public void Test6_SaveId()
    {
      //Arrange
      Venue testVenue = new Venue("Largo");
      testVenue.Save();

      //Act
      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
 public void Test7_AddVenueBand()
 {
   //Arrange
   Venue testVenue = new Venue("Maxwel");
   testVenue.Save();

   Band testBand1 = new Band("Beatles");
   testBand1.Save();

   Band testBand2 = new Band("U2");
   testBand2.Save();

   //Act
   testVenue.AddBand(testBand1);
   testVenue.AddBand(testBand2);

   List<Band> result = testVenue.GetBands();
   List<Band> testList = new List<Band>{testBand1, testBand2};

   //Assert
   Assert.Equal(testList, result);
 }

 [Fact]
   public void Test8_ReturnsVenueBands()
   {
     //Arrange
     Venue testVenue = new Venue("Maxwel");
     testVenue.Save();

     Band testBand1 = new Band("Beatles");
     testBand1.Save();

     Band testBand2 = new Band("U2");
     testBand2.Save();

     //Act
     testVenue.AddBand(testBand1);
     List<Band> savedBands = testVenue.GetBands();
     List<Band> testList = new List<Band> {testBand1};

     //Assert
     Assert.Equal(testList, savedBands);
   }

   [Fact]
   public void Test9_DeleteVenueBand()
   {
     //Arrange
     Band testBand = new Band("U2");
     testBand.Save();

     Venue testVenue = new Venue("Maxwel");
     testVenue.Save();

     //Act
     testVenue.AddBand(testBand);
     testVenue.Delete();

     List<Venue> resultBandVenues = testBand.GetVenues();
     List<Venue> testBandVenues = new List<Venue> {};

     //Assert
     Assert.Equal(testBandVenues, resultBandVenues);
   }

   [Fact]
   public void Test10_UpdateVenue()
   {
     //Arrange
     string name = "Maxwel";
     Venue testVenue = new Venue(name);
     testVenue.Save();
     string newName = "Largo";

     //Act
     testVenue.Update(newName);

     string result = testVenue.GetName();

     //Assert
     Assert.Equal(newName, result);
   }





    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
