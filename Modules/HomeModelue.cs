using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/venues"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["venues.cshtml", AllVenues];
      };

      Get["/venues/new"] = _ => {
        return View["venues_form.cshtml"];
      };

      Post["/venues/new"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        return View["success.cshtml"];
      };

      Get["venue/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        return View["venue_delete.cshtml", SelectedVenue];
      };

      Delete["venue/delete/{id}"] = parameters => {
       Venue SelectedVenue = Venue.Find(parameters.id);
       SelectedVenue.Delete();
       return View["success.cshtml"];
     };

     Post["/venues/delete"] = _ => {
       Venue.DeleteAll();
       return View["cleared.cshtml"];
     };

     Get["venue/edit/{id}"] = parameters => {
       Venue SelectedVenue = Venue.Find(parameters.id);
       return View["venue_edit.cshtml", SelectedVenue];
     };

     Patch["venue/edit/{id}"] = parameters => {
       Venue SelectedVenue = Venue.Find(parameters.id);
       SelectedVenue.Update(Request.Form["venue-name"]);
       return View["success.cshtml"];
     };

    }
  }
}
