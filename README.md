# Zorro y Cherry

Arcade 2D top-down construido como ejercicio de arquitectura de software: el valor del proyecto está en cómo está organizado el código bajo el patrón **MVC (Model-View-Controller)**, con una separación clara de responsabilidades entre datos, presentación y lógica de control.

## Como juego

Controlás a un zorro que recolecta cerezas para subir el puntaje, mientras evita (o aprovecha) los proyectiles de un slime enemigo que dispara a intervalos regulares. Se gana al llegar a 100 puntos; se pierde al quedarse sin vidas (3 impactos).

## Arquitectura (MVC)

El código del gameplay vive en `Assets/Scripts/` y está dividido en tres clases, cada una con una única responsabilidad:

- **`GameModel`** — guarda y modifica el estado del juego: vida, puntaje, movimiento del jugador y la lógica de ataque del enemigo. No sabe nada de animaciones, sonido ni UI.
- **`GameView`** — se encarga exclusivamente de la presentación: animaciones de movimiento y daño, sonidos, iconos de vida, texto de puntaje y pantallas de victoria/derrota. No contiene ninguna regla de juego.
- **`GameController`** — es el único que conoce tanto al Model como a la View. Lee el input, detecta colisiones (balas, recolección de cerezas, condiciones de victoria/derrota) y coordina a los otros dos sin que se conozcan entre sí.

Esta separación permite cambiar la presentación (animaciones, sonidos, UI) o las reglas del juego (vida, puntaje, velocidad) de forma independiente, sin que un cambio en una capa obligue a tocar las otras.

## Controles

| Acción | Tecla |
| --- | --- |
| Mover | W A S D / flechas |
