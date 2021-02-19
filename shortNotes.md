# Flow of command for menufactory
- interface IAbstractMenuFactory defines IAbstractProduct methods and is then implemented by the concrete factory class concreteMenuFactory
-   The concrete factory class instantiates types of interfaces for the specified menu
-   the menu interface that defines all types of that certain menu is then implemented

# abstract factory notes
- an abstract factory pattern uses a super factory, or a "factory of factories".
- The factory pattern is a way of replacing manual object instantiation with delegation to a class whose purpose is to create objects