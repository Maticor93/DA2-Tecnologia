# src

Como ya se dijo, esta carpeta es la encargada de gestionar toda la organizacion de la aplicacion y guardar todo el codigo fuente necesario para realizar las funcionalidades del negocio.

En ella podemos encontrar:

## 1. app

Una carpeta `app` que es la que guardara todo nuestro codigo relacionado a `modulos` y `componentes` de nuestro negocio.

## 2. assets

Una carpeta que guarda todo recurso estatico utilizado en la aplicacion. Pueden ser imagenes u otros archivos necesarios para operar.

## 3. environments

Esta carpeta define las diferentes configuraciones de ambientes disponibles en los cuales ejecutar la aplicacion. Es un buen lugar para configurar que servidor api web se estara consumiendo la data. Dicho valor varia para cada ambiente.

## 4. index.html

Este template HTML es la raiz de la aplicacion, desde aca comienzan todas las inclusiones y llamadas. Sera el unico HTML generado cuando se compile al estar trabajando con una SPA.

## Organizacion de una aplicacion

La organizacion de la aplicacion que debemos respetar es la siguiente:

```
src
|── app
|   |── app.module.ts
|   |── app.component.ts
|   |── app-routing.module.ts
|   |── app.component.html
|── backend
|   |── services
|   |   |── models
|   |── repositories
|── business-components
|── components
|── assets
|── environments
|   |── environment.prod.ts
|   |── environment.ts
|── favicon.ico
|── index.html
|── main.ts
|──polyfills.ts
|──styles.css

```
