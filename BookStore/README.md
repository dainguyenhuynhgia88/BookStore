# BookStore
- This project was implemented by Dai Nguyen

## Back-end side
1. Dot Net Core

2. Mediator
- This pattern helps us to separate the code to two workflows: command to modify data and query to retrieve data
- It also helps us to reduce the number of dependencies. We only need to deal with one dependency is Mediator, others dependencies are resolved by Mediator by itself
- A command or query only has single work, so it's readable and maintainable
- The library helps us to deal with Dependency Injection, we don't need to worry about DI work
- This also complies to Single responsiblity principle

3. Scrutor
- This library helps us to deal with Dependency Injection for the services

4. JsonConverter
- I created a custom JsonConverter class, so that we can apply Polymorphism for the DeliveryInfo property
- This complies to Liskov substitution principle

5. Dynamic pagination/ filter
- I implemented generic approach for filter. Therefore, if we want to filter the books by other properties, we would only need to extend the filterColumns instead of modify the query statement
- This complies to Open/ closed principle

## Front-end side
1. Angular Framework
- The framework powers up HTML with built in directives
- Data binding feature is very useful and helps us to reduce the effort for implementation
- Structure the application as modules, so it's readable and maintainable
- It also has built in service to integrate with Back-end side

2. SASS/ SCSS

3. Angular Material
- It's official library that implements Material Design of Angular

4. Bootstrap
- It's common library to build the responsive UI

5. Ngx-toastr
- Helps us to reduce the effort to build the toast message
- The latest release was 10 days ago at the time I was writing this documentation
- The documentation is very clear and easy to follow
- Weekly download times are about 200000

6. Typescript
- It helps us to apply strong-typed for Javascript
- Developed by Microsoft
- TypeScript doesn’t alter JavaScript, instead expanding it with new and valuable features

## Bonus work
- Pagination

## Time summary
- Preparation: 1 hour
- Coding: 6 hours
- Styling 1 hour
- Testing 30 minutes

Grand total: 8.5 hours
