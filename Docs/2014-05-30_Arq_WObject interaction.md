# Interacting with world objects

### [Component] PlayerWorldInteraction

Controls the interacton of the player and world objects. When it receives a ```PlayerStartAction``` event it prepares a list of all available actions and processes all inputs from there.

### List<PlayerAction> availableActions

Stores all available actions currently possible.

#### GetAvailableActions

This method goes through the equiped items and overlapping world objects and builds a list of possible actions.

---

### [Singleton] ActionManager

This is a data storage which keeps references to all potential actions existing in the game.

---

### [Component] Inventory

Controls what is equiped by the player at any given moment.

---

### [Class] PlayerAction

This class is created on the fly, by checking what is equiped right now and what world objects are available to be acted upon in any given moment.

#### Verb
Depends on the active tools / objects equiped by the player.

#### Target
Object which will be affected by the action.

#### Show ()
Returns an understandable description of the action.

#### Run ()
Executes the action, initiating a cascade of changes across the parts involved.

#### Cancel ()
Stops displaying the action message to the player.

---

### [Class] Verb

