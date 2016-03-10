using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Shoes
{
  public class BrandTest : IDisposable
  {
    public BrandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=shoe_stores_test;Integrated Security=SSPI;";
    }



    [Fact]
    public void Test_BrandsEmptyAtFirst()
    {
      int result = Brand.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Brand firstBrand = new Brand("Nike");
      Brand secondBrand = new Brand("Nike");

      Assert.Equal(firstBrand, secondBrand);
    }
    [Fact]
    public void Test_Save_SavesBrandToDatabase()
    {
      //Arrange
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      //Act
      List<Brand> result = Brand.GetAll();
      List<Brand> testList = new List<Brand>{testBrand};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToBrandObject()
    {
      //Arrange
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      //Act
      Brand savedBrand = Brand.GetAll()[0];

      int result = savedBrand.GetId();
      int testId = testBrand.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsBrandInDatabase()
    {
      //Arrange
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      //Act
      Brand foundBrand = Brand.Find(testBrand.GetId());

      //Assert
      Assert.Equal(testBrand, foundBrand);
    }

    [Fact]
    public void Test_GetBrands_RetrievesAllBrands()
    {
      Brand firstBrand = new Brand("Nike");
      firstBrand.Save();
      Brand secondBrand = new Brand("Adidas");
      secondBrand.Save();

      List<Brand> testBrandList = new List<Brand> {firstBrand, secondBrand};
      List<Brand> resultBrandList = Brand.GetAll();

      Assert.Equal(testBrandList, resultBrandList);



    }
    [Fact]
    public void Test_GetAllStoresFromBrand_RetrievesAllStoresFromGivenBrand()
    {
      Store newStore = new Store("Sears");
      newStore.Save();
      // Console.WriteLine(newStore.GetName()+" "+newStore.GetId());
      Brand newBrand = new Brand("Nike");
      newBrand.Save();
      // Console.WriteLine(newBrand.GetName()+" "+newBrand.GetId());

      newBrand.AddStore(newStore.GetId());
      // Console.WriteLine(newStore.GetBrands().Count);
      List<Store> resultStores = newBrand.GetStores();
      // Console.WriteLine(resultBrands.Count);

      List<Store> testStores = new List<Store> { newStore };

      Assert.Equal(testStores, resultStores);




    }
    public void Dispose()
    {
       Brand.DeleteAll();
       Store.DeleteAll();
    }
  }
}
