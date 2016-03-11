using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Shoes
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
          return View["index.cshtml"];
      };

      Post["/stores/new"] = _ => {
        Store newStore = new Store(Request.Form["newStore-name"]);
        newStore.Save();
        List<Store> stores = Store.GetAll();
        return View["stores.cshtml", stores];
      };

      Post["/brands/new"] = _ => {
        Brand newBrand = new Brand(Request.Form["newBrand-name"]);
        newBrand.Save();
        List<Brand> brands = Brand.GetAll();
        return View["brands.cshtml", brands];
      };

      Get["/stores/new/{id}"] = parameters => {
        Brand SelectedBrand = Brand.Find(parameters.id);
        return View["addStore.cshtml", SelectedBrand];
      };

      Post["/stores/new/{id}"] = parameters => {
        Brand SelectedBrand = Brand.Find(parameters.id);
        Store newStore = new Store(Request.Form["new-store"]);
        newStore.Save();
        SelectedBrand.AddStore(newStore.GetId());
        List<Store> stores = SelectedBrand.GetStores();

        return View["brandStores.cshtml", stores];
      };

      Get["/brands/new/{id}"] = parameters => {
        Store SelectedStore = Store.Find(parameters.id);
        return View["addBrand.cshtml", SelectedStore];
      };

      Post["/brands/new/{id}"] = parameters => {
        Store SelectedStore = Store.Find(parameters.id);
        Brand newBrand = new Brand(Request.Form["new-brand"]);
        newBrand.Save();
        SelectedStore.AddBrand(newBrand.GetId());
        List<Brand> brands = SelectedStore.GetBrands();

        return View["storeBrands.cshtml", brands];
      };

      Get["/stores"] = _ => {
        List<Store> stores = Store.GetAll();
        return View["stores.cshtml", stores];
      };

      Get["/brands"] = _ => {
        List<Brand> brands = Brand.GetAll();
        return View["brands.cshtml", brands];
      };

      Get["/storeBrands/{id}"] = parameters => {
        Store SelectedStore = Store.Find(parameters.id);
        List<Brand> brands = SelectedStore.GetBrands();

        return View["storeBrands.cshtml", brands];
      };

      Get["/brandStores/{id}"] = parameters => {
        Brand SelectedBrand = Brand.Find(parameters.id);
        List<Store> stores = SelectedBrand.GetStores();

        return View["brandStores.cshtml", stores];
      };

      Get["/stores/edit/{id}"] = parameters => {
        Store SelectedStore = Store.Find(parameters.id);
        return View["store_edit.cshtml", SelectedStore];
      };

      Patch["/stores/edit/{id}"] = parameters => {
        Store SelectedStore = Store.Find(parameters.id);
        SelectedStore.Update(Request.Form["store-name"]);
        List<Store> stores = Store.GetAll();
        return View["stores.cshtml", stores];
      };

      Delete["/stores/deleteAll"] = _ => {
        Store.DeleteAll();
        List<Store> stores = Store.GetAll();
        return View["stores.cshtml", stores];
      };

      Delete["/stores/delete/{id}"] = parameters => {
        Store SelectedStore = Store.Find(parameters.id);
        SelectedStore.Delete();
        List<Store> stores = Store.GetAll();
        return View["stores.cshtml", stores];
      };


    }
  }
}
