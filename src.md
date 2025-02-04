# src

Como ya se dijo, esta carpeta es la encargada de gestionar toda la organizacion de la aplicacion y guardar todo el codigo fuente necesario para realizar las funcionalidades del negocio.

En ella podemos encontrar:

## 1. app

Una carpeta `app` que es la que guardara todo nuestro codigo relacionado a `modulos` y `componentes` de nuestro negocio. Podran encontrar mas informacion [aca](https://github.com/Maticor93/DA2-Tecnologia/blob/angular-create-project/app.md)

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
|   |   |── business-components
|   |   |── components
|   |   |── layouts
|   |   |── app.module.ts
|   |   |── app.component.ts
|   |   |── app-routing.module.ts
|   |   |── app.component.html
|   |── backend
|   |   |── services
|   |   |   |── models
|   |   |── repositories
|   |── index.html
|   |── main.ts
|   |──styles.css
|── public
|   |── favicon.ico
```
Donde `business-components` es una carpeta que guarda componentes `standalone` que tienen como responsabilidad encapsular una porcion pequeña del negocio para ser reusada en otras partes de la aplicacion.

La carpeta `components` guarda componentes esqueletos `standalone` que tienen como responsabilidad encapsular template HTML de componentes base y genericos para construir el resto de elementos de la aplicacion. Estos componentes son fundamentales para la construccion de la aplicacion ya que la aplicacion se basa en la disponibilidad de estos componentes.

La carpeta `backend` guardara aquellas clases denominadas servicios para la consumicion de la data. Dentro de ella podemos encontrar la carpeta `services` que seran los servicios que utiliza los componentes en `business-components` o en otros componentes de la aplicacion. Estos servicios no seran consumidos por componentes en `components`. Para evitar que los componentes se acomplen a la forma de obtencion de los datos, se creo la carpeta `repositories` donde se guardaran los servicios asociados a la manipulacion de los datos, es decir, estos servicios se comunicaran con una API en caso de consumir endpoints o consumir datos en memoria. Lo importante es que los componentes no conozcan de donde provienen estos datos.
