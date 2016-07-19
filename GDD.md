# PlanetXploit's Design Doc

## Overview

PlanetXploit is an idle game focused on gathering resources with moderated user interaction.

## Views

* **[Planet view]**. Current visited planet view.
* **[Universe view]**. An icon will be shown at the planet where the player currently is.
* **[Stats view]**. The player can view its stats.
* **[Research view]**. The player can **[research]** tech to discover and upgrade **[buildings]** among other upgrades like reducing **[travel]** cost in **[xargon]**.

## Resource types

* **[Froncetite]** - Rare, gas. Only found in gas planets.
  * Used to build **[froncetite]** and **[xargon]** gathering buildings
* **[Sandetite]** - Rare, solid. Only found in solid planets.
  * Used to build **[sandetite]** and **[xargon]** gathering buildings
* **[Xargon]** - Common, liquid. Found everywhere.
  * Used to build **[froncetite]**, **[sandetite]** and **[xargon]** gathering buildings

All planets have **[xargon]**, but only a few planets can have **[sandetite]** or **[froncetite]**.


## Planets

Each planet can have one following states:
* Solid
* Gas
* Solid with some gas

Planet properties:

* **[Base gathering rate]** for each resource kind.
* **[Size]** - Only aesthetics
* **[Temperature]** - Only aesthetics

## Storaging

There are two storage types:

* **[Planet storage]**
* **[Player storage]**

Each planet has its own material storage. When the player is not present in a planet but there are gatherers in it, resources will be stored in the planet storage, and not directly given to the player. These resources are moved to the player storage by visiting the planet.

## Player actions

* In **[planet view]**
  * Click on the planet to **[gather]** resources into **[player storage]**.
  * Click on icon at top right to go to **[universe view]**.
  * Click on icons at bottom to construct **[buildings]**.

* In **[universe view]**
  * Click on a planet opens a contextual menu:
    * **[Travel]** - Only active if the player has enough **[xargon]** to travel.
    * **[Visit]** - Go to **[planet view]**.

## Player mobility

The player starts in a planet, which will surely have **[xargon]** (because all planets have). The player needs a certain amount of **[xargon]** to travel between planets. The traveling time and **[xargon]** needed depends on the distance. For the jam, this time will be reduced.              

**Possible upgrade:** require more **[xargon]** depending on how much resources the player have.
