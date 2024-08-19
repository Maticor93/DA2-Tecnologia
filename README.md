# Configuracino de repo

A continuacion se pueden encontrar aquellos archivos que son requeridos en la solucion junto con una breve descripcion de su funcionalidad dentro del repositorio y de la solucion.

## Archivos

- **.gitignore**: Este archivo es para ignorar aquellos archivos que no se quiere tener un control de version. Esto quiere decir, que ciertos archivos por mas que sean modificados, eliminados o agregados, no se vera ningun cambio efectuado en el historico de cambios de git al momento de crear un commit. Para que este archivo haga efecto, tiene que ser controlado primero por git antes de aquellos archivos que queremos ignorar. En caso de agregar este archivo posteriormente al repo y los archivos que queremos ignorar ya estan siendo trackeados por git, estos deberan de ser eliminados, commitear la eliminacion de los mismos y luego cuando vuelvan a ser agregados estos ya no se veran en el historico de cambios. La eliminacion de los archivos y el commit hacen que git deje de trackear los cambios en esos archivos para que pueda tener efecto el gitignore.

- **.editorconfig**: Configuracion de reglas de clean code para C#.

- **Directory.Build.props**: Archivo donde se especifican aquellos paquetes junto con sus versiones que son usados por todos los proyectos locales de la solucion. Es una forma mas rapida de controlar sus versiones y que los paquetes locales se actualicen en simultaneo. Es muy util este archivo para tener centralizado aquellas dependencias transversales que impactan a todos los proyectos de la solucion.

- **pull_request_template.md**: Es una guia sobre la informacion a incluir en los pull request que se creen. La misma se debera de modificar en las partes necesarias para agregar informacion sobre el PR del trabajo realizado.

- **.github/workflows/build-and-test.yml**: Es una configuracion para ejecutar tareas al momento de realizar ciertas acciones en github. Esta configurado para que haga build y corra las pruebas junto con el chequeo de cobertura del codigo, cuando se crea un PR y cuando se mergea codigo a una rama.

- **.github/workflows/code-analysis**: Es una configuracion que analiza el codigo en funcion a los parametros del archivo **.editorconfig**.

# Badges

Las badges que se van agregar son indicadores del estado en el que se encuentra nuestro proyecto. Son una ayuda visual mas rapida sobre el estado de nuestro codigo.

```md
[![Build and Test](https://github.com/daniel18acevedo/style-analysis/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/daniel18acevedo/style-analysis/actions/workflows/build-and-test.yml)
```
<p align="center">
  [Badge de build y test]
</p>

```md
[![Clean Code](https://github.com/daniel18acevedo/style-analysis/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/daniel18acevedo/style-analysis/actions/workflows/code-analysis.yml)
```
<p align="center">
  [Badge de clean code]
</p>

Se deberan de adecuar las rutas acorde a sus repositorios.

# Configuracion de branches

Se requiere que configuren reglas en las branches principales para evitar conflictos al momento de mergear.

- Ir a Settings (Ultima opcion en la barra de navegacion en github en el repositorio)
<p align="center">
<img src="images/image-1.png"/>
</p>

## General

- Ir a General
<p align="center">
<img src="images/image-10.png"/>
</p>

- La branch por defecto debera ser `develop`
<p align="center">
<img src="images/image-7.png"/>
</p>

- Configurar la seccion de `Pull Requests` de la siguiente manera
<p align="center">
<img src="images/image-8.png"/>
</p>

## Branches

- Ir a Branches
<p align="center">
<img src="images/image-2.png"/>
</p>

- Crear una nueva regla
<p align="center">
<img src="images/image-3.png"/>
</p>

- En el nombre de la rama poner: `main`

- Seleccionar la opcion `Require a pull request before merging`
<p align="center">
<img src="images/image-4.png"/>
</p>

- Seleccionar `Require status checks to pass before merging` y poner `Build`, `Test` y `Analysis`
<p align="center">
<img src="images/image-5.png"/>
</p>

- Seleccionar `Lock branch`
<p align="center">
<img src="images/image-6.png"/>
</p>

- Para terminar apretar `Create`

- Replicar lo mismo para otra branch llamada `develop`
