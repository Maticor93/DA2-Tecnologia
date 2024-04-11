# Tips Clean Code

Clean code es codigo que:

- Facil de leer
- Facil de mantener
- Facil de entender

Escribir clean code es una habilidad la cual se puede aprender.

## 1. Remplazar condiciones de if complejas por metodos descriptivos

Las condiciones complejas dentro de un if complejisan la lectura y el entendimiento de la condicion, cuanto mas condiciones abarca, mas dificil es de interpretar y de mantener.

La solucion es mover la condicion a un metodo o variable con un nombre descriptivo. El nombre debe de ser lo mas detallado posible.

Esta practiva una mejora significante en la lectura del codigo.

<p align="center">
<img src="./images/image.png">
</p>

<p align="center">
[If statement -> Method]
</p>

## 2. Juntar varias condiciones de ifs en uno

La idea principal es evitar muchos ifs anidados los culaes abren siempre caminos logicos. Lo ideal seria agruparlos en una unica condicion.

<p align="center">
<img src="./images/image-2.png">
</p>

<p align="center">
[Merge condiciones de ifs]
</p>
