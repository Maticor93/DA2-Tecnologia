[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-module)

# Creacion de modulos

En esta seccion realizaremos la implementacion de 3 modulos con routing, el encargado de la `Autenticacion`, `Peliculas` y `Usuarios`. Estos estaran situados dentro de la carpeta app:

```
|
|── src
|   |── app
|   |   |── app.module.ts
|   |   |── app.component.ts
|   |   |── app-routing.module.ts
|   |   |── app.component.html
|   |
```

Esperando obtener el siguiente resultado dentro de la organizacion:

```
|
|── src
|   |── app
|   |   |── movie
|   |   |── user
|   |   |── authentication
|   |   |── app.module.ts
|   |   |── app.component.ts
|   |   |── app-routing.module.ts
|   |   |── app.component.html
|   |
```

## Paso previo a la creacion de un modulo

Antes de crear el modulo es necesario situarnos en el lugar correcto para su creacion, dado que queremos crear modulos hijos a la raiz, nos debemos situar con la terminal en la carpeta `app`.

```CMD
cd src
cd app
```

## Creacion del modulo movie

Para la creacion de un modulo se debe ejecutar el comando:

```CMD
ng generate module <<nombre del modulo>>
```

Esto generara solamente los modulos, sin routing, pero como nosotros queremos con routing, ejectuar el comando:

```CMD
ng generate module movie --routing
```

Obteniendo el siguiente modulo:

<p align="center">
<img src="./images/image.png">
</p>
<p align="center">
[Mensaje de salida]
</p>

<p align="center">
<img src="./images/image-1.png">
</p>
<p align="center">
[Directorio y archivos nuevos]
</p>

La responsabilidad de este modulo es definir y atender cualquier tipo de URL relacionada con las peliculas y declarar y definir cualquier tipo de componentes relacionado a las peliculas.

Es importante destacar que para la generacion de cualquier elemento a traves de Angular CLI, no se pone el tipo del elemento ya que este es puesto por la herramienta.

## Creacion del modulo user y authentication

Repetir el paso de la creacion del modulo movie pero con user y authentication.

El resultado esperado es el siguiente:

### User

<p align="center">
<img src="./images/image-2.png">
</p>
<p align="center">
[Mensaje de salida]
</p>

<p align="center">
<img src="./images/image-3.png">
</p>
<p align="center">
[Directorio y archivos nuevos]
</p>

La responsabilidad de este modulo es definir y atender cualquier tipo de URL relacionada con los usuarios y declarar y definir cualquier tipo de componentes relacionado a los usuarios.

### Authentication

<p align="center">
<img src="./images/image-4.png">
</p>
<p align="center">
[Mensaje de salida]
</p>

<p align="center">
<img src="./images/image-5.png">
</p>
<p align="center">
[Directorio y archivos nuevos]
</p>

La responsabilidad de este modulo es definir y atender cualquier tipo de URL relacionada con la autenticacion y declarar y definir cualquier tipo de componentes relacionado a la autenticacion.