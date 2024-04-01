# Creacion de proyecto de prueba unitaria por comandos

- Abrir terminal en el directorio de la solucion. Para saber si estamos bien situados ejecutar `ls` y se deberia de ver el archivo `.sln`

```C#
ls
```

Comandos:

- `ls`: lista elementos en un directorio

<p align="center">
<img src='./images/image-9.png'>
</p>

<p align="center">
[Terminal en directorio]
</p>

- Crear proyecto MSTest

```C#
dotnet new mstest -n Vidly.WebApi.UnitTests
```

Comandos y parametros:

- `new`: crea un nuevo proyecto
- `mstest`: tipo de proyecto a crear
- `-n`: nombre del proyecto

<p align="center">
<img src='./images/image-10.png'>
</p>

<p align="center">
[Creacion proyecto MSTest]
</p>

- Agregar proyecto creado a la solucion

```C#
dotnet sln add Vidly.WebApi.UnitTests
```

Comandos y parametros

- `sln`: operar con solucion
- `add`: agregar proyecto a la solucion
- `Vidly.WebApi.UnitTests`: nombre del proyecto a agregar a la solucion

<p align="center">
<img src='./images/image-11.png'>
</p>

<p align="center">
[Agregar a solucion]
</p>

- Chequear que se agrego el proyecto a la solucion

```C#
dotnet sln list
```

Comandos:

- `sln`: operar con solucion
- `list`: listar proyectos en solucion

<p align="center">
<img src='./images/image-12.png'>
</p>

<p align="center">
[Chequear que se agrego a la solucion]
</p>

- Agregar referencia al proyecto que se quiere probar.

  - Pararse en el proyecto de prueba

  ```C#
  cd Vidly.WebApi.UnitTests
  ```

  Comandos:

  - `cd`: entrar a un directorio

  <p align="center">
  <img src='./images/image-13.png'>
  </p>

  <p align="center">
  [Situarse en el proyecto de prueba]
  </p>

  - Agregar referencia a proyecto a probar

  ```C#
  dotnet add reference ../Vidly.WebApi/Vidly.WebApi.csproj
  ```

  Comandos:

  - `add`: operacion para agregar
  - `reference`: referencia a proyecto en solucion
  - `../Vidly.WebApi/Vidly.WebApi.csproj`: archivo de configuracion del proyecto, `../` sirve para ir al directorio raiz

  <p align="center">
  <img src='./images/image-14.png'>
  </p>

  <p align="center">
  [Agregar referencia]
  </p>

- Chequear que se agrego bien la referencia. Hacer doble click en `Vidly.WebApi.UnitTests.csproj`
<p align="center">
<img src='./images/image-15.png'>
</p>
<p align="center">
[Vidly.WebApi.UnitTests.csproj]
</p>
