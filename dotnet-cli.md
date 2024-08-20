# Pasos

- Abrir una terminal y situarse en el directorio donde quieren crear el proyecto.

<p align="center">
  <img src="images/image-5.png"/>
</p>

- Crear una carpeta con el nombre del proyecto

```
  mkdir Vidly
```

<p align="center">
  <img src="images/image-6.png"/>
</p>

- Situarse en la consola en ese directorio

```
  vd Vidly
```

<p align="center">
  <img src="images/image-7.png"/>
</p>

- Crear el archivo .sln que es la solucion de nuestro proyecto.

```
  dotnet new sln -n Vidly
```

  <p align="center">
  <img src="images/image-8.png"/>
</p>

El parametro `-n` sirve para especificar un nombre, en este caso el nombre que queremos que tenga el archivo `.sln`.

- Crear el proyecto WebApi

```
  dotnet new webapi -au none --no-openapi -controllers -n Vidly.WebApi
```

  <p align="center">
  <img src="images/image-9.png"/>
</p>

El parametro `-au` sirve para configurar el tipo de autenticacion que queremos que se requiera, el valor `none` es para indicar que no queremos que se configure esto en nuestra WebApi.

- Agregarlo a la solucion que acabamos de crear

```
  dotnet sln add Vidly.WebApi
```

  <p align="center">
  <img src="images/image-10.png"/>
</p>

- Comprobar que se agrego bien

```
  dotnet sln list
```

  <p align="center">
  <img src="images/image-11.png"/>
</p>
