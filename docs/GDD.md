# Taplanet Design Doc

## Overview

Taplanet is an idle game focused on gathering resources with moderated user interaction.

## Views

* **[Universe view]**. An icon will be shown at the planet where the player currently is.
* **[Planet view]**. Current visited planet view.
* **[Buildings view]**. Buildings present in current planet. The player can check how much **[RPS]** a specific building type is providing, for each unit and the whole pack of bought buildings of that type.
* **[Research view]**. The player can **[research]** tech to discover and upgrade **[buildings]** among other upgrades like reducing **[travel]** cost in **[xargon]**.
* **[Stats view]**. The player can view its stats.

## Planets and resources

Planet properties:

* **[Base gathering rate]** for each resource kind.
* **[Temperature]** - Influences present resources.
* **[State]** - Gas or solid. Influences present resources.
* **[Size]** - Influences number of buildings?


Resources in planets are infinite. The only thing that changes is the rate at which the player gather them. Special planets can be generated,

The player can find the following resource types in planets:

* **[Froncetite]** - Rare, gas.
  * Used to build **[froncetite]** and **[xargon]** gathering buildings
* **[Sandetite]** - Rare, solid.
  * Used to build **[sandetite]** and **[xargon]** gathering buildings
* **[Xargon]** - Common, liquid.
  * Used to build **[froncetite]**, **[sandetite]** and **[xargon]** gathering buildings

The way resources can be found in planets follow the next diagram:

![alt text](resource-diagram.png "Sample")

Planet colors are #FF0066 for hot planets and #55DDFF for cold planets. Other planets will have colors lerped from one to the other.

There will be special coloured planets which will contain a limited but quickly gathered amount of resources. These special colors will be:

| Color | resources | composition |
|-------|-----------|-------------|
| Cyan (#00FFFF) | **[xargon]**, **[sandetite]** | solid/liquid |
| Yellow (#FFFF00) | **[xargon]**, **[froncetite]** | gas/liquid |
| Magenta (#FF00FF) | **[sandetite]**, **[froncetite]** | gas/solid |
| Red (#FF0000) | **[xargon]**, **[froncetite]** | gas |
| Green (#00FF00) | **[xargon]**, **[froncetite]** | liquid |
| Blue (#0000FF) | **[xargon]**, **[froncetite]** | solid |


As a bonus, gas-based planets could have an increased probability of generating extremely bigger quantities of **[froncetite]**, and the same with solid-based planets and **[sandetite]**.

With a specific type of **[buildings]**, **[froncetite]** and **[sandetite]** can be converted into **[xargon]**. Otherwise, the player could get stuck in a planet, because **[xargon]** is used as fuel to **[travel]** between planets.

## Storaging

There are two storage types:

* **[Planet storage]**
* **[Player storage]**

Each planet has its own material storage. When the player is not present in a planet but there are gatherers in it, resources will be stored in the **[planet storage]**, and not directly given to the player. These resources are moved to the **[player storage]** by pressing the proper button in the UI. The player can chose how much resources to place in the ship and how much resources to place in the planet (limited by both planet and ship limits).

## Player actions

* In **[planet view]**
  * Click on the planet to **[gather]** resources into **[player storage]**.
  * Click on icon at top right to go to **[universe view]**.
  * Click on icons at bottom to construct **[buildings]**.

* In **[universe view]**
  * Click on a planet opens a contextual menu:
    * **[Travel]** - Only active if the player has enough **[xargon]** to travel.
    * **[Visit]** - Go to **[planet view]**.
    * **[Info]** - Checks general information about the planet.

## Player mobility

The player needs a certain amount of **[xargon]** to travel between planets. The traveling time and **[xargon]** needed depends on the distance and how much resources the player carries. If the player does not have any **[xargon]** available, then some resource converting will be needed. The only resource needed to build a converter is the resource that it will convert from to **[xargon]**, because otherwise the player could get stuck in a planet.

## Buildings

* **[Gatherers]**, for each resource. Each one is much better than the previous one at gathering resources and increase exponentially in cost and gathering rate. Different gatherers are needed depending on planet main status (**[solid]** or **[liquid]**).

* **[Container]**. To store resources in a planet. If containers are full, **[gatherers]** won't collect any material until the player has traveled to the planet and fetched the resources.
* **[Converters]**. For non-**[xargon]** materials, to turn them into **[xargon]**.
* **[Power plant]**. Needed in order to make other buildings work. If too much energy exceed, buildings will start to break randomly until power is restored.


## Ship

The ship has the following properties

* **[Cruising speed]**, reduced by the quantity of resources. All resources can decrease it by the same amount, or different for each resource type. The logic behind all decreasing the same independently from the material type and status can be that containers for gas are heavier.
* **[Resource cargo]** for each type.
* **[Base construction speed]**.

One material can decrease the **[cruising speed]** more but need less space, or need less base construction speed for buildings of that type. It can be a hi/lo, mid/mid, lo/hi relationship.

## Upgrades


All buildings can be upgraded.

|Building type|Effect|
|-------------|------|
|gatherer | increases gather rate |
|container|increases capacity|
|converters|increases conversion into xargon rate|
|power plant|increases power generated and overload support|

Also, the ship will also be upgradeable in the following properties

* Increase **[cruising speed]**
* Increase **[base construction speed]**
* Increase max **[resource cargo]** supported
