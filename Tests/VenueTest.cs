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
     public void Test3_Save_SaveVenue()
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




    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
