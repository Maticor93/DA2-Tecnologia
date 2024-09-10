# Creacion de una solucion

- Para crear una solucion debemos situarnos con la terminal en el directorio donde queremos crear dicho archivo `.sln`. Dicho directorio debera de ser el del repositorio clonado.
- Una vez situados en dicho directorio con la terminal se debera de ejecutar el siguiente comando:

```
dotnet new sln --name 'Nombre de la solucion'
```
- Una vez creada la solucion crearemos dos directorios: `src` y `tests`. El directorio `src` servira para agrupar nuestro codigo fuente y el directorio `tests` servira para agrupar los proyectos de prueba. De esta forma tendremos una mejor organizacion en la solucion y en el repositorio. Para crear dichos directorios se puede hacer de manera tradicional (click derecho -> Nueva carpeta) o ejecutar los siguientes comandos independientemente:

```
mkdir src
mkdir tests
```
