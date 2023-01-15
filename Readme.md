## Fifth activity WebGL.
## Design Patterns Activity: Analyze the code you've developed for WebGL activities and look for a possible game design pattern that can be applied to improve their efficiency or expandability.

For this activity I have analyzed the code and I have seen that in the Controller.razor.cs file there is no specific video game design pattern. However, you can see some design principles on which the code is based.

![gif ejercicio 1](/imgs/Captura6.png)

![gif ejercicio 1](/imgs/Captura7.png)

![gif ejercicio 1](/imgs/Captura8.png)

![gif ejercicio 1](/imgs/Captura9.png)

![gif ejercicio 1](/imgs/Captura10.png)

The Coordinates2D and Angles2D class are examples of simple classes that encapsulate a single responsibility, that is, storing and operating on 2D coordinates and angles respectively. This is known as the Single Responsibility Principle (SRP) and is a highly recommended design principle when developing a game.

The IController interface and the Controller class refer to a design pattern called inversion of dependencies (IoC). This pattern consists of classes not directly depending on other classes, but on an interface or contract that defines the services that are offered. This makes classes easier to reuse and maintain since dependencies are clearly defined.

In short, the provided code is not based on a specific design pattern, but it does follow well-established design principles that help keep the structure clean and easy to understand.

## Layered Architecture.
One video game design pattern that could be applied is the layered architecture pattern. This pattern is based on dividing the game logic into different layers, each of which is responsible for a specific set of tasks.

To apply this pattern, I can separate the code into the following layers:

    - Coordinates Layer: for the Coordinates2D and Angles2D class.
    - Shared Layer: for the Controller class and the IController interface.

The Entities layer would be in charge of creating and storing the game entities, such as coordinates and angles. The Control layer would be in charge of handling the game logic, such as user input and entity handling.

Layering would help to better understand the code and keep it cleaner and easier to understand.

For which I have created another file called Coordinate.cs where we will have our first layer which is where Coordinates2D and Angles2D class are defined.

![gif ejercicio 1](/imgs/Captura1.png)

The truth is that in order to result in a minimal change in the code, it has caused quite a few problems due to how the code itself was defined. For example, I tried to change the name of the Shared class to Entities, to make it clearer, but that generated errors. in all the code, then it commented that there was ambiguous call with the public partial class Controller, when it was not, so the only solution has been to leave it and call it shared, since the Controller.razor file when calling "ctrlDiv" "mouseEvent" " keydownEvent" "keyupEvent", it generated errors because it said "that was not defined in the current context".

![gif ejercicio 1](/imgs/Captura2.png)

I have added the layers in the files "Imports.razor" and Game.razor.cs

![gif ejercicio 1](/imgs/Captura3.png)

![gif ejercicio 1](/imgs/Captura4.png)

This helps separate entity responsibilities and game control, and makes code easier to understand and maintain.

![gif ejercicio 1](/imgs/Captura5.png)

And we check that the code works:

![gif ejercicio 1](/images/gif.gif)
