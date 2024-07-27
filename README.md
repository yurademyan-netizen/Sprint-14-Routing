## Please, update the initial application so that a user will be able to:

1. View list of products (page available via ../products/index, ../items/index, ../products/ and ../items)
2. User can click on Edit, View links that lead to corresponding views
3. Edit a product can be performed
4. A new product can be added
5. Delete of a product can be performed by clicking on the corresponding Delete link
6. View info about a product (page available via ../products/id)
7. Edit a product (page available via ../products/edit/id )
8. Delete a product (page available via ../products/delete/id)
9. Create a product (page available via ../products/create and ../products/new)
10. Filter products list by parameter(s) that can be set in query string
11. When there isn't a product with the corresponding id then redirect to custom 404 error page which will contain the text "The product does not exist" and a link to the list of all products.
12. The admin part should show a list of users. It is shown only if the request is with the parameter equal to "df2323eoT". The parameter should not be shown neither as route parameter nor in query string, it should be sent in the query of a request body. (url should look like this: ../users/index). If there is no such parameter, please, return the user unauthorized result.
