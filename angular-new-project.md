[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-create-project)

# Creacion de una aplicacion de Angular

Previamente a la creacion de una aplicacion de Angular, necesitamos tener el ambiente seteado y listo. Para ello hay que descargar `Node` e instalar `Angular CLI`, se puede encontrar los pasos del preparado del ambiente [aca](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-setup.md).

Una vez que tengamos el ambiente listo procederemos a crear una aplicacion de angular. Para ello seguir los siguientes pasos:

## 1. Creacion del proyecto

Abrir una terminal en el directorio del repositorio del obligatorio y ejectuar el siguiente comando:

```CMD
ng new <<nombre de la aplicacion de angular>> --minimal --routing --no-standalone
```

Parametros:

- `minimal`: sin frameworks de pruebas, solo por temas educativos
- `routing`: genera un modulo para el ruteo de raiz
- `no-standalone`: no genera el componente raiz autogestionable

## 2. Seleccionar el tipo de estilado

Luego de ejecutar el comando nos dara la opcion de seleccionar el tipo de estilado que queremos en nuestra aplicacion, seleccionar `CSS` y apretar `enter`:

<p align="center">
<img src="./images/image.png">
</p>
<p align="center">
[Opciones de estilado]
</p>

## 3. Decimos que no al Server-Side Rendering

<p align="center">
<img src="./images/image-1.png">
</p>
<p align="center">
[Server-Side Rendering]
</p>

## 4. Ejecutar la aplicacion

Una vez que la aplicacion terminara de crearse, situarse en el directorio de la aplicacion

```CMD
cd <<nombre de la aplicacion>>
```

y ejectuar el siguiente comando:

```CMD
ng serve --open
```

Parametros:

- `open`: abrira automaticamente el navegador cuando la aplicacion este lista para usarse

## 5. Aplicacion en ejecucion

Si todo esta bien, tendremos la siguiente salida:

<p align="center">
<img src="./images/image-2.png">
</p>
<p align="center">
[Salida en la terminal]
</p>

<p align="center">
<img src="./images/image-3.png">
</p>
<p align="center">
[Aplicacion en ejecucion]
</p>

## Lecturas recomendadas

- [Creacion de proyecto](https://v17.angular.io/tutorial/first-app/first-app-lesson-01)
