[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-create-project)

# Elementos de una aplicacion Angular

## 1. node_modules

Lo primero que vamos a encontrar es una carpeta llamada `node_modules`, esta carpeta contiene todas las dependencias que la aplicacion necesita para compilar y ser ejecutada. Como es de imaginarse, el tamaño de esta carpeta es demasiado grande por lo cual nunca debe ser comiteada al repositorio, por suerte, cuando creamos una aplicacion Angular, la misma trae un `.gitignore` que ignora esta carpeta.

Esta carpeta tiene las compilaciones de todas las dependencias, de todas las librerias que nuestra aplicacion utiliza. Es por eso que pesa mucho y nunca vamos a trabajar directamente en ella, podremos hacer alguna busqueda puntual para verificar si hay una dependencia instalada pero no mucho mas.

Como esta carpeta es ignorada, siempre que descarguen una aplicacion angular ya sea clonando un repositorio o descargando el codigo fuente, antes de correr dicha aplicacion tienen que instalar localmente las dependencias de la aplicacion ejecutando: `npm install`.

Si esta carpeta es eliminada, la misma se debera de generar nuevamente previamente a la ejecucion de la aplicacion.

## 2. src

En esta carpeta encontraremos todo el codigo fuente de la aplicacion, es donde trabajaremos en la creacion de nuevos componentes y el mantenimiento de los existentes. Se puede encontrar mas informacion sobre esta carpeta [aca](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular-create-project/src.md).

## 3. angular.json

Es un archivo de configuracion de Angular que indica elementos de buildeo, arquitectura, ambientes, etc.

## 4. package-lock.json

Es un archivo que provee informacion de las versiones y dependencias de los paquetes instalados que se encuentran en `node_modules`

## 5. package.json

Es un archivo donde se listan todas las dependencias que la aplicacion tiene, la misma tambien define los comandos disponibles para ejecutar sobre la aplicacion.

## 6. public

Una carpeta que guarda todo recurso estatico utilizado en la aplicacion. Pueden ser imagenes u otros archivos necesarios para operar.

## Proyectos sin uso de minimal

En caso de crear el proyecto sin la flag `minimal` se crearan archivos con la extension `spec`, los cuales son para realizar pruebas. Como no es necesario realizar pruebas pueden ignorar dichos archivos o eliminarlos.
