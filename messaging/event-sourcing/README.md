Project made for study propose.

Backend made with .NET 5, implementing a system that has EventSourcing and EventStore, so firstly we add/update/remove Vehicle and after that dispatch a event for EventHandler, who add a StoredEvent that have informations of the Event and the Entity State at this moment.

Frontend made with Angular 12, have two pages, Home and Vehicles. Vehicles has the list of all the Vehicles and options to add/update/remove/history a Vehicle, using bootstrap-modal. Also have interceptors to catch errors from backend, ngx-toastr and masks.
