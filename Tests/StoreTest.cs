using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Shoes
{
  public class StoreTest : IDisposable
  {
    public StoreTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=shoe_stores_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
       Store.DeleteAll();
    }

    [Fact]
    public void Test_StoresEmptyAtFirst()
    {
      int result = Store.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Store firstStore = new Store("Sears");
      Store secondStore = new Store("Sears");

      Assert.Equal(firstStore, secondStore);
    }
    [Fact]
    public void Test_Save_SavesStoreToDatabase()
    {
      //Arrange
      Store testStore = new Store("Sears");
      testStore.Save();

      //Act
      List<Store> result = Store.GetAll();
      List<Store> testList = new List<Store>{testStore};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToStoreObject()
    {
      //Arrange
      Store testStore = new Store("Sears");
      testStore.Save();

      //Act
      Store savedStore = Store.GetAll()[0];

      int result = savedStore.GetId();
      int testId = testStore.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsStoreInDatabase()
    {
      //Arrange
      Store testStore = new Store("Sears");
      testStore.Save();

      //Act
      Store foundStore = Store.Find(testStore.GetId());

      //Assert
      Assert.Equal(testStore, foundStore);
    }

    [Fact]
    public void Test_GetStores_RetrievesAllStores()
    {
      Store firstStore = new Store("Sears");
      firstStore.Save();
      Store secondStore = new Store("Target");
      secondStore.Save();

      List<Store> testStoreList = new List<Store> {firstStore, secondStore};
      List<Store> resultStoreList = Store.GetAll();

      Assert.Equal(testStoreList, resultStoreList);



    }
  }
}
