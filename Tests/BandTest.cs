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
   public void Test7_EmptyDatabase()
   {
     //Arrange, Act
     int result = Band.GetAll().Count;

     //Assert
     Assert.Equal(0, result);
   }

   [Fact]
   public void Test8_SameName()
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




    public void Dispose()
    {

      Band.DeleteAll();
    }
  }
}
