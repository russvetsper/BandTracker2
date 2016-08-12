using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
   public void Test1_EmptyDatabase()
   {
     //Arrange, Act
     int result = Band.GetAll().Count;

     //Assert
     Assert.Equal(0, result);
   }

   [Fact]
   public void Test2_SameName()
   {
     //Arrange, Act
     Band firstBand = new Band("Beatles");
     Band secondBand = new Band("Beatles");

     //Assert
     Assert.Equal(firstBand, secondBand);
   }

   [Fact]
    public void Test3_SaveBand()
    {
      //Arrange
      Band testBand = new Band("Beatles");
      testBand.Save();

      //Act
      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
   public void Test4_FindBand()
   {
     //Arrange
     Band testBand = new Band("Beatles");
     testBand.Save();

     //Act
     Band foundBand = Band.Find(testBand.GetId());

     //Assert
     Assert.Equal(testBand, foundBand);
   }

   [Fact]
   public void Test5_SaveBandId()
   {
     //Arrange
     Band testBand = new Band("Beatles");
     testBand.Save();

     //Act
     Band savedBand = Band.GetAll()[0];

     int result = savedBand.GetId();
     int testId = testBand.GetId();

     //Assert
     Assert.Equal(testId, result);
   }

   [Fact]
    public void Test6_AddVenueToBand()
    {
      //Arrange
      Band testBand = new Band("Beatles");
      testBand.Save();

      Venue testVenue = new Venue("Maxwel");
      testVenue.Save();

      //Act
      testBand.AddVenue(testVenue);

      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue>{testVenue};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test7_DeletesBand()
    {
      //Arrange
      Venue testVenue = new Venue("Maxwel");
      testVenue.Save();

      Band testBand = new Band("Beatles");
      testBand.Save();

      //Act
      testBand.AddVenue(testVenue);
      testBand.Delete();

      List<Band> resultVenueBands = testVenue.GetBands();
      List<Band> testVenueBands = new List<Band> {};

      //Assert
      Assert.Equal(testVenueBands, resultVenueBands);
    }

    [Fact]
      public void Test7_ReturnBandVenues()
      {
        //Arrange
        Band testBand = new Band("Beatles");
        testBand.Save();

        Venue testVenue1 = new Venue("U2");
        testVenue1.Save();

        Venue testVenue2 = new Venue("Largo");
        testVenue2.Save();

        //Act
        testBand.AddVenue(testVenue1);
        List<Venue> result = testBand.GetVenues();
        List<Venue> testList = new List<Venue> {testVenue1};

        //Assert
        Assert.Equal(testList, result);
      }





    public void Dispose()
    {

      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
