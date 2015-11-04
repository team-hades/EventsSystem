# Events System
---

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
|POST (public) | api/users/register | Registers a new user in the forum |
|POST (public) | api/users/login | Logs in a user in the forum 
|PUT | api/users/logout | Logs out a user from the forum |
|POST| api/events| Creates a new thread, returns the events created so it can be loaded in the UI|
|GET (public) | api/events | Gets top 10 articles, sorted by their date of publishing |     
|GET (public) |	api/events?page=P |	Gets the events at positions from P*10 to (P+1)*10. The articles sorted by date of creation and are at most 10.|
|GET | api/events?category=[categoryName] | Gets top 10 articles in category “categoryName”, sorted by their date of creation |
|GET | api/events?category=[categoryName]&page=P | Gets the articles in category “categoryName” at positions from P*10 to (P+1)*10. The articles sorted by date of creation and are at most 10. | 
|GET | api/events/{eventId} | Get article with ID = articleID, with 10 comments sorted by date | 
|POST | api/events/{eventId}/comments | Creates a new comment for a given event | 
|GET | api/categories | Gets all categories |
|GET | api/categories/{categorId} | Gets all events, sorted by date, from Category with Id = categorId | 
|GET | api/tags | Gets all tags | 
|GET | api/tags/{tagId} | Gets all events, sorted by date, that have Tag with Id = categorId | 
|POST | api/events/like/{eventId} | Creates a like by the current user for the article with Id = articleId | 
|PUT | api/events/like/{eventId} | Removes a like by the current user for the article with Id = articleId | 
|GET | api/alerts | Get all alerts with date of expiration later than today







