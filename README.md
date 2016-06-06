# MyWedding
When planning for my marriage in May 2016 I decided early that I would present information and details about our marriage on the web. However I realized that the existing wedding pages didn't meet my expectations, at least not the one that I found in Sweden. For that reason I decided to write my own solution!

My site has the following functions: A start page with overall information together with a photo gallery and a count down timer, information about the program/schedule, contact information with possibilities to send private messages, a wish list and a guest book.

The solution is mainly developed in Microsoft technologies. I have used ASP.NET MVC with the programming language C# and Entity Framework for data base access. Javascript and Bootstrap are also used, with help from the libraries JQuery and AngularJs.

The solution uses so called Responsive Design, which means that it scales automatically on computers, tablets and phones. The library Bootstrap helps with this part.

When reserving items on the wish list, only that part of the page is updated (not the entire page). This also means that the scroll position is not changed, which is good from a GUI perspective. JQuery and Ajax are used to implement this.

The guestbook is implemented via a RESTful Web API service and the Javascript library AngularJs.

Currently there are a few unit tests, more will follow. Moq is used for mocking objects.

I have installed the in Microsofts cloud, Azure. However currently a separate login is needed.

My plan is to develop the solution futher, making it possible for people to register their wedding events, together with color schemes etc.

If you have any questions feel free to ask Henrik Hjalmarsson, hjalmarsson.henrik@gmail.com


