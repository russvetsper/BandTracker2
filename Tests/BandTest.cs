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



    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
