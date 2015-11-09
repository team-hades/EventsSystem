# Events System
---
[![Build status](https://ci.appveyor.com/api/projects/status/lece5hskefnj5al9?svg=true)](https://ci.appveyor.com/project/georgimanov/eventssystem)
---

![Draft image for Events System](/EventsSystemDrawing.jpeg)

## Events System Description

`User Roles`
 * NotRegistered - not registered user
 * Registered - user with registration
 * Administrator - user with admin rights.

`User`

> a. Not Registered
* can **view** all events with comments and votes

> b. Registered
 * register, login and logout.
 * create comments for the events
 * up/down votes for events 
 * join event

> c. Administrators
* CRUD: events, categories, tags, comments

`Category`
 * holds events

`Event` 
* event has 1 category and 0 or more tags.
* holds comments
* has votes 
* holds joined users

`Vote`
* has user and event

`Comment`
* has user, event and content

 `Notifications` - are displayed on the page when new event is published.

## Applicataion Logic 

 -	Users register in the events page / Users login in the events page
     -	They receive SessionKey (token) for later authentication
 -	Users can view all events and their comments and votes
 -	Users (Admins) can create a new category, and it will be added to the other categories
 -	Users (Admins) can create a new event, and it will be added to the other events
 -	Users can open a sigle event and view its comments and likes. 
 -	Registered users can join event.
 -	Users can comment in any event
 -	Users can up/down vote for any event
 -	When creating an event optionally tags can be added;

 ## RESTful API Overview
| HTTP Method | Web service endpoint | Description |
|:----------:|:-----------:|:-------------|
|POST (public) | api/users/register | Registers a new user in the events system |
|POST (public) | api/users/login | Logs in a user in the events system 
|PUT | api/users/logout | Logs out a user from the events system |
|GET (public)|api/events|Gets top 10 public events, sorted by their date of creation|
|POST|api/events|Creates a new event, returns the event created so it can be loaded in the UI|
|PUT|api/events/{eventID}|Update an existing event, returns the event created so it can be loaded in the UI|
|DELETE|api/events/{eventID}|Delete an existing event, returns WHAT?? ID? (the event created so it can be loaded in the UI)|
|GET|api/events/{eventID}|Get event with ID = eventID, with 10 comments sorted by date|
|POST|api/events/join/{eventID}|Current user can join to the event with ID = eventID.|
|PUT|api/events/join/{eventID}|Current user can leave an event with ID = eventID.|
|GET (public)|api/events?page=P|Gets the events at positions from P*10 to (P+1)*10. The events sorted by date of creation and are at most 10.|
|GET|api/events?category=[categoryName]&town=[townName]|Gets top 10 events in category “categoryName” and town “townName”, sorted by their date of creation|
|GET|api/events?category=[categoryName]|Gets top 10 events in category “categoryName”,sorted by their date of creation|
|GET|api/events?category=[categoryName]&page=P|Gets the events in category “categoryName” at positions from P*10 to (P+1)*10. The events sorted by date of creation and are at most 10.|
|POST|api/events/{eventID}/comments|Creates a new comment for a given event|
|GET|api/categories|Gets all categories|
|GET|api/categories/{categorID}|Gets all events, sorted by date, from Category with ID = categorID|
|GET|api/tags|Gets all tags|
|GET|api/tags/{tagID}|Gets all events, sorted by date, that have Tag with ID = categorID|
|POST|api/events/rate/{eventId} header body: { “rate”: 1-5 (int)}|Creates rating by the current user for the event with ID = eventId|
|PUT|api/events/rate/{eventId} header body: { “rate”: 1-5 (int)}|Update rating by the current user for the event with ID = eventId|
