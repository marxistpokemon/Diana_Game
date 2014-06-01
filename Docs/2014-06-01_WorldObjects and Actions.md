Every object in the world, be it an item carried and used by the player or a prop in the world scenario, is interactive.

#### `abstract class ItemProperty`

This is a component which extends from `MonoBehavior`. This abstract class takes care of loading `ItemProperty` components from data files, as well as other helper functions. All components which give a new interactive property to a world object must extend this class.

#### `abstract class Action`

Model for a class which brings together all the requirements for a player's action, as well as the proper bindings to its execution. All classes which define a behavior for interacting with a world object must extend `Action`.

#### `singleton Inventory`

Controls the equipment slots, as well as a storage list where any item with the `Portable` component can be stored. Also handles weights and capacity.
