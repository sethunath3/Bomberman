# BomberMan

ArtAssetLink: http://enva.to/BombingChapSprites

Simple version of BomberMan game made using unity3D.

* Created the grid using Unity TileMaps.
* Used Service->MVC architecture for all the components(except for independent manager classes).
* Explosion Animations are pooled for optimization.
* Used interfaces for making the damageable behaviour(now only player and Enemy are damageable).
* Properties of enemy is designed as a scrptable object so that new enemies can be introduced easly.
* Score Card is de-coupled using observer pattern.
* Enemy Patrolling - At each cell enemy looks for a new random target cell.
