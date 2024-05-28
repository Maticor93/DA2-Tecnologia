# src

Como ya se dijo, esta carpeta es la encargada de gestionar toda la organizacion de la aplicacion y guardar todo el codigo fuente necesario para realizar las funcionalidades del negocio.

En ella podemos encontrar:

## 1. app

Una carpeta `app` que es la que guardara todo nuestro codigo relacionado a `modulos` y `componentes` de nuestro negocio. Podran encontrar mas informacion [aca](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular-create-project/app.md)

## 2. index.html

Este template HTML es la raiz de la aplicacion, desde aca comienzan todas las inclusiones y llamadas. Sera el unico HTML generado cuando se compile al estar trabajando con una SPA.

## 3. main.ts

Archivo que inicia el proceso de bootstrap

## 4. styles.css

Archivo de estilado para estilos globales a la aplicaicon. Cualquier estilo definido aca sera accesible en cualquier parte de la aplicacion.

## Organizacion de una aplicacion

La organizacion de la aplicacion que debemos respetar es la siguiente:

```
|
|── src
|   |── app
|   |   |── app.module.ts
|   |   |── app.component.ts
|   |   |── app-routing.module.ts
|   |   |── app.component.html
|   |── backend
|   |   |── services
|   |   |   |── models
|   |   |── repositories
|   |── business-components
|   |── components
|   |── index.html
|   |── main.ts
|   |──styles.css
|── public
|   |── favicon.ico

```
