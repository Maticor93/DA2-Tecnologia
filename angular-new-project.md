[Atras](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular)

# Creacion de una aplicacion de Angular

Previamente a la creacion de una aplicacion de Angular, necesitamos tener el ambiente seteado y listo. Para ello hay que descargar `Node` e instalar `Angular CLI`, se puede encontrar los pasos del preparado del ambiente [aca](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular/angular-setup.md).

Una vez que tengamos el ambiente listo procederemos a crear una aplicacion de angular. Para ello seguir los siguientes pasos:

Si tenemos descargado una aplicacion de Angular, lo unico que hay que hacer es instalar las dependencias del mismo de la siguiente manera, nos situamos en el directorio de la aplicacion y ejectuamos:

```CMD
npm install
```

Esto instalara todas las dependencias de la aplicacion Angular y podremos verificar que todo esta funcionando ejecutando el ultimo paso de la guia de `Creacion del proyecto`.

En caso de no contar con una aplicacion de Angular ya descargada, seguir los siguientes pasos para la creacion de una.

## 1. Creacion del proyecto

Abrir una terminal en el directorio del repositorio del obligatorio y ejectuar el siguiente comando:

```CMD
ng new MyFirstAngularApp --minimal --routing
```

Parametros:

- `minimal`: sin frameworks de pruebas, solo por temas educativos
- `routing`: genera un modulo para el ruteo de raiz

## 2. Seleccionar el tipo de estilado

Luego de ejecutar el comando nos dara la opcion de seleccionar el tipo de estilado que queremos en nuestra aplicacion, seleccionar `CSS` y apretar `enter`:

<p align="center">
<img src="./images/image.png">
</p>
<p align="center">
[Opciones de estilado]
</p>

## 3. Ejecutar la aplicacion

Una vez que la aplicacion terminara de crearse, abrir una terminal en el directorio de la aplicacion y ejectuar el siguiente comando:

```CMD
ng serve --open
```

Parametros:

- `open`: abrira automaticamente el navegador cuando la aplicacion este lista para usarse

## Lecturas recomendadas

- [Creacion de proyecto](https://v17.angular.io/tutorial/first-app/first-app-lesson-01)
