[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-create-project)

# Elementos de una aplicacion Angular

## 1. node_modules

Lo primero que vamos a encontrar es una carpeta llamada `node_modules`, esta carpeta contiene todas las dependencias que la aplicacion necesita para compilar y ser ejecutada. Como es de imaginarse, el tamaño de esta carpeta es demasiado grande por lo cual nunca debe ser comiteada al repositorio, por suerte, cuando creamos una aplicacion Angular, la misma trae un `.gitignore` que ignora esta carpeta.

Esta carpeta tiene las compilaciones de todas las dependencias, de todas las librerias que nuestra aplicacion utiliza. Es por eso que pesa mucho y nunca vamos a trabajar directamente en ella, podremos hacer alguna busqueda puntual para verificar si hay una dependencia instalada pero no mucho mas.

Como esta carpeta es ignorada, siempre que descarguen una aplicacion angular ya sea clonando un repositorio o descargando el codigo fuente, antes de correr dicha aplicacion tienen que instalar localmente las dependencias de la aplicacion ejecutando: `npm install`.

Si esta carpeta es eliminada, la misma se debera de generar nuevamente previamente a la ejecucion de la aplicacion.

## 2. src

En esta carpeta encontraremos todo el codigo fuente de la aplicacion, es donde trabajaremos en la creacion de nuevos componentes y el mantenimiento de los existentes.

Dentro de esta podremos encontrar lo siguiente:

### 2.1. app

Una carpeta `app` que es la que guardara todo nuestro codigo relacionado a `modulos` y `componentes` de nuestro negocio.

### 2.2. assets

Una carpeta que guarda todo recurso estatico utilizado en la aplicacion. Pueden ser imagenes u otros archivos necesarios para operar.

### 2.3. environments

Esta carpeta define las diferentes configuraciones de ambientes disponibles en los cuales ejecutar la aplicacion. Es un buen lugar para configurar que servidor api web se estara consumiendo la data. Dicho valor varia para cada ambiente.

### 2.4. index.html

Este template HTML es la raiz de la aplicacion, desde aca comienzan todas las inclusiones y llamadas. Sera el unico HTML generado cuando se compile al estar trabajando con una SPA.

### main.ts

Archivo que inicia el proceso de bootstrap

### styles.css

Archivo de estilado para estilos globales a la aplicaicon. Cualquier estilo definido aca sera accesible en cualquier parte de la aplicacion.

## 3. .browserslistrc

Archivo que lista los navegadores que pueden soportar la aplicacion Angular. Es usado en tiempo de compilacion para ajustar el codigo a ser soportado por los navegadores listados.

## 4. angular.json

Es un archivo de configuracion de Angular que indica elementos de buildeo, arquitectura, ambientes, etc.

## 5. package-lock.json

Es un archivo que provee informacion de las versiones y dependencias de los paquetes instalados que se encuentran en `node_modules`

## 6. package.json

Es un archivo donde se listan todas las dependencias que la aplicacion tiene, la misma tambien define los comandos disponibles para ejecutar sobre la aplicacion.
